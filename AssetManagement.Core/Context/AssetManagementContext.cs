using AssetManagement.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.Core.Context
{
    public class AssetManagementContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=DESKTOP-47MR3VQ;Database=AssetManagement;integrated security=True;MultipleActiveResultSets=True;");
        }

        public DbSet<ActionStatus> ActionStatus { get; set; }
        public DbSet<Asset> Asset { get; set; }
        public DbSet<AssetAction> AssetAction { get; set; }
        public DbSet<AssetBarcode> AssetBarcode { get; set; }
        public DbSet<AssetCustomer> AssetCustomer { get; set; }
        public DbSet<AssetOwner> AssetOwner { get; set; }
        public DbSet<AssetStatus> AssetStatus { get; set; }
        public DbSet<AssetType> AssetType { get; set; }
        public DbSet<AssetWithoutBarcode> AssetWithoutBarcode { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<CommType> CommType { get; set; }
        public DbSet<Communication> Communication { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Document> Document { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<MasterDetail> MasterDetail { get; set; }
        public DbSet<OwnerType> OwnerType { get; set; }
        public DbSet<Page> Page { get; set; }
        public DbSet<PageClaim> PageClaim { get; set; }
        public DbSet<PageClaimDetail> PageClaimDetail { get; set; }
        public DbSet<Personnel> Personnel { get; set; }
        public DbSet<PersonnelLoginInfo> PersonnelLoginInfo { get; set; }
        public DbSet<PersonnelTeam> PersonnelTeam { get; set; }
        public DbSet<Price> Price { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<RolePersonnel> RolePersonnel { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<Unit> Unit { get; set; }
    }
}
