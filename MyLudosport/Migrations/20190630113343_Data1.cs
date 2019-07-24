using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyLudosport.Migrations
{
    public partial class Data1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Duels",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    ChallengeTime = table.Column<DateTime>(nullable: false),
                    ReportTime = table.Column<DateTime>(nullable: false),
                    DuelResult = table.Column<int>(nullable: false),
                    DuelStatus = table.Column<int>(nullable: false),
                    Reporter = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Duels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityRole",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserClaim<string>",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: true),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserClaim<string>", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserRole<string>",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserRole<string>", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "AthleteAcademyRelation",
                columns: table => new
                {
                    AthleteId = table.Column<Guid>(nullable: false),
                    AcademyId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AthleteAcademyRelation", x => new { x.AthleteId, x.AcademyId });
                    table.UniqueConstraint("AK_AthleteAcademyRelation_AcademyId_AthleteId", x => new { x.AcademyId, x.AthleteId });
                });

            migrationBuilder.CreateTable(
                name: "IdentityUser",
                columns: table => new
                {
                    UserName = table.Column<string>(nullable: false),
                    Id = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    PersonalName = table.Column<string>(nullable: true),
                    FamilyName = table.Column<string>(nullable: true),
                    AcademyId = table.Column<Guid>(nullable: true),
                    ClanId = table.Column<Guid>(nullable: true),
                    SchoolId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "Judges",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AccountId = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Judges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Judges_IdentityUser_AccountId",
                        column: x => x.AccountId,
                        principalTable: "IdentityUser",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AcademyId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clans",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SchoolId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clans_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Athletes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AccountId = table.Column<string>(nullable: true),
                    BattleName = table.Column<string>(nullable: true),
                    Form1 = table.Column<int>(nullable: true),
                    Form2 = table.Column<int>(nullable: true),
                    Form3 = table.Column<int>(nullable: true),
                    Form4 = table.Column<int>(nullable: true),
                    Form5 = table.Column<int>(nullable: true),
                    Form6 = table.Column<int>(nullable: true),
                    Form7 = table.Column<int>(nullable: true),
                    Form8 = table.Column<int>(nullable: true),
                    Form9 = table.Column<int>(nullable: true),
                    CourseY = table.Column<int>(nullable: true),
                    ClanId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Athletes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Athletes_IdentityUser_AccountId",
                        column: x => x.AccountId,
                        principalTable: "IdentityUser",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Athletes_Clans_ClanId",
                        column: x => x.ClanId,
                        principalTable: "Clans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Academies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DeanId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Academies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Academies_Athletes_DeanId",
                        column: x => x.DeanId,
                        principalTable: "Athletes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AthleteClanRelation",
                columns: table => new
                {
                    AthleteId = table.Column<Guid>(nullable: false),
                    ClanId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AthleteClanRelation", x => new { x.AthleteId, x.ClanId });
                    table.ForeignKey(
                        name: "FK_AthleteClanRelation_Athletes_AthleteId",
                        column: x => x.AthleteId,
                        principalTable: "Athletes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AthleteClanRelation_Clans_ClanId",
                        column: x => x.ClanId,
                        principalTable: "Clans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AthleteDuelRelations",
                columns: table => new
                {
                    AthleteId = table.Column<Guid>(nullable: false),
                    DuelId = table.Column<Guid>(nullable: false),
                    Challenger = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AthleteDuelRelations", x => new { x.AthleteId, x.DuelId });
                    table.ForeignKey(
                        name: "FK_AthleteDuelRelations_Athletes_AthleteId",
                        column: x => x.AthleteId,
                        principalTable: "Athletes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AthleteDuelRelations_Duels_DuelId",
                        column: x => x.DuelId,
                        principalTable: "Duels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AthleteSchoolRelation",
                columns: table => new
                {
                    AthleteId = table.Column<Guid>(nullable: false),
                    SchoolId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AthleteSchoolRelation", x => new { x.AthleteId, x.SchoolId });
                    table.ForeignKey(
                        name: "FK_AthleteSchoolRelation_Athletes_AthleteId",
                        column: x => x.AthleteId,
                        principalTable: "Athletes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AthleteSchoolRelation_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Academies_DeanId",
                table: "Academies",
                column: "DeanId");

            migrationBuilder.CreateIndex(
                name: "IX_AthleteClanRelation_ClanId",
                table: "AthleteClanRelation",
                column: "ClanId");

            migrationBuilder.CreateIndex(
                name: "IX_AthleteDuelRelations_DuelId",
                table: "AthleteDuelRelations",
                column: "DuelId");

            migrationBuilder.CreateIndex(
                name: "IX_Athletes_AccountId",
                table: "Athletes",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Athletes_ClanId",
                table: "Athletes",
                column: "ClanId");

            migrationBuilder.CreateIndex(
                name: "IX_AthleteSchoolRelation_SchoolId",
                table: "AthleteSchoolRelation",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Clans_SchoolId",
                table: "Clans",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUser_AcademyId",
                table: "IdentityUser",
                column: "AcademyId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUser_ClanId",
                table: "IdentityUser",
                column: "ClanId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUser_SchoolId",
                table: "IdentityUser",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Judges_AccountId",
                table: "Judges",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schools_AcademyId",
                table: "Schools",
                column: "AcademyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AthleteAcademyRelation_Athletes_AthleteId",
                table: "AthleteAcademyRelation",
                column: "AthleteId",
                principalTable: "Athletes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AthleteAcademyRelation_Academies_AcademyId",
                table: "AthleteAcademyRelation",
                column: "AcademyId",
                principalTable: "Academies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUser_Academies_AcademyId",
                table: "IdentityUser",
                column: "AcademyId",
                principalTable: "Academies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUser_Clans_ClanId",
                table: "IdentityUser",
                column: "ClanId",
                principalTable: "Clans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUser_Schools_SchoolId",
                table: "IdentityUser",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Schools_Academies_AcademyId",
                table: "Schools",
                column: "AcademyId",
                principalTable: "Academies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Academies_Athletes_DeanId",
                table: "Academies");

            migrationBuilder.DropTable(
                name: "AthleteAcademyRelation");

            migrationBuilder.DropTable(
                name: "AthleteClanRelation");

            migrationBuilder.DropTable(
                name: "AthleteDuelRelations");

            migrationBuilder.DropTable(
                name: "AthleteSchoolRelation");

            migrationBuilder.DropTable(
                name: "IdentityRole");

            migrationBuilder.DropTable(
                name: "IdentityUserClaim<string>");

            migrationBuilder.DropTable(
                name: "IdentityUserRole<string>");

            migrationBuilder.DropTable(
                name: "Judges");

            migrationBuilder.DropTable(
                name: "Duels");

            migrationBuilder.DropTable(
                name: "Athletes");

            migrationBuilder.DropTable(
                name: "IdentityUser");

            migrationBuilder.DropTable(
                name: "Clans");

            migrationBuilder.DropTable(
                name: "Schools");

            migrationBuilder.DropTable(
                name: "Academies");
        }
    }
}
