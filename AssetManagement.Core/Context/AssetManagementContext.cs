﻿using AssetManagement.Core.Entity;
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
                       Project = "Zimmet",
                       Code = "Product_Asset_AssetType",
                       Description = "Zimmet Modülü Zimmet Türü",
                       Detail = "",
                       IsActive = true
                   },
                   new SystemLists()
                   {
                       Project = "Zimmet",
                       Code = "Product_Asset_Company",
                       Description = "Üretici (2)",
                       Detail = "",
                       IsActive = true
                   },
                   new SystemLists()
                   {
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
                      StatusID = 3,
                      StatusActionID = 4,
                      StatusController = "AssetAction",
                      StatusActionMetod = "_ToRetire",
                      ActionText = "Emekli Et",
                  },
                      new ActionStatus()
                      {
                          StatusID = 3,
                          StatusActionID = 5,
                          StatusController = "AssetAction",
                          StatusActionMetod = "_ToCancel",
                          ActionText = "İptal Et",
                      },
                          new ActionStatus()
                          {
                              StatusID = 3,
                              StatusActionID = 5,
                              StatusController = "AssetAction",
                              StatusActionMetod = "_ReportOfLostOrStolen",
                              ActionText = "Kayıp/Çalıntı Bildir",
                          },
                              new ActionStatus()
                              {
                                  StatusID = 3,
                                  StatusActionID = 7,
                                  StatusController = "AssetAction",
                                  StatusActionMetod = "_ToReturn",
                                  ActionText = "İade Et",
                              },
                                  new ActionStatus()
                                  {
                                      StatusID = 3,
                                      StatusActionID = 8,
                                      StatusController = "AssetAction",
                                      StatusActionMetod = "_AddComment",
                                      ActionText = "Yorum Ekle",
                                  },
                  new ActionStatus()
                  {
                      StatusID = 2,
                      StatusActionID = 6,
                      StatusController = "AssetAction",
                      StatusActionMetod = "_PutInStorage",
                      ActionText = "Depoya At",
                  },
                      new ActionStatus()
                      {
                          StatusID = 2,
                          StatusActionID = 2,
                          StatusController = "AssetAction",
                          StatusActionMetod = "_ToOwner",
                          ActionText = "Zimmet Ata",
                      },
                         new ActionStatus()
                         {
                             StatusID = 2,
                             StatusActionID = 3,
                             StatusController = "AssetAction",
                             StatusActionMetod = "_ToConsume",
                             ActionText = "Tüket",
                         },
                           new ActionStatus()
                           {
                               StatusID = 2,
                               StatusActionID = 4,
                               StatusController = "AssetAction",
                               StatusActionMetod = "_ToRetire",
                               ActionText = "Emekli Et",
                           },
                              new ActionStatus()
                              {
                                  StatusID = 2,
                                  StatusActionID = 6,
                                  StatusController = "AssetAction",
                                  StatusActionMetod = "_ReportOfLostOrStolen",
                                  ActionText = "Kayıp/Çalıntı Bildir",
                              },
                               new ActionStatus()
                               {
                                   StatusID = 2,
                                   StatusActionID = 8,
                                   StatusController = "AssetAction",
                                   StatusActionMetod = "_AddComment",
                                   ActionText = "Yorum Ekle",
                               },
                 new ActionStatus()
                 {
                     StatusID = 1,
                     StatusActionID = 4,
                     StatusController = "AssetAction",
                     StatusActionMetod = "_ToRetire",
                     ActionText = "Emekli Et",
                 },
                    new ActionStatus()
                    {
                        StatusID = 1,
                        StatusActionID = 6,
                        StatusController = "AssetAction",
                        StatusActionMetod = "_ReportOfLostOrStolen",
                        ActionText = "Kayıp/Çalıntı Bildir",
                    },
                      new ActionStatus()
                      {
                          StatusID = 1,
                          StatusActionID = 2,
                          StatusController = "AssetAction",
                          StatusActionMetod = "_ToOwner",
                          ActionText = "Zimmet Ata",
                      },
                         new ActionStatus()
                         {
                             StatusID = 1,
                             StatusActionID = 8,
                             StatusController = "AssetAction",
                             StatusActionMetod = "_AddComment",
                             ActionText = "Yorum Ekle",
                         }
                  );
            #endregion

            modelBuilder.Entity<Asset>(x => x.Property(e => e.RegistrationNumber).ValueGeneratedOnAdd());
            base.OnModelCreating(modelBuilder);
        }


        //Burda RegistrationNumber default değer verebilmek için yazmıştım patladı acil Çözüm Bul!!!!!!!!!
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Asset>(x => x.Property(e => e.RegistrationNumber).ValueGeneratedOnAdd());
        //    //entity.Property(u => u.RegistrationNumber).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
