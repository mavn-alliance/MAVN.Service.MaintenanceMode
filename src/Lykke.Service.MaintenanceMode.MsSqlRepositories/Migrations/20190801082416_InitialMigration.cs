using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lykke.Service.MaintenanceMode.MsSqlRepositories.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "maintenance");

            migrationBuilder.CreateTable(
                name: "maintenance",
                schema: "maintenance",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlannedDuration = table.Column<TimeSpan>(nullable: false),
                    ActualStart = table.Column<DateTime>(nullable: false),
                    Who = table.Column<string>(nullable: false),
                    Reason = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_maintenance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "maintenance_history",
                schema: "maintenance",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlannedDuration = table.Column<TimeSpan>(nullable: false),
                    ActualStart = table.Column<DateTime>(nullable: false),
                    Who = table.Column<string>(nullable: false),
                    Reason = table.Column<string>(nullable: false),
                    ActualFinish = table.Column<DateTime>(nullable: false),
                    ActualDuration = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_maintenance_history", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "maintenance",
                schema: "maintenance");

            migrationBuilder.DropTable(
                name: "maintenance_history",
                schema: "maintenance");
        }
    }
}
