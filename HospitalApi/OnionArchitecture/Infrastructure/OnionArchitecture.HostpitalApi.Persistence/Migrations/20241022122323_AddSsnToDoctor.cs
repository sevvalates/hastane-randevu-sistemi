using Microsoft.EntityFrameworkCore.Migrations;

namespace OnionArchitecture.HostpitalApi.Persistence.Migrations
{
    public partial class AddSsnToDoctor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "SocialSecurityNumber",
                table: "Doctors",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SocialSecurityNumber",
                table: "Doctors");
        }
    }
}
