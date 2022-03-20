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

        public DbSet<LoginInfo> LoginInfo { get; set; }
    }
}
