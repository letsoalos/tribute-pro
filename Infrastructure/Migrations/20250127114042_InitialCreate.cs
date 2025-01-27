using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Suburb = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupTypeCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BenefitTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenefitTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BurialSchemes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsPayoutPlan = table.Column<bool>(type: "bit", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BurialSchemes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BurialSocieties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ContactPerson = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Members = table.Column<int>(type: "int", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BurialSocieties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ethnicities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ethnicities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaritalStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaritalStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PolicyTypes",
                columns: table => new
                {
                    PolicyTypeCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyTypes", x => x.PolicyTypeCode);
                });

            migrationBuilder.CreateTable(
                name: "PremiumPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BasePremium = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PlanType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PremiumPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Relationships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relationships", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Titles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BurialPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BurialSchemeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    BasePremium = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxMembers = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BurialPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BurialPlans_BurialSchemes_BurialSchemeId",
                        column: x => x.BurialSchemeId,
                        principalTable: "BurialSchemes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AgeRangePremia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PremiumPlanId = table.Column<int>(type: "int", nullable: false),
                    AgeFrom = table.Column<int>(type: "int", nullable: false),
                    AgeTo = table.Column<int>(type: "int", nullable: false),
                    MonthlyPremium = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgeRangePremia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgeRangePremia_PremiumPlans_PremiumPlanId",
                        column: x => x.PremiumPlanId,
                        principalTable: "PremiumPlans",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedByUserId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branches_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Branches_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Benefits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BurialPlanId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BenefitTypeId = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Benefits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Benefits_BenefitTypes_BenefitTypeId",
                        column: x => x.BenefitTypeId,
                        principalTable: "BenefitTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Benefits_BurialPlans_BurialPlanId",
                        column: x => x.BurialPlanId,
                        principalTable: "BurialPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BurialPlanAddons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BurialPlanId = table.Column<int>(type: "int", nullable: false),
                    AddonId = table.Column<int>(type: "int", nullable: false),
                    IsMandatory = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BurialPlanAddons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BurialPlanAddons_Addons_AddonId",
                        column: x => x.AddonId,
                        principalTable: "Addons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BurialPlanAddons_BurialPlans_BurialPlanId",
                        column: x => x.BurialPlanId,
                        principalTable: "BurialPlans",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExtendedMemberProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BurialPlanId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EligibilityCriteria = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtendedMemberProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExtendedMemberProducts_BurialPlans_BurialPlanId",
                        column: x => x.BurialPlanId,
                        principalTable: "BurialPlans",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdentityTypeId = table.Column<int>(type: "int", nullable: false),
                    IdentityNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    OtherIdentity = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    EthnicityId = table.Column<int>(type: "int", nullable: false),
                    MaritalStatusId = table.Column<int>(type: "int", nullable: false),
                    CellPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AltNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Suburb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    Consent = table.Column<bool>(type: "bit", nullable: false),
                    BurialPlanId = table.Column<int>(type: "int", nullable: true),
                    BurialSocietyId = table.Column<int>(type: "int", nullable: true),
                    DateJoined = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedByUserId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clients_BurialPlans_BurialPlanId",
                        column: x => x.BurialPlanId,
                        principalTable: "BurialPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clients_BurialSocieties_BurialSocietyId",
                        column: x => x.BurialSocietyId,
                        principalTable: "BurialSocieties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clients_Ethnicities_EthnicityId",
                        column: x => x.EthnicityId,
                        principalTable: "Ethnicities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clients_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clients_IdentityTypes_IdentityTypeId",
                        column: x => x.IdentityTypeId,
                        principalTable: "IdentityTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clients_MaritalStatuses_MaritalStatusId",
                        column: x => x.MaritalStatusId,
                        principalTable: "MaritalStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clients_Titles_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Titles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    TitleId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    RelationshipId = table.Column<int>(type: "int", nullable: false),
                    IsBeneficiary = table.Column<bool>(type: "bit", nullable: true, comment: "Applicable only for funeral plans with payout benefits"),
                    DateJoined = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedByUserId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Members_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Members_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Members_Relationships_RelationshipId",
                        column: x => x.RelationshipId,
                        principalTable: "Relationships",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Members_Titles_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Titles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Policies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyTypeCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PolicyNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    PremiumPlanId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CurrentStatusId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Policies_AppStatuses_CurrentStatusId",
                        column: x => x.CurrentStatusId,
                        principalTable: "AppStatuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Policies_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Policies_PolicyTypes_PolicyTypeCode",
                        column: x => x.PolicyTypeCode,
                        principalTable: "PolicyTypes",
                        principalColumn: "PolicyTypeCode");
                    table.ForeignKey(
                        name: "FK_Policies_PremiumPlans_PremiumPlanId",
                        column: x => x.PremiumPlanId,
                        principalTable: "PremiumPlans",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PolicyStatusHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusChangedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChangedUserById = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyStatusHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PolicyStatusHistories_Policies_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "Policies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgeRangePremia_PremiumPlanId",
                table: "AgeRangePremia",
                column: "PremiumPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Benefits_BenefitTypeId",
                table: "Benefits",
                column: "BenefitTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Benefits_BurialPlanId",
                table: "Benefits",
                column: "BurialPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_AddressId",
                table: "Branches",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_ProvinceId",
                table: "Branches",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_BurialPlanAddons_AddonId",
                table: "BurialPlanAddons",
                column: "AddonId");

            migrationBuilder.CreateIndex(
                name: "IX_BurialPlanAddons_BurialPlanId",
                table: "BurialPlanAddons",
                column: "BurialPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_BurialPlans_BurialSchemeId",
                table: "BurialPlans",
                column: "BurialSchemeId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_CellPhone",
                table: "Clients",
                column: "CellPhone");

            migrationBuilder.CreateIndex(
                name: "IX_Client_DateOfBirth",
                table: "Clients",
                column: "DateOfBirth");

            migrationBuilder.CreateIndex(
                name: "IX_Client_Email",
                table: "Clients",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Client_FirstName",
                table: "Clients",
                column: "FirstName");

            migrationBuilder.CreateIndex(
                name: "IX_Client_IdentityNumber",
                table: "Clients",
                column: "IdentityNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Client_LastName",
                table: "Clients",
                column: "LastName");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_BranchId",
                table: "Clients",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_BurialPlanId",
                table: "Clients",
                column: "BurialPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_BurialSocietyId",
                table: "Clients",
                column: "BurialSocietyId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_EthnicityId",
                table: "Clients",
                column: "EthnicityId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_GenderId",
                table: "Clients",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_IdentityTypeId",
                table: "Clients",
                column: "IdentityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_MaritalStatusId",
                table: "Clients",
                column: "MaritalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_TitleId",
                table: "Clients",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtendedMemberProducts_BurialPlanId",
                table: "ExtendedMemberProducts",
                column: "BurialPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_ClientId",
                table: "Members",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_GenderId",
                table: "Members",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_RelationshipId",
                table: "Members",
                column: "RelationshipId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_TitleId",
                table: "Members",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Policies_ClientId",
                table: "Policies",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Policies_CurrentStatusId",
                table: "Policies",
                column: "CurrentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Policies_PolicyTypeCode",
                table: "Policies",
                column: "PolicyTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_Policies_PremiumPlanId",
                table: "Policies",
                column: "PremiumPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyStatusHistories_PolicyId",
                table: "PolicyStatusHistories",
                column: "PolicyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgeRangePremia");

            migrationBuilder.DropTable(
                name: "Benefits");

            migrationBuilder.DropTable(
                name: "BurialPlanAddons");

            migrationBuilder.DropTable(
                name: "ExtendedMemberProducts");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "PolicyStatusHistories");

            migrationBuilder.DropTable(
                name: "BenefitTypes");

            migrationBuilder.DropTable(
                name: "Addons");

            migrationBuilder.DropTable(
                name: "Relationships");

            migrationBuilder.DropTable(
                name: "Policies");

            migrationBuilder.DropTable(
                name: "AppStatuses");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "PolicyTypes");

            migrationBuilder.DropTable(
                name: "PremiumPlans");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "BurialPlans");

            migrationBuilder.DropTable(
                name: "BurialSocieties");

            migrationBuilder.DropTable(
                name: "Ethnicities");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "IdentityTypes");

            migrationBuilder.DropTable(
                name: "MaritalStatuses");

            migrationBuilder.DropTable(
                name: "Titles");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "BurialSchemes");
        }
    }
}
