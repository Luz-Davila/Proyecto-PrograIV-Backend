using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
#nullable disable
namespace HackerRank1.Migrations
{
    public partial class AddUsersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Cedula = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Name", "Cedula", "Email", "Role" },
                values: new object[,]
                {
                    { "María Rodríguez", "101110001", "maria.rodriguez@siapb.cr", "Administrativo" },
                    { "Carlos Méndez", "202220002", "carlos.mendez@siapb.cr", "Fontanero" },
                    { "Laura Jiménez", "303330003", "laura.jimenez@siapb.cr", "Junta Directiva" },
                    { "Andrés Mora", "404440004", "andres.mora@siapb.cr", "Administrativo" },
                    { "Sofía Vargas", "505550005", "sofia.vargas@siapb.cr", "Fontanero" },
                    { "Diego Castillo", "606660006", "diego.castillo@siapb.cr", "Administrativo" },
                    { "Valentina Cruz", "707770007", "valentina.cruz@siapb.cr", "Junta Directiva" },
                    { "Luis Herrera", "808880008", "luis.herrera@siapb.cr", "Fontanero" },
                    { "Camila Salazar", "909990009", "camila.salazar@siapb.cr", "Administrativo" },
                    { "Roberto Arias", "101010010", "roberto.arias@siapb.cr", "Junta Directiva" },
                    { "Daniela Quesada", "111110011", "daniela.quesada@siapb.cr", "Fontanero" },
                    { "Felipe Rojas", "121210012", "felipe.rojas@siapb.cr", "Administrativo" },
                    { "Marcela Solís", "131310013", "marcela.solis@siapb.cr", "Junta Directiva" },
                    { "Alejandro Núñez", "141410014", "alejandro.nunez@siapb.cr", "Fontanero" },
                    { "Paola Vega", "151510015", "paola.vega@siapb.cr", "Administrativo" },
                    { "Esteban Fallas", "161610016", "esteban.fallas@siapb.cr", "Junta Directiva" },
                    { "Natalia Bermúdez", "171710017", "natalia.bermudez@siapb.cr", "Fontanero" },
                    { "Mauricio Chaves", "181810018", "mauricio.chaves@siapb.cr", "Administrativo" },
                    { "Gabriela Montoya", "191910019", "gabriela.montoya@siapb.cr", "Junta Directiva" },
                    { "Sebastián Lara", "202020020", "sebastian.lara@siapb.cr", "Fontanero" },
                    { "Andrea Pizarro", "212120021", "andrea.pizarro@siapb.cr", "Administrativo" },
                    { "Óscar Badilla", "222220022", "oscar.badilla@siapb.cr", "Junta Directiva" },
                    { "Silvia Cordero", "232320023", "silvia.cordero@siapb.cr", "Fontanero" },
                    { "Jonathan Madrigal", "242420024", "jonathan.madrigal@siapb.cr", "Administrativo" },
                    { "Tatiana Esquivel", "252520025", "tatiana.esquivel@siapb.cr", "Junta Directiva" },
                    { "Randall Vindas", "262620026", "randall.vindas@siapb.cr", "Fontanero" },
                    { "Melissa Araya", "272720027", "melissa.araya@siapb.cr", "Administrativo" },
                    { "Christian Picado", "282820028", "christian.picado@siapb.cr", "Junta Directiva" },
                    { "Stephanie Ulate", "292920029", "stephanie.ulate@siapb.cr", "Fontanero" },
                    { "Gerardo Blanco", "303030030", "gerardo.blanco@siapb.cr", "Administrativo" },
                    { "Priscilla Mora", "313130031", "priscilla.mora@siapb.cr", "Junta Directiva" },
                    { "Alexis Quirós", "323230032", "alexis.quiros@siapb.cr", "Fontanero" },
                    { "Karina Zúñiga", "333330033", "karina.zuniga@siapb.cr", "Administrativo" },
                    { "Marco Villalobos", "343430034", "marco.villalobos@siapb.cr", "Junta Directiva" },
                    { "Diana Portuguez", "353530035", "diana.portuguez@siapb.cr", "Fontanero" },
                    { "Fabián Ugalde", "363630036", "fabian.ugalde@siapb.cr", "Administrativo" },
                    { "Cristina Solano", "373730037", "cristina.solano@siapb.cr", "Junta Directiva" },
                    { "Héctor Campos", "383830038", "hector.campos@siapb.cr", "Fontanero" },
                    { "Viviana Acosta", "393930039", "viviana.acosta@siapb.cr", "Administrativo" },
                    { "Pablo Leiva", "404040040", "pablo.leiva@siapb.cr", "Junta Directiva" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}