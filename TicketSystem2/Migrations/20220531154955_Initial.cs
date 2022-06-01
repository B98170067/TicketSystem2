using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketSystem.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_Parameter",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Value = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Parameter", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "T_Permission",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Controller = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Action = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Permission", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "T_Role",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Role", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "T_Ticket",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Resolved = table.Column<bool>(type: "bit", nullable: false),
                    Severity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: ""),
                    Priority = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Ticket", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "T_User",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Account = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Password = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Type = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "T_Role_Permission",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    Permission = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Role_Permission", x => new { x.RoleID, x.Permission });
                    table.ForeignKey(
                        name: "FK_T_Role_Permission_T_Permission",
                        column: x => x.Permission,
                        principalTable: "T_Permission",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_T_Role_Permission_T_Role",
                        column: x => x.RoleID,
                        principalTable: "T_Role",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "T_User_Role",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_User_Role", x => new { x.UserID, x.RoleID });
                    table.ForeignKey(
                        name: "FK_T_User_Role_T_Role",
                        column: x => x.RoleID,
                        principalTable: "T_Role",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_T_User_Role_T_User",
                        column: x => x.UserID,
                        principalTable: "T_User",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_Role_Permission_Permission",
                table: "T_Role_Permission",
                column: "Permission");

            migrationBuilder.CreateIndex(
                name: "IX_T_User_Role_RoleID",
                table: "T_User_Role",
                column: "RoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_Parameter");

            migrationBuilder.DropTable(
                name: "T_Role_Permission");

            migrationBuilder.DropTable(
                name: "T_Ticket");

            migrationBuilder.DropTable(
                name: "T_User_Role");

            migrationBuilder.DropTable(
                name: "T_Permission");

            migrationBuilder.DropTable(
                name: "T_Role");

            migrationBuilder.DropTable(
                name: "T_User");
        }
    }
}
