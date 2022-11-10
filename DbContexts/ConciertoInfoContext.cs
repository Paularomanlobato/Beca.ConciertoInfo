using Beca.ConciertoInfo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Beca.ConciertoInfo.API.DbContexts
{
    public class ConciertoInfoContext : DbContext
    {
        public DbSet<Concierto> Conciertos { get; set; } = null!;
        public DbSet<Cancion> Canciones { get; set; } = null!;

        public ConciertoInfoContext(DbContextOptions<ConciertoInfoContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Concierto>()
                .HasData(
               new Concierto("Izal")
               {
                   Id = 1,
                   Description = "Concierto de Izal."
               },
               new Concierto("Imagine Dragons")
               {
                   Id = 2,
                   Description = "Concierto de Imagine Dragons."
               },
               new Concierto("OneRepublic")
               {
                   Id = 3,
                   Description = "Concierto de OneRepublic."
               });

            modelBuilder.Entity<Cancion>()
             .HasData(
               new Cancion("Copacabana")
               {
                   Id = 1,
                   ConciertoId = 1,
                   Description = "Incluso ahora\r\nQue ya no hay miedo\r\nQue nada tiembla\r\nSal de baño\r\nBrillo dorado en la piel."
               },
               new Cancion("El baile")
               {
                   Id = 2,
                   ConciertoId = 1,
                   Description = "Bailando hasta que todo acabe\r\nYa no importa lo que digan y menos lo que callen\r\nQue nos miren, que sientan, que rían, que se unan al baile\r\nBienvenidos a la última fiesta del no somos nadie."
               },
                 new Cancion("Wrecked")
                 {
                     Id = 3,
                     ConciertoId = 2,
                     Description = "Sometimes I wish that I could wish it all away\r\nOne more rainy day without you\r\nSometimes I wish that I could see you one more day\r\nOne more rainy day."
                 },
               new Cancion("Walking The Wire")
               {
                   Id = 4,
                   ConciertoId = 2,
                   Description = "We're walking the wire, love\r\nWe're walking the wire, love\r\nWe couldn't be higher, up\r\nWe're walking the wire, wire, wire."
               },
               new Cancion("Run")
               {
                   Id = 5,
                   ConciertoId = 3,
                   Description = "You're gonna grow up, you're gonna get old\r\nAll that glitter don't turn to gold\r\nBut until then, just have your fun\r\nBoy, run, run, run, run, run."
               },
               new Cancion("Better Days")
               {
                   Id = 6,
                   ConciertoId = 3,
                   Description = "Oh, I know that there'll be better days\r\nOh, that sunshine 'bout to come my way\r\nMay we never ever shed another tear for today\r\n'Cause, oh, I know that there'll be better days."
               }
               );
            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("connectionstring");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
