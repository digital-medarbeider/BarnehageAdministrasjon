using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BarnehageAdministrasjon.Models.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Municipalities",
                columns: table => new
                {
                    MunicipalityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipalities", x => x.MunicipalityId);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    NationalId = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    MaritalStatus = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<int>(nullable: false),
                    FirstLanguage = table.Column<string>(nullable: true),
                    LevelOfSpoken = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.NationalId);
                });

            migrationBuilder.CreateTable(
                name: "SpecialRequirements",
                columns: table => new
                {
                    SpecialRequirementId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialRequirements", x => x.SpecialRequirementId);
                });

            migrationBuilder.CreateTable(
                name: "WeekDays",
                columns: table => new
                {
                    WeekId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Keyword = table.Column<string>(nullable: true),
                    Day = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekDays", x => x.WeekId);
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    ApplicationId = table.Column<Guid>(nullable: false),
                    ChildId = table.Column<string>(nullable: true),
                    FatherId = table.Column<string>(nullable: true),
                    MotherId = table.Column<string>(nullable: true),
                    MunicipalityId = table.Column<int>(nullable: false),
                    ChildName = table.Column<string>(nullable: true),
                    ChildAddress = table.Column<string>(nullable: true),
                    FatherName = table.Column<string>(nullable: true),
                    MotherName = table.Column<string>(nullable: true),
                    FirstLanguage = table.Column<string>(nullable: true),
                    LevelOfSpoken = table.Column<string>(nullable: true),
                    ApplicationStartDate = table.Column<DateTime>(nullable: false),
                    IsReducedFee = table.Column<bool>(nullable: false),
                    IsChooseDiffDays = table.Column<bool>(nullable: false),
                    ApplicationSubmitDate = table.Column<DateTime>(nullable: false),
                    KindergartenCoverage = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.ApplicationId);
                    table.ForeignKey(
                        name: "FK_Applications_Persons_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Persons",
                        principalColumn: "NationalId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Applications_Persons_FatherId",
                        column: x => x.FatherId,
                        principalTable: "Persons",
                        principalColumn: "NationalId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Applications_Persons_MotherId",
                        column: x => x.MotherId,
                        principalTable: "Persons",
                        principalColumn: "NationalId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Applications_Municipalities_MunicipalityId",
                        column: x => x.MunicipalityId,
                        principalTable: "Municipalities",
                        principalColumn: "MunicipalityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationKindergartenCoverage",
                columns: table => new
                {
                    ApplicationId = table.Column<Guid>(nullable: false),
                    WeekId = table.Column<int>(nullable: false),
                    WeekType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationKindergartenCoverage", x => new { x.ApplicationId, x.WeekId });
                    table.ForeignKey(
                        name: "FK_ApplicationKindergartenCoverage_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationKindergartenCoverage_WeekDays_WeekId",
                        column: x => x.WeekId,
                        principalTable: "WeekDays",
                        principalColumn: "WeekId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationSpecRequirement",
                columns: table => new
                {
                    ApplicationId = table.Column<Guid>(nullable: false),
                    SpecialRequirementId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationSpecRequirement", x => new { x.ApplicationId, x.SpecialRequirementId });
                    table.ForeignKey(
                        name: "FK_ApplicationSpecRequirement_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationSpecRequirement_SpecialRequirements_SpecialRequirementId",
                        column: x => x.SpecialRequirementId,
                        principalTable: "SpecialRequirements",
                        principalColumn: "SpecialRequirementId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Municipalities",
                columns: new[] { "MunicipalityId", "Name" },
                values: new object[,]
                {
                    { 1, "Oslo" },
                    { 2, "Oslo2" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "NationalId", "Address", "Email", "FirstLanguage", "FirstName", "LastName", "LevelOfSpoken", "MaritalStatus", "PhoneNumber" },
                values: new object[,]
                {
                    { "11111111111", "oslo, Norway", "abc@xyz.com", "Norway", "Arne", "Legureett", "Medium", null, 11111111 },
                    { "44444444444", "oslo, Norway", "martin@xyz.com", "Norway", "Martin", "Legureett", "Low", null, 33333333 },
                    { "22222222222", "oslo, Norway", "abc@xyz.com", "Norway", "Per", "Legureett", "Low", "Married", 22222222 },
                    { "33333333333", "oslo, Norway", "abc@xyz.com", "Norway", "Marianna", "Legureett", "Low", "Married", 33333333 }
                });

            migrationBuilder.InsertData(
                table: "SpecialRequirements",
                columns: new[] { "SpecialRequirementId", "Name" },
                values: new object[,]
                {
                    { 1, "Disabilities" },
                    { 2, "Illinessinfamily" }
                });

            migrationBuilder.InsertData(
                table: "WeekDays",
                columns: new[] { "WeekId", "Day", "Keyword" },
                values: new object[,]
                {
                    { 1, "Monday", "M" },
                    { 2, "Tuesday", "T" },
                    { 3, "Wednesday", "W" },
                    { 4, "Thursday", "T" },
                    { 5, "Friday", "F" }
                });

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "ApplicationId", "ApplicationStartDate", "ApplicationSubmitDate", "ChildAddress", "ChildId", "ChildName", "FatherId", "FatherName", "FirstLanguage", "IsChooseDiffDays", "IsReducedFee", "KindergartenCoverage", "LevelOfSpoken", "MotherId", "MotherName", "MunicipalityId", "Status" },
                values: new object[] { new Guid("1a3b944e-3632-467b-a53a-206305310bae"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "11111111111", null, "22222222222", null, null, true, true, 60, null, "33333333333", null, 1, "Draft" });

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "ApplicationId", "ApplicationStartDate", "ApplicationSubmitDate", "ChildAddress", "ChildId", "ChildName", "FatherId", "FatherName", "FirstLanguage", "IsChooseDiffDays", "IsReducedFee", "KindergartenCoverage", "LevelOfSpoken", "MotherId", "MotherName", "MunicipalityId", "Status" },
                values: new object[] { new Guid("e2f7997c-ba14-46d4-b417-aef06b64d33e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "44444444444", null, "22222222222", null, null, true, false, 60, null, "33333333333", null, 1, "Draft" });

            migrationBuilder.InsertData(
                table: "ApplicationKindergartenCoverage",
                columns: new[] { "ApplicationId", "WeekId", "WeekType" },
                values: new object[,]
                {
                    { new Guid("1a3b944e-3632-467b-a53a-206305310bae"), 1, "Even" },
                    { new Guid("1a3b944e-3632-467b-a53a-206305310bae"), 3, "Even" },
                    { new Guid("1a3b944e-3632-467b-a53a-206305310bae"), 2, "Odd" },
                    { new Guid("1a3b944e-3632-467b-a53a-206305310bae"), 4, "Odd" },
                    { new Guid("e2f7997c-ba14-46d4-b417-aef06b64d33e"), 2, "Even" },
                    { new Guid("e2f7997c-ba14-46d4-b417-aef06b64d33e"), 4, "Even" },
                    { new Guid("e2f7997c-ba14-46d4-b417-aef06b64d33e"), 1, "Odd" },
                    { new Guid("e2f7997c-ba14-46d4-b417-aef06b64d33e"), 3, "Odd" }
                });

            migrationBuilder.InsertData(
                table: "ApplicationSpecRequirement",
                columns: new[] { "ApplicationId", "SpecialRequirementId" },
                values: new object[,]
                {
                    { new Guid("1a3b944e-3632-467b-a53a-206305310bae"), 1 },
                    { new Guid("1a3b944e-3632-467b-a53a-206305310bae"), 2 },
                    { new Guid("e2f7997c-ba14-46d4-b417-aef06b64d33e"), 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationKindergartenCoverage_WeekId",
                table: "ApplicationKindergartenCoverage",
                column: "WeekId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_ChildId",
                table: "Applications",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_FatherId",
                table: "Applications",
                column: "FatherId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_MotherId",
                table: "Applications",
                column: "MotherId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_MunicipalityId",
                table: "Applications",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationSpecRequirement_SpecialRequirementId",
                table: "ApplicationSpecRequirement",
                column: "SpecialRequirementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationKindergartenCoverage");

            migrationBuilder.DropTable(
                name: "ApplicationSpecRequirement");

            migrationBuilder.DropTable(
                name: "WeekDays");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "SpecialRequirements");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Municipalities");
        }
    }
}
