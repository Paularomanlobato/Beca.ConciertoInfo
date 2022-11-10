using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beca.ConciertoInfo.API.Migrations
{
    public partial class ConciertoInfoDBInitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conciertos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conciertos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Canciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    ConciertoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Canciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Canciones_Cconciertos_ConciertoId",
                        column: x => x.ConciertoId,
                        principalTable: "Conciertos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Conciertos",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "Concierto de Izal.", "Izal" });

            migrationBuilder.InsertData(
                table: "Conciertos",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 2, "Concierto de Imagine Dragons.", "Imagine Dragons" });

            migrationBuilder.InsertData(
                table: "Conciertos",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 3, "Concierto de OneRepublic.", "OneRepublic" });

            migrationBuilder.InsertData(
                table: "Canciones",
                columns: new[] { "Id", "ConciertoId", "Description", "Name" },
                values: new object[] { 1, 1, "Incluso ahora\r\nQue ya no hay miedo\r\nQue nada tiembla\r\nSal de baño\r\nBrillo dorado en la piel." });

            migrationBuilder.InsertData(
                table: "Canciones",
                columns: new[] { "Id", "ConciertoId", "Description", "Name" },
                values: new object[] { 2, 1, "Bailando hasta que todo acabe\r\nYa no importa lo que digan y menos lo que callen\r\nQue nos miren, que sientan, que rían, que se unan al baile\r\nBienvenidos a la última fiesta del no somos nadie." });

            migrationBuilder.InsertData(
                table: "Canciones",
                columns: new[] { "Id", "ConciertoId", "Description", "Name" },
                values: new object[] { 3, 2, "Sometimes I wish that I could wish it all away\r\nOne more rainy day without you\r\nSometimes I wish that I could see you one more day\r\nOne more rainy day." });

            migrationBuilder.InsertData(
                table: "Canciones",
                columns: new[] { "Id", "ConciertoId", "Description", "Name" },
                values: new object[] { 4, 2, "We're walking the wire, love\r\nWe're walking the wire, love\r\nWe couldn't be higher, up\r\nWe're walking the wire, wire, wire." });

            migrationBuilder.InsertData(
                table: "Canciones",
                columns: new[] { "Id", "ConciertoId", "Description", "Name" },
                values: new object[] { 5, 3, "You're gonna grow up, you're gonna get old\r\nAll that glitter don't turn to gold\r\nBut until then, just have your fun\r\nBoy, run, run, run, run, run." });

            migrationBuilder.InsertData(
                table: "Canciones",
                columns: new[] { "Id", "ConciertoId", "Description", "Name" },
                values: new object[] { 6, 3, "Oh, I know that there'll be better days\r\nOh, that sunshine 'bout to come my way\r\nMay we never ever shed another tear for today\r\n'Cause, oh, I know that there'll be better days." });

            migrationBuilder.CreateIndex(
                name: "IX_Canciones_ConciertoId",
                table: "Canciones",
                column: "ConciertoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Canciones");

            migrationBuilder.DropTable(
                name: "Conciertos");
        }
    }
}
