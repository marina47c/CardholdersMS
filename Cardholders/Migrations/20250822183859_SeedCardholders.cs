using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cardholders.Migrations
{
    /// <inheritdoc />
    public partial class SeedCardholders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cardholders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1001, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TransactionCount = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cardholders", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cardholders",
                columns: new[] { "Id", "Address", "FirstName", "LastName", "PhoneNumber", "TransactionCount" },
                values: new object[,]
                {
                    { 1L, "11 Nexi St", "Dragan", "Jurić", "+38591234567", 0L },
                    { 2L, "34 Nexi St", "Matej", "Brlec", "+38591876543", 0L },
                    { 3L, "65 Nexi St", "Marija", "Štefić", "+38591876544", 0L },
                    { 4L, "65 Nexi St", "Kristina", "Sardelić", "+38591111222", 0L },
                    { 5L, "New Nexi St", "Marina", "Capan", "+38593344556", 0L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cardholders");
        }
    }
}
