using Beca.ConciertoInfo.API.Models;

namespace Beca.ConciertoInfo.API
{
    public class ConciertosDataStore
    {
        public List<ConciertoDto> Conciertos { get; set; }
        // public static ConciertosDataStore Current { get; } = new ConciertosDataStore();

        public ConciertosDataStore()
        {
            // init dummy data
            Conciertos = new List<ConciertoDto>()
            {
                new ConciertoDto()
                {
                     Id = 1,
                     Name = "Izal",
                     Description = "Concierto de Izal.",
                     Canciones = new List<CancionDto>()
                     {
                         new CancionDto() {
                             Id = 1,
                             Name = "Copacabana",
                             Description = "Incluso ahora\r\nQue ya no hay miedo\r\nQue nada tiembla\r\nSal de baño\r\nBrillo dorado en la piel." },
                          new CancionDto() {
                             Id = 2,
                             Name = "El baile",
                             Description = "Bailando hasta que todo acabe\r\nYa no importa lo que digan y menos lo que callen\r\nQue nos miren, que sientan, que rían, que se unan al baile\r\nBienvenidos a la última fiesta del no somos nadie." },
                     }
                },
                new ConciertoDto()
                {
                    Id = 2,
                    Name = "Imagine Dragons",
                    Description = "Concierto de Imagine Dragons.",
                    Canciones = new List<CancionDto>()
                     {
                         new CancionDto() {
                             Id = 3,
                             Name = "Wrecked",
                             Description = "Sometimes I wish that I could wish it all away\r\nOne more rainy day without you\r\nSometimes I wish that I could see you one more day\r\nOne more rainy day." },
                          new CancionDto() {
                             Id = 4,
                             Name = "Walking The Wire",
                             Description = "We're walking the wire, love\r\nWe're walking the wire, love\r\nWe couldn't be higher, up\r\nWe're walking the wire, wire, wire." },
                     }
                },
                new ConciertoDto()
                {
                    Id= 3,
                    Name = "OneRepublic",
                    Description = "Concierto de OneRepublic.",
                    Canciones = new List<CancionDto>()
                     {
                         new CancionDto() {
                             Id = 5,
                             Name = "Run",
                             Description = "You're gonna grow up, you're gonna get old\r\nAll that glitter don't turn to gold\r\nBut until then, just have your fun\r\nBoy, run, run, run, run, run." },
                          new CancionDto() {
                             Id = 6,
                             Name = "Better Days",
                             Description = "Oh, I know that there'll be better days\r\nOh, that sunshine 'bout to come my way\r\nMay we never ever shed another tear for today\r\n'Cause, oh, I know that there'll be better days." },
                     }
                }
            };

        }

    }
}
