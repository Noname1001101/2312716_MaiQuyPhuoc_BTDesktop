using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab07_Entity_Framework.Models
{
    public class RestaurantContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleAccount> RoleAccounts { get; set; }
        public DbSet<DiningTable> Tables { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillDetails> BillDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // 1. Quan hệ Food - Category (của bạn đã có)
            modelBuilder.Entity<Food>()
                .HasRequired(x => x.Category)
                .WithMany()
                .HasForeignKey(x => x.FoodCategoryId)
                .WillCascadeOnDelete(true);

            // 2. Quan hệ Role - Account
            modelBuilder.Entity<RoleAccount>()
                .HasKey(ra => new { ra.RoleID, ra.AccountName });

            modelBuilder.Entity<RoleAccount>()
                .HasRequired(ra => ra.Role)
                .WithMany(r => r.RoleAccounts)
                .HasForeignKey(ra => ra.RoleID);

            modelBuilder.Entity<RoleAccount>()
                .HasRequired(ra => ra.Account)
                .WithMany(a => a.RoleAccounts)
                .HasForeignKey(ra => ra.AccountName);

            // 3. (PHẦN SỬA LỖI) Chỉ định tên bảng CHÍNH XÁC
            // Ép EF dùng đúng tên bảng "Table" cho class "DiningTable"
            modelBuilder.Entity<DiningTable>()
                .ToTable("Table");

            // Chỉ định tên bảng "Bill"
            modelBuilder.Entity<Bill>()
                .ToTable("Bills");

            // Chỉ định tên bảng "BillDetails"
            modelBuilder.Entity<BillDetails>()
                .ToTable("BillDetails");
        }
    }
}