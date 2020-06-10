using Microsoft.EntityFrameworkCore.Migrations;

namespace AddressBookWebAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "addressBooks",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(14)", nullable: true),
                    CellNumber = table.Column<string>(type: "nvarchar(14)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    UpdatedDate = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addressBooks", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "addressBooks");
        }
    }
}
