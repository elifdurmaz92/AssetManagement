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

        public virtual DbSet<ActionStatus> ActionStatus { get; set; }
        public virtual DbSet<Asset> Asset { get; set; }
        public virtual DbSet<AssetAction> AssetAction { get; set; }
        public virtual DbSet<AssetBarcode> AssetBarcode { get; set; }
        public virtual DbSet<AssetCustomer> AssetCustomer { get; set; }
        public virtual DbSet<AssetOwner> AssetOwner { get; set; }
        public virtual DbSet<AssetStatus> AssetStatus { get; set; }
        public virtual DbSet<AssetType> AssetType { get; set; }
        public virtual DbSet<AssetWithoutBarcode> AssetWithoutBarcode { get; set; }
        public virtual DbSet<Claim> Claim { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<CommType> CommType { get; set; }
        public virtual DbSet<Communication> Communication { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Currency> Currency { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<LoginInfo> LoginInfo { get; set; }
        public virtual DbSet<MasterDetail> MasterDetail { get; set; }
        public virtual DbSet<OwnerType> OwnerType { get; set; }
        public virtual DbSet<Page> Page { get; set; }
        public virtual DbSet<PageClaim> PageClaim { get; set; }
        public virtual DbSet<Personnel> Personnel { get; set; }
        public virtual DbSet<PersonnelLoginInfo> PersonnelLoginInfo { get; set; }
        public virtual DbSet<PersonnelTeam> PersonnelTeam { get; set; }
        public virtual DbSet<Price> Price { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RolePersonnel> RolePersonnel { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Team> Team { get; set; }
        public virtual DbSet<Unit> Unit { get; set; }
    }
}
