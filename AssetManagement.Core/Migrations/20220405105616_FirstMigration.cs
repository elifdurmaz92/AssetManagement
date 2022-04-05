using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AssetManagement.Core.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "sp_PersonnelAssetList");

            migrationBuilder.EnsureSchema(
                name: "sp_TeamAssetList");

            migrationBuilder.EnsureSchema(
                name: "sp_WarehouseAllAssetList");

            migrationBuilder.CreateTable(
                name: "AssetGroup",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetGroup", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AssetType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CommType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriptionNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LoginInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OwnerType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Page",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Page", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PersonnelAssetList",
                schema: "sp_PersonnelAssetList",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationNumber = table.Column<int>(type: "int", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssetType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AssetBrand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssetModel = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonnelAssetList", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SystemLists",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Project = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperationController = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperationAction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemLists", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TeamAssetList",
                schema: "sp_TeamAssetList",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationNumber = table.Column<int>(type: "int", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssetType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AssetBrand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssetModel = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamAssetList", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WarehouseAllAssetList",
                schema: "sp_WarehouseAllAssetList",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationNumber = table.Column<int>(type: "int", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssetType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AssetBrand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssetModel = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseAllAssetList", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AssetBrand",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetTypeID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetBrand", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AssetBrand_AssetType_AssetTypeID",
                        column: x => x.AssetTypeID,
                        principalTable: "AssetType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Personnel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterID = table.Column<int>(type: "int", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Personnel_Company_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Company",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PageClaim",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    PageID = table.Column<int>(type: "int", nullable: true),
                    RoleID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageClaim", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PageClaim_Page_PageID",
                        column: x => x.PageID,
                        principalTable: "Page",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PageClaim_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActionStatus",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusID = table.Column<int>(type: "int", nullable: false),
                    StatusActionID = table.Column<int>(type: "int", nullable: false),
                    StatusController = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusActionMetod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionStatus", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ActionStatus_Status_StatusID",
                        column: x => x.StatusID,
                        principalTable: "Status",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetBrandID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetModel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AssetModel_AssetBrand_AssetBrandID",
                        column: x => x.AssetBrandID,
                        principalTable: "AssetBrand",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Communication",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonnelID = table.Column<int>(type: "int", nullable: false),
                    CommTypeID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Communication", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Communication_CommType_CommTypeID",
                        column: x => x.CommTypeID,
                        principalTable: "CommType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Communication_Personnel_PersonnelID",
                        column: x => x.PersonnelID,
                        principalTable: "Personnel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonnelLoginInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonnelID = table.Column<int>(type: "int", nullable: false),
                    LoginInfoID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonnelLoginInfo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PersonnelLoginInfo_LoginInfo_LoginInfoID",
                        column: x => x.LoginInfoID,
                        principalTable: "LoginInfo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonnelLoginInfo_Personnel_PersonnelID",
                        column: x => x.PersonnelID,
                        principalTable: "Personnel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolePersonnel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonnelID = table.Column<int>(type: "int", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePersonnel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RolePersonnel_Personnel_PersonnelID",
                        column: x => x.PersonnelID,
                        principalTable: "Personnel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePersonnel_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PageClaimDetail",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    PageID = table.Column<int>(type: "int", nullable: false),
                    PageClaimID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageClaimDetail", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PageClaimDetail_Page_PageID",
                        column: x => x.PageID,
                        principalTable: "Page",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PageClaimDetail_PageClaim_PageClaimID",
                        column: x => x.PageClaimID,
                        principalTable: "PageClaim",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PageClaimDetail_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Asset",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationNumber = table.Column<int>(type: "int", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    AssetGroupID = table.Column<int>(type: "int", nullable: false),
                    AssetTypeID = table.Column<int>(type: "int", nullable: false),
                    AssetBrandID = table.Column<int>(type: "int", nullable: false),
                    AssetModelID = table.Column<int>(type: "int", nullable: false),
                    CurrencyID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsBarcode = table.Column<bool>(type: "bit", nullable: false),
                    Guarantee = table.Column<bool>(type: "bit", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RetireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asset", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Asset_AssetBrand_AssetBrandID",
                        column: x => x.AssetBrandID,
                        principalTable: "AssetBrand",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asset_AssetGroup_AssetGroupID",
                        column: x => x.AssetGroupID,
                        principalTable: "AssetGroup",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asset_AssetModel_AssetModelID",
                        column: x => x.AssetModelID,
                        principalTable: "AssetModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asset_AssetType_AssetTypeID",
                        column: x => x.AssetTypeID,
                        principalTable: "AssetType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asset_Company_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Company",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asset_Currency_CurrencyID",
                        column: x => x.CurrencyID,
                        principalTable: "Currency",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetBarcode",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetID = table.Column<int>(type: "int", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetBarcode", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AssetBarcode_Asset_AssetID",
                        column: x => x.AssetID,
                        principalTable: "Asset",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetCustomer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetID = table.Column<int>(type: "int", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetCustomer", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AssetCustomer_Asset_AssetID",
                        column: x => x.AssetID,
                        principalTable: "Asset",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetCustomer_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetDocument",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetID = table.Column<int>(type: "int", nullable: false),
                    PageCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetDocument", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AssetDocument_Asset_AssetID",
                        column: x => x.AssetID,
                        principalTable: "Asset",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetOwner",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetID = table.Column<int>(type: "int", nullable: false),
                    OwnerTypeID = table.Column<int>(type: "int", nullable: false),
                    PersonnelID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetOwner", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AssetOwner_Asset_AssetID",
                        column: x => x.AssetID,
                        principalTable: "Asset",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetOwner_OwnerType_OwnerTypeID",
                        column: x => x.OwnerTypeID,
                        principalTable: "OwnerType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetOwner_Personnel_PersonnelID",
                        column: x => x.PersonnelID,
                        principalTable: "Personnel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetPrice",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetID = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrencyID = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetPrice", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AssetPrice_Asset_AssetID",
                        column: x => x.AssetID,
                        principalTable: "Asset",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetPrice_Currency_CurrencyID",
                        column: x => x.CurrencyID,
                        principalTable: "Currency",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssetStatus",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetID = table.Column<int>(type: "int", nullable: false),
                    PersonnelID = table.Column<int>(type: "int", nullable: false),
                    StatusID = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetStatus", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AssetStatus_Asset_AssetID",
                        column: x => x.AssetID,
                        principalTable: "Asset",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetStatus_Personnel_PersonnelID",
                        column: x => x.PersonnelID,
                        principalTable: "Personnel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetStatus_Status_StatusID",
                        column: x => x.StatusID,
                        principalTable: "Status",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetWithoutBarcode",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetID = table.Column<int>(type: "int", nullable: false),
                    UnitID = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetWithoutBarcode", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AssetWithoutBarcode_Asset_AssetID",
                        column: x => x.AssetID,
                        principalTable: "Asset",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetWithoutBarcode_Unit_UnitID",
                        column: x => x.UnitID,
                        principalTable: "Unit",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetID = table.Column<int>(type: "int", nullable: false),
                    PersonnelID = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comment_Asset_AssetID",
                        column: x => x.AssetID,
                        principalTable: "Asset",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comment_Personnel_PersonnelID",
                        column: x => x.PersonnelID,
                        principalTable: "Personnel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ActionStatus",
                columns: new[] { "ID", "ActionText", "CreatedBy", "CreatedDate", "IsActive", "ModifiedBy", "ModifiedDate", "StatusActionID", "StatusActionMetod", "StatusController", "StatusID" },
                values: new object[,]
                {
                    { 1, "Emekli Et", null, null, null, null, null, 4, "_ToRetire", "AssetAction", 3 },
                    { 15, "Yorum Ekle", null, null, null, null, null, 8, "_AddComment", "AssetAction", 1 },
                    { 14, "Zimmet Ata", null, null, null, null, null, 2, "_ToOwner", "AssetAction", 1 },
                    { 13, "Kayıp/Çalıntı Bildir", null, null, null, null, null, 6, "_ReportOfLostOrStolen", "AssetAction", 1 },
                    { 12, "Emekli Et", null, null, null, null, null, 4, "_ToRetire", "AssetAction", 1 },
                    { 10, "Kayıp/Çalıntı Bildir", null, null, null, null, null, 6, "_ReportOfLostOrStolen", "AssetAction", 2 },
                    { 9, "Emekli Et", null, null, null, null, null, 4, "_ToRetire", "AssetAction", 2 },
                    { 11, "Yorum Ekle", null, null, null, null, null, 8, "_AddComment", "AssetAction", 2 },
                    { 7, "Zimmet Ata", null, null, null, null, null, 2, "_ToOwner", "AssetAction", 2 },
                    { 6, "Depoya At", null, null, null, null, null, 6, "_PutInStorage", "AssetAction", 2 },
                    { 5, "Yorum Ekle", null, null, null, null, null, 8, "_AddComment", "AssetAction", 3 },
                    { 4, "İade Et", null, null, null, null, null, 7, "_ToReturn", "AssetAction", 3 },
                    { 3, "Kayıp/Çalıntı Bildir", null, null, null, null, null, 5, "_ReportOfLostOrStolen", "AssetAction", 3 },
                    { 2, "İptal Et", null, null, null, null, null, 5, "_ToCancel", "AssetAction", 3 },
                    { 8, "Tüket", null, null, null, null, null, 3, "_ToConsume", "AssetAction", 2 }
                });

            migrationBuilder.InsertData(
                table: "SystemLists",
                columns: new[] { "ID", "Code", "Description", "Detail", "IsActive", "OperationAction", "OperationController", "Project" },
                values: new object[,]
                {
                    { 5, "Product_Asset_Company", "Üretici (2)", "", true, "", "", "Zimmet" },
                    { 1, "Product_Asset_ProductGroup", "Ürün Grubu (1)", "", true, "Index", "Admin/AssetGroup", "Zimmet" },
                    { 2, "Product_Asset_Brand", "Marka", "", true, "Index", "Admin/Brand", "Zimmet" },
                    { 3, "Product_Asset_Model", "Model (3)", "", true, "Index", "Admin/Model", "Zimmet" },
                    { 4, "Product_Asset_AssetType", "Zimmet Modülü Zimmet Türü", "", true, "", "", "Zimmet" },
                    { 6, "ProductCostCurrency", "Zimmet Modülü Ürünün Para Birimi Listesi", "", true, null, null, "Zimmet" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActionStatus_StatusID",
                table: "ActionStatus",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_AssetBrandID",
                table: "Asset",
                column: "AssetBrandID");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_AssetGroupID",
                table: "Asset",
                column: "AssetGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_AssetModelID",
                table: "Asset",
                column: "AssetModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_AssetTypeID",
                table: "Asset",
                column: "AssetTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_CompanyID",
                table: "Asset",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_CurrencyID",
                table: "Asset",
                column: "CurrencyID");

            migrationBuilder.CreateIndex(
                name: "IX_AssetBarcode_AssetID",
                table: "AssetBarcode",
                column: "AssetID");

            migrationBuilder.CreateIndex(
                name: "IX_AssetBrand_AssetTypeID",
                table: "AssetBrand",
                column: "AssetTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_AssetCustomer_AssetID",
                table: "AssetCustomer",
                column: "AssetID");

            migrationBuilder.CreateIndex(
                name: "IX_AssetCustomer_CustomerID",
                table: "AssetCustomer",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_AssetDocument_AssetID",
                table: "AssetDocument",
                column: "AssetID");

            migrationBuilder.CreateIndex(
                name: "IX_AssetModel_AssetBrandID",
                table: "AssetModel",
                column: "AssetBrandID");

            migrationBuilder.CreateIndex(
                name: "IX_AssetOwner_AssetID",
                table: "AssetOwner",
                column: "AssetID");

            migrationBuilder.CreateIndex(
                name: "IX_AssetOwner_OwnerTypeID",
                table: "AssetOwner",
                column: "OwnerTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_AssetOwner_PersonnelID",
                table: "AssetOwner",
                column: "PersonnelID");

            migrationBuilder.CreateIndex(
                name: "IX_AssetPrice_AssetID",
                table: "AssetPrice",
                column: "AssetID");

            migrationBuilder.CreateIndex(
                name: "IX_AssetPrice_CurrencyID",
                table: "AssetPrice",
                column: "CurrencyID");

            migrationBuilder.CreateIndex(
                name: "IX_AssetStatus_AssetID",
                table: "AssetStatus",
                column: "AssetID");

            migrationBuilder.CreateIndex(
                name: "IX_AssetStatus_PersonnelID",
                table: "AssetStatus",
                column: "PersonnelID");

            migrationBuilder.CreateIndex(
                name: "IX_AssetStatus_StatusID",
                table: "AssetStatus",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_AssetWithoutBarcode_AssetID",
                table: "AssetWithoutBarcode",
                column: "AssetID");

            migrationBuilder.CreateIndex(
                name: "IX_AssetWithoutBarcode_UnitID",
                table: "AssetWithoutBarcode",
                column: "UnitID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_AssetID",
                table: "Comment",
                column: "AssetID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_PersonnelID",
                table: "Comment",
                column: "PersonnelID");

            migrationBuilder.CreateIndex(
                name: "IX_Communication_CommTypeID",
                table: "Communication",
                column: "CommTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Communication_PersonnelID",
                table: "Communication",
                column: "PersonnelID");

            migrationBuilder.CreateIndex(
                name: "IX_PageClaim_PageID",
                table: "PageClaim",
                column: "PageID");

            migrationBuilder.CreateIndex(
                name: "IX_PageClaim_RoleID",
                table: "PageClaim",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_PageClaimDetail_PageClaimID",
                table: "PageClaimDetail",
                column: "PageClaimID");

            migrationBuilder.CreateIndex(
                name: "IX_PageClaimDetail_PageID",
                table: "PageClaimDetail",
                column: "PageID");

            migrationBuilder.CreateIndex(
                name: "IX_PageClaimDetail_RoleID",
                table: "PageClaimDetail",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Personnel_CompanyID",
                table: "Personnel",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonnelLoginInfo_LoginInfoID",
                table: "PersonnelLoginInfo",
                column: "LoginInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonnelLoginInfo_PersonnelID",
                table: "PersonnelLoginInfo",
                column: "PersonnelID");

            migrationBuilder.CreateIndex(
                name: "IX_RolePersonnel_PersonnelID",
                table: "RolePersonnel",
                column: "PersonnelID");

            migrationBuilder.CreateIndex(
                name: "IX_RolePersonnel_RoleID",
                table: "RolePersonnel",
                column: "RoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionStatus");

            migrationBuilder.DropTable(
                name: "AssetBarcode");

            migrationBuilder.DropTable(
                name: "AssetCustomer");

            migrationBuilder.DropTable(
                name: "AssetDocument");

            migrationBuilder.DropTable(
                name: "AssetOwner");

            migrationBuilder.DropTable(
                name: "AssetPrice");

            migrationBuilder.DropTable(
                name: "AssetStatus");

            migrationBuilder.DropTable(
                name: "AssetWithoutBarcode");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Communication");

            migrationBuilder.DropTable(
                name: "PageClaimDetail");

            migrationBuilder.DropTable(
                name: "PersonnelAssetList",
                schema: "sp_PersonnelAssetList");

            migrationBuilder.DropTable(
                name: "PersonnelLoginInfo");

            migrationBuilder.DropTable(
                name: "RolePersonnel");

            migrationBuilder.DropTable(
                name: "SystemLists");

            migrationBuilder.DropTable(
                name: "TeamAssetList",
                schema: "sp_TeamAssetList");

            migrationBuilder.DropTable(
                name: "WarehouseAllAssetList",
                schema: "sp_WarehouseAllAssetList");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "OwnerType");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Unit");

            migrationBuilder.DropTable(
                name: "Asset");

            migrationBuilder.DropTable(
                name: "CommType");

            migrationBuilder.DropTable(
                name: "PageClaim");

            migrationBuilder.DropTable(
                name: "LoginInfo");

            migrationBuilder.DropTable(
                name: "Personnel");

            migrationBuilder.DropTable(
                name: "AssetGroup");

            migrationBuilder.DropTable(
                name: "AssetModel");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "Page");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "AssetBrand");

            migrationBuilder.DropTable(
                name: "AssetType");
        }
    }
}
