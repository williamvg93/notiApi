using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "auditor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ActionDes = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_auditor", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "filednumber",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_filednumber", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "formats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_formats", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "genericpermissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genericpermissions", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "notificactionresponse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notificactionresponse", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "notificationstatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notificationstatus", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "notificationtype",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notificationtype", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "requirementtype",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requirementtype", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "rol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rol", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "submodules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_submodules", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "teachermodule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teachermodule", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "blockchain",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GeneratedHash = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdNotiRespFk = table.Column<int>(type: "int", nullable: false),
                    IdNotiTypeFk = table.Column<int>(type: "int", nullable: false),
                    IdAuditorFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blockchain", x => x.Id);
                    table.ForeignKey(
                        name: "FK_blockchain_auditor_IdAuditorFk",
                        column: x => x.IdAuditorFk,
                        principalTable: "auditor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_blockchain_notificactionresponse_IdNotiRespFk",
                        column: x => x.IdNotiRespFk,
                        principalTable: "notificactionresponse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_blockchain_notificationtype_IdNotiTypeFk",
                        column: x => x.IdNotiTypeFk,
                        principalTable: "notificationtype",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "notificationmodule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NotiSubject = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Text = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdNotiTypeFk = table.Column<int>(type: "int", nullable: false),
                    IdFiledNumFk = table.Column<int>(type: "int", nullable: false),
                    IdFotmatFk = table.Column<int>(type: "int", nullable: false),
                    IdNotiStatusFk = table.Column<int>(type: "int", nullable: false),
                    IdNotiResFk = table.Column<int>(type: "int", nullable: false),
                    IdRequiTypeFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notificationmodule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_notificationmodule_filednumber_IdFiledNumFk",
                        column: x => x.IdFiledNumFk,
                        principalTable: "filednumber",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_notificationmodule_formats_IdFotmatFk",
                        column: x => x.IdFotmatFk,
                        principalTable: "formats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_notificationmodule_notificactionresponse_IdNotiResFk",
                        column: x => x.IdNotiResFk,
                        principalTable: "notificactionresponse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_notificationmodule_notificationstatus_IdNotiStatusFk",
                        column: x => x.IdNotiStatusFk,
                        principalTable: "notificationstatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_notificationmodule_notificationtype_IdNotiTypeFk",
                        column: x => x.IdNotiTypeFk,
                        principalTable: "notificationtype",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_notificationmodule_requirementtype_IdRequiTypeFk",
                        column: x => x.IdRequiTypeFk,
                        principalTable: "requirementtype",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "rolteacher",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdRolFk = table.Column<int>(type: "int", nullable: false),
                    IdTecherModuFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rolteacher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_rolteacher_rol_IdRolFk",
                        column: x => x.IdRolFk,
                        principalTable: "rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rolteacher_teachermodule_IdTecherModuFk",
                        column: x => x.IdTecherModuFk,
                        principalTable: "teachermodule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "teachersubmodule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdTeacherModuFk = table.Column<int>(type: "int", nullable: false),
                    IdSubModulesFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teachersubmodule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_teachersubmodule_submodules_IdSubModulesFk",
                        column: x => x.IdSubModulesFk,
                        principalTable: "submodules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_teachersubmodule_teachermodule_IdTeacherModuFk",
                        column: x => x.IdTeacherModuFk,
                        principalTable: "teachermodule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "genericsubmodules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdRolFk = table.Column<int>(type: "int", nullable: false),
                    IdGenePermiFk = table.Column<int>(type: "int", nullable: false),
                    IdTeacSubModuFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genericsubmodules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_genericsubmodules_genericpermissions_IdGenePermiFk",
                        column: x => x.IdGenePermiFk,
                        principalTable: "genericpermissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_genericsubmodules_rol_IdRolFk",
                        column: x => x.IdRolFk,
                        principalTable: "rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_genericsubmodules_teachersubmodule_IdTeacSubModuFk",
                        column: x => x.IdTeacSubModuFk,
                        principalTable: "teachersubmodule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_blockchain_IdAuditorFk",
                table: "blockchain",
                column: "IdAuditorFk");

            migrationBuilder.CreateIndex(
                name: "IX_blockchain_IdNotiRespFk",
                table: "blockchain",
                column: "IdNotiRespFk");

            migrationBuilder.CreateIndex(
                name: "IX_blockchain_IdNotiTypeFk",
                table: "blockchain",
                column: "IdNotiTypeFk");

            migrationBuilder.CreateIndex(
                name: "IX_genericsubmodules_IdGenePermiFk",
                table: "genericsubmodules",
                column: "IdGenePermiFk");

            migrationBuilder.CreateIndex(
                name: "IX_genericsubmodules_IdRolFk",
                table: "genericsubmodules",
                column: "IdRolFk");

            migrationBuilder.CreateIndex(
                name: "IX_genericsubmodules_IdTeacSubModuFk",
                table: "genericsubmodules",
                column: "IdTeacSubModuFk");

            migrationBuilder.CreateIndex(
                name: "IX_notificationmodule_IdFiledNumFk",
                table: "notificationmodule",
                column: "IdFiledNumFk");

            migrationBuilder.CreateIndex(
                name: "IX_notificationmodule_IdFotmatFk",
                table: "notificationmodule",
                column: "IdFotmatFk");

            migrationBuilder.CreateIndex(
                name: "IX_notificationmodule_IdNotiResFk",
                table: "notificationmodule",
                column: "IdNotiResFk");

            migrationBuilder.CreateIndex(
                name: "IX_notificationmodule_IdNotiStatusFk",
                table: "notificationmodule",
                column: "IdNotiStatusFk");

            migrationBuilder.CreateIndex(
                name: "IX_notificationmodule_IdNotiTypeFk",
                table: "notificationmodule",
                column: "IdNotiTypeFk");

            migrationBuilder.CreateIndex(
                name: "IX_notificationmodule_IdRequiTypeFk",
                table: "notificationmodule",
                column: "IdRequiTypeFk");

            migrationBuilder.CreateIndex(
                name: "IX_rolteacher_IdRolFk",
                table: "rolteacher",
                column: "IdRolFk");

            migrationBuilder.CreateIndex(
                name: "IX_rolteacher_IdTecherModuFk",
                table: "rolteacher",
                column: "IdTecherModuFk");

            migrationBuilder.CreateIndex(
                name: "IX_teachersubmodule_IdSubModulesFk",
                table: "teachersubmodule",
                column: "IdSubModulesFk");

            migrationBuilder.CreateIndex(
                name: "IX_teachersubmodule_IdTeacherModuFk",
                table: "teachersubmodule",
                column: "IdTeacherModuFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "blockchain");

            migrationBuilder.DropTable(
                name: "genericsubmodules");

            migrationBuilder.DropTable(
                name: "notificationmodule");

            migrationBuilder.DropTable(
                name: "rolteacher");

            migrationBuilder.DropTable(
                name: "auditor");

            migrationBuilder.DropTable(
                name: "genericpermissions");

            migrationBuilder.DropTable(
                name: "teachersubmodule");

            migrationBuilder.DropTable(
                name: "filednumber");

            migrationBuilder.DropTable(
                name: "formats");

            migrationBuilder.DropTable(
                name: "notificactionresponse");

            migrationBuilder.DropTable(
                name: "notificationstatus");

            migrationBuilder.DropTable(
                name: "notificationtype");

            migrationBuilder.DropTable(
                name: "requirementtype");

            migrationBuilder.DropTable(
                name: "rol");

            migrationBuilder.DropTable(
                name: "submodules");

            migrationBuilder.DropTable(
                name: "teachermodule");
        }
    }
}
