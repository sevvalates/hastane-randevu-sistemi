using Microsoft.EntityFrameworkCore.Migrations;

namespace OnionArchitecture.HostpitalApi.Persistence.Migrations
{
    public partial class UpdatedDoctorEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Corporations_CorporationId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_CorporationId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "CorporationId",
                table: "Doctors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CorporationId",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_CorporationId",
                table: "Doctors",
                column: "CorporationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Corporations_CorporationId",
                table: "Doctors",
                column: "CorporationId",
                principalTable: "Corporations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
