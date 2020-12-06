using PackageAccountant3._0.Data;
using PackageAccountant3._0.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PackageAccountant3._0.Service
{
    public class ExcelBackupInofBll : IExcelBackupInofBll
    {
        public readonly EFPackageDbContext _context;
        public ExcelBackupInofBll(EFPackageDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void Insert(ExcelBackupInfor entity)
        {
            _context.ExcelBackupInfor.Add(entity);
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
