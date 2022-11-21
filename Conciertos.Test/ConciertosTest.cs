using Beca.ConciertoInfo.API.Models;
using Conciertos.Test;

namespace Conciertoes.Test
{
    public class ConciertoesTest
    {
        // Nombre del concierto mayor que 1
        [Fact]
        public void crearConcierto_validarNombre()
        {
            ConciertoForCreationDto conciertoCreado = new ConciertoForCreationDto()
            {
                Name = "Concierto",
                Description = "Descripcion"
            };

            var longCadena = conciertoCreado.Name.Length;

            // Assert
            Assert.True(1 < longCadena);
        }

        // Descripción del concierto mayor que 1 y menor que 200 
        [Fact]
        public void crearConcierto_validarDescripcion()
        {
            ConciertoForCreationDto conciertoCreado = new ConciertoForCreationDto()
            {
                Name = "Concierto",
                Description = "Descripcion"
            };

            var longCadena = conciertoCreado.Description.Length;

            // Assert
            Assert.True(200 > longCadena);
        }
    }
}