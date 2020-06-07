using Microsoft.EntityFrameworkCore;
using PackageAccountant3._0.Data;
using PackageAccountant3._0.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PackageAccountant3._0.Service
{
    public class MenuBll : IMenuBll
    {
        public readonly EFPackageDbContext _context;
        public MenuBll(EFPackageDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<List<Menu>> GetMenuasyn()
        {
            var list = _context.Menu;
            return await list.ToListAsync();
        }
    }
}
