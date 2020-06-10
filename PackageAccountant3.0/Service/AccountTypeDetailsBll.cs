using Microsoft.EntityFrameworkCore;
using PackageAccountant3._0.Data;
using PackageAccountant3._0.Entities;
using PackageAccountant3._0.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PackageAccountant3._0.Service
{
    public class AccountTypeDetailsBll : IAccountTypeDetailsBll
    {
        public readonly EFPackageDbContext _context;
        public AccountTypeDetailsBll(EFPackageDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<List<AccountTypeDetails>> AccountTypeDetailsAsync()
        {
            var list = _context.AccountTypeDetails;
            return await list.ToListAsync();
        }

        public void AddAccountTypeDetails(AccountTypeDetails details)
        {
            if(details == null)
                throw new ArgumentNullException(nameof(details));

            _context.AccountTypeDetails.Add(details);
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
