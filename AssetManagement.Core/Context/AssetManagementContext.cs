using AssetManagement.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.Core.Context
{
    public class AssetManagementContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=DESKTOP-47MR3VQ;Database=AssetManagement;integrated security=True;MultipleActiveResultSets=True;");
        }

        #region Entities
        public DbSet<ActionStatus> ActionStatus { get; set; }
        public DbSet<Asset> Asset { get; set; }
        public DbSet<AssetBarcode> AssetBarcode { get; set; }
        public DbSet<AssetBrand> AssetBrand { get; set; }
        public DbSet<AssetModel> AssetModel { get; set; }
        public DbSet<AssetCustomer> AssetCustomer { get; set; }
        public DbSet<AssetOwner> AssetOwner { get; set; }
        public DbSet<AssetStatus> AssetStatus { get; set; }
        public DbSet<AssetPrice> AssetPrice { get; set; }
        public DbSet<AssetType> AssetType { get; set; }
        public DbSet<AssetWithoutBarcode> AssetWithoutBarcode { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<CommType> CommType { get; set; }
        public DbSet<Communication> Communication { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<AssetDocument> AssetDocument { get; set; }
        public DbSet<AssetGroup> AssetGroup { get; set; }
        public DbSet<OwnerType> OwnerType { get; set; }
        public DbSet<Page> Page { get; set; }
        public DbSet<PageClaim> PageClaim { get; set; }
        public DbSet<PageClaimDetail> PageClaimDetail { get; set; }
        public DbSet<Personnel> Personnel { get; set; }
        public DbSet<PersonnelLoginInfo> PersonnelLoginInfo { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<RolePersonnel> RolePersonnel { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Unit> Unit { get; set; }
        public DbSet<SystemLists> SystemLists { get; set; }
        #endregion


        #region Prosedure
        public DbSet<WarehouseAllAssetList> WarehouseAllAssetList { get; set; }
        public DbSet<PersonnelAssetList> PersonnelAssetList { get; set; }
        public DbSet<TeamAssetList> TeamAssetList { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region SystemLists Seed
            modelBuilder.Entity<SystemLists>().HasData(
                   new SystemLists()
                   {
                       ID = 1,
                       Project = "Zimmet",
                       Code = "Product_Asset_ProductGroup",
                       Description = "Ürün Grubu (1)",
                       Detail = "",
                       OperationController = "Admin/AssetGroup",
                       OperationAction = "Index",
                       IsActive = true
                   },
                   new SystemLists()
                   {
                       ID = 2,
                       Project = "Zimmet",
                       Code = "Product_Asset_Brand",
                       Description = "Marka",
                       Detail = "",
                       OperationController = "Admin/Brand",
                       OperationAction = "Index",
                       IsActive = true
                   },
                   new SystemLists()
                   {
                       ID = 3,
                       Project = "Zimmet",
                       Code = "Product_Asset_Model",
                       Description = "Model (3)",
                       Detail = "",
                       OperationController = "Admin/Model",
                       OperationAction = "Index",
                       IsActive = true
                   },
                   new SystemLists()
                   {
                       ID = 4,
                       Project = "Zimmet",
                       Code = "Product_Asset_AssetType",
                       Description = "Zimmet Modülü Zimmet Türü",
                       Detail = "",
                       OperationController = "",
                       OperationAction = "",
                       IsActive = true
                   },
                   new SystemLists()
                   {
                       ID = 5,
                       Project = "Zimmet",
                       Code = "Product_Asset_Company",
                       Description = "Üretici (2)",
                       Detail = "",
                       OperationController = "",
                       OperationAction = "",
                       IsActive = true
                   },
                   new SystemLists()
                   {
                       ID = 6,
                       Project = "Zimmet",
                       Code = "ProductCostCurrency",
                       Description = "Zimmet Modülü Ürünün Para Birimi Listesi",
                       Detail = "",
                       IsActive = true
                   }
               );
            #endregion

            #region ActionStatus Seed
            modelBuilder.Entity<ActionStatus>().HasData(
                  new ActionStatus()
                  {
                      ID = 1,
                      StatusID = 3,
                      StatusActionID = 4,
                      StatusController = "AssetAction",
                      StatusActionMetod = "_ToRetire",
                      ActionText = "Emekli Et",
                  },
                      new ActionStatus()
                      {
                          ID = 2,
                          StatusID = 3,
                          StatusActionID = 5,
                          StatusController = "AssetAction",
                          StatusActionMetod = "_ToCancel",
                          ActionText = "İptal Et",
                      },
                          new ActionStatus()
                          {
                              ID = 3,
                              StatusID = 3,
                              StatusActionID = 5,
                              StatusController = "AssetAction",
                              StatusActionMetod = "_ReportOfLostOrStolen",
                              ActionText = "Kayıp/Çalıntı Bildir",
                          },
                              new ActionStatus()
                              {
                                  ID = 4,
                                  StatusID = 3,
                                  StatusActionID = 7,
                                  StatusController = "AssetAction",
                                  StatusActionMetod = "_ToReturn",
                                  ActionText = "İade Et",
                              },
                                  new ActionStatus()
                                  {
                                      ID = 5,
                                      StatusID = 3,
                                      StatusActionID = 8,
                                      StatusController = "AssetAction",
                                      StatusActionMetod = "_AddComment",
                                      ActionText = "Yorum Ekle",
                                  },
                  new ActionStatus()
                  {
                      ID = 6,
                      StatusID = 2,
                      StatusActionID = 6,
                      StatusController = "AssetAction",
                      StatusActionMetod = "_PutInStorage",
                      ActionText = "Depoya At",
                  },
                      new ActionStatus()
                      {
                          ID = 7,
                          StatusID = 2,
                          StatusActionID = 2,
                          StatusController = "AssetAction",
                          StatusActionMetod = "_ToOwner",
                          ActionText = "Zimmet Ata",
                      },
                         new ActionStatus()
                         {
                             ID = 8,
                             StatusID = 2,
                             StatusActionID = 3,
                             StatusController = "AssetAction",
                             StatusActionMetod = "_ToConsume",
                             ActionText = "Tüket",
                         },
                           new ActionStatus()
                           {
                               ID = 9,
                               StatusID = 2,
                               StatusActionID = 4,
                               StatusController = "AssetAction",
                               StatusActionMetod = "_ToRetire",
                               ActionText = "Emekli Et",
                           },
                              new ActionStatus()
                              {
                                  ID = 10,
                                  StatusID = 2,
                                  StatusActionID = 6,
                                  StatusController = "AssetAction",
                                  StatusActionMetod = "_ReportOfLostOrStolen",
                                  ActionText = "Kayıp/Çalıntı Bildir",
                              },
                               new ActionStatus()
                               {
                                   ID = 11,
                                   StatusID = 2,
                                   StatusActionID = 8,
                                   StatusController = "AssetAction",
                                   StatusActionMetod = "_AddComment",
                                   ActionText = "Yorum Ekle",
                               },
                 new ActionStatus()
                 {
                     ID = 12,
                     StatusID = 1,
                     StatusActionID = 4,
                     StatusController = "AssetAction",
                     StatusActionMetod = "_ToRetire",
                     ActionText = "Emekli Et",
                 },
                    new ActionStatus()
                    {
                        ID = 13,
                        StatusID = 1,
                        StatusActionID = 6,
                        StatusController = "AssetAction",
                        StatusActionMetod = "_ReportOfLostOrStolen",
                        ActionText = "Kayıp/Çalıntı Bildir",
                    },
                      new ActionStatus()
                      {
                          ID = 14,
                          StatusID = 1,
                          StatusActionID = 2,
                          StatusController = "AssetAction",
                          StatusActionMetod = "_ToOwner",
                          ActionText = "Zimmet Ata",
                      },
                         new ActionStatus()
                         {
                             ID = 15,
                             StatusID = 1,
                             StatusActionID = 8,
                             StatusController = "AssetAction",
                             StatusActionMetod = "_AddComment",
                             ActionText = "Yorum Ekle",
                         }
                  );
            #endregion

            //registrationNumber default deger alsın artsın artsın diye yazmıştım patladı bak!!!
            //modelBuilder.Entity<Asset>(x => x.Property(e => e.RegistrationNumber).ValueGeneratedOnAdd());
            base.OnModelCreating(modelBuilder);
        }


    }
}
