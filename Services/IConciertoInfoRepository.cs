using Beca.ConciertoInfo.API.Entities;

namespace Beca.ConciertoInfo.API.Services
{
    public interface IConciertoInfoRepository
    {
        Task<IEnumerable<Concierto>> GetConciertosAsync();
        Task<(IEnumerable<Concierto>, PaginationMetadata)> GetConciertosAsync(
            string? name, string? searchQuery, int pageNumber, int pageSize);
        Task<Concierto?> GetConciertoAsync(int conciertoId, bool includeCanciones);
        Task<bool> ConciertoExistsAsync(int conciertoId);
        Task<IEnumerable<Cancion>> GetCancionesForConciertoAsync(int conciertoId);
        Task<Cancion?> GetCancionesForConciertoAsync(int conciertoId,
            int cancionId);
        Task AddCancionesForConciertoAsync(int conciertoId, Cancion cancion);
        void DeleteCanciones(Cancion cancion);
        Task<bool> ConciertoNameMatchesConciertoId(string? conciertoName, int conciertoId);
        Task<bool> SaveChangesAsync();

        Task AddConciertoAsync(Concierto concierto);

        void DeleteConcierto(Concierto concierto);
    }
}
