using Beca.ConciertoInfo.API.Services;
using Beca.ConciertoInfo.API.DbContexts;
using Beca.ConciertoInfo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Beca.ConciertoInfo.API.Services
{
    public class ConciertoInfoRepository : IConciertoInfoRepository
    {
        private readonly ConciertoInfoContext _context;

        public ConciertoInfoRepository(ConciertoInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Concierto>> GetConciertosAsync()
        {
            return await _context.Conciertos.OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<bool> ConciertoNameMatchesConciertoId(string? conciertoName, int conciertoId)
        {
            return await _context.Conciertos.AnyAsync(c => c.Id == conciertoId && c.Name == conciertoName);
        }

        public async Task<(IEnumerable<Concierto>, PaginationMetadata)> GetConciertosAsync(
            string? name, string? searchQuery, int pageNumber, int pageSize)
        {
            // collection to start from
            var collection = _context.Conciertos as IQueryable<Concierto>;

            if (!string.IsNullOrWhiteSpace(name))
            {
                name = name.Trim();
                collection = collection.Where(c => c.Name == name);
            }

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery = searchQuery.Trim();
                collection = collection.Where(a => a.Name.Contains(searchQuery)
                    || (a.Description != null && a.Description.Contains(searchQuery)));
            }

            var totalItemCount = await collection.CountAsync();

            var paginationMetadata = new PaginationMetadata(
                totalItemCount, pageSize, pageNumber);

            var collectionToReturn = await collection.OrderBy(c => c.Name)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();

            return (collectionToReturn, paginationMetadata);
        }



        public async Task<Concierto?> GetConciertoAsync(int conciertoId, bool includeCanciones)
        {
            if (includeCanciones)
            {
                return await _context.Conciertos.Include(c => c.Canciones)
                    .Where(c => c.Id == conciertoId).FirstOrDefaultAsync();
            }

            return await _context.Conciertos
                  .Where(c => c.Id == conciertoId).FirstOrDefaultAsync();
        }

        public async Task<bool> ConciertoExistsAsync(int conciertoId)
        {
            return await _context.Conciertos.AnyAsync(c => c.Id == conciertoId);
        }

        public async Task<Cancion?> GetCancionesForConciertoAsync(
            int conciertoId,
            int cancionId)
        {
            return await _context.Canciones
               .Where(p => p.ConciertoId == conciertoId && p.Id == cancionId)
               .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Cancion>> GetCancionesForConciertoAsync(
            int conciertoId)
        {
            return await _context.Canciones
                           .Where(p => p.ConciertoId == conciertoId).ToListAsync();
        }

        public async Task AddCancionesForConciertoAsync(int conciertoId,
            Cancion cancion)
        {
            var concierto = await GetConciertoAsync(conciertoId, false);
            if (concierto != null)
            {
                concierto.Canciones.Add(cancion);
            }
        }

        public void DeleteCanciones(Cancion cancion)
        {
            _context.Canciones.Remove(cancion);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        public async Task AddConciertoAsync(Concierto concierto)
        {
            if (concierto != null)
            {
                _context.Conciertos.Add(concierto);
            }
        }

        public async void DeleteConcierto(Concierto concierto)
        {
            var listaCanciones = await _context.Canciones.Where(p => p.ConciertoId == concierto.Id).ToListAsync();

            foreach (var cancion in listaCanciones)
            {
                DeleteCanciones(cancion);
            }

            _context.Conciertos.Remove(concierto);
        }
    }
}
