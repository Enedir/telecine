using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TopCine.Infra.ORM.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "process");

            migrationBuilder.CreateTable(
                name: "TBUsers",
                schema: "process",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Email = table.Column<string>(maxLength: 30, nullable: true),
                    AccessLevel = table.Column<int>(nullable: false),
                    Password = table.Column<string>(maxLength: 500, nullable: true),
                    InsertDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Id", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "process",
                table: "TBUsers",
                columns: new[] { "Id", "AccessLevel", "Email", "Name", "Password", "UpdateDate" },
                values: new object[] { 1L, 0, "admin.test@printwayy.com", "Admin", "827ccb0eea8a706c4c34a16891f84e7b", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBUsers",
                schema: "process");
        }
    }
}
