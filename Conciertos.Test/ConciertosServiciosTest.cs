using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Beca.ConciertoInfo.API.DbContexts;
using Beca.ConciertoInfo.API.Services;
using Conciertos.Test;

namespace Conciertoes.Test
{
    public class ConciertoesServiciosTest : IDisposable
    {
        private ConciertoInfoRepository _conciertoInfoRepository;
        public ConciertoesServiciosTest()
        {
            var connection = new SqliteConnection("Data source=BecaConciertoInfo.db");
            connection.Open();

            var optionsBuilder = new DbContextOptionsBuilder<ConciertoInfoContext>().UseSqlite(connection);
            var _dbContext = new ConciertoInfoContext(optionsBuilder.Options);

            _dbContext.Database.Migrate();

            _conciertoInfoRepository = new ConciertoInfoRepository(_dbContext);
        }
        public void Dispose()
        {

        }

        [Fact]
        public async Task ConciertoServicios_Canciones()
        {
            var concierto = await _conciertoInfoRepository.GetConciertoAsync(1, false);

            // Assert
            Assert.Empty(concierto.Canciones);
        }

        [Fact]
        public async Task ConciertoServicios_NumeroCanciones()
        {
            var concierto = await _conciertoInfoRepository.GetConciertoAsync(1, false);

            int numero = concierto.Canciones.Count;

            // Assert
            Assert.True(2 >= numero);
        }

        [Fact]
        public async Task ConciertoServicios_NombreConcierto()
        {
            var concierto = await _conciertoInfoRepository.GetConciertoAsync(1, false);

            // Assert
            Assert.Equal("Izal", concierto.Name);
        }
    }

}
