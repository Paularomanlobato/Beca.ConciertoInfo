using Beca.ConciertoInfo.API.Models;
using Xunit;

namespace Conciertos.Test
{
    public class CancionesTest
    {
        // Caracteres cancion mayor que 1
        [Fact]
        public void crearCancion_validarNombre()
        {
            CancionForCreationDto cancionCreada = new CancionForCreationDto()
            {
                Name = "Cancion",
                Description = "Descripcion"
            };

            var longCadena = cancionCreada.Name.Length;

            // Assert
            Assert.True(1 < longCadena);
        }

        // Descripcion cancion mayor que 1 y menor que 200 
        [Fact]
        public void crearCancion_validarDescripcion()
        {
            CancionForCreationDto cancionCreada = new CancionForCreationDto()
            {
                Name = "Cancion",
                Description = "Descripcion"
            };

            var longCadena = cancionCreada.Description.Length;

            // Assert
            Assert.True(200 > longCadena);
        }   
    }
}

