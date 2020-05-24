using Microsoft.EntityFrameworkCore;
using PackageAccountant3._0.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PackageAccountant3._0.Data
{
    public class EFPackageDbContext: DbContext
    {
        public EFPackageDbContext(DbContextOptions<EFPackageDbContext> options) : base(options) { }

        public DbSet<AccountItermDetails> AccountItermDetails { get; set; }

        public DbSet<ExcelBackupInfor> ExcelBackupInfor { get; set; }

        public DbSet<UserInfo> UserInfo { get; set; }

        public DbSet<Menu> Menu { get; set; }

        public DbSet<IncomeExpenseDetails> IncomeExpenseDetails { get; set; }

        public DbSet<AccountTypeDetails> AccountTypeDetails { get; set; }

    }
}
