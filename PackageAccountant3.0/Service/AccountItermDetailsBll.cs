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
    public class AccountItermDetailsBll : IAccountItermDetailsBll
    {
        public readonly EFPackageDbContext _context;
        public AccountItermDetailsBll(EFPackageDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void AddAccountItermDetails(AccountItermDetails details)
        {
            if (details == null)
            {
                throw new ArgumentNullException(nameof(details));
            }

            _context.AccountItermDetails.Add(details);
        }

        public async Task<List<AccountItermDetails>> GetAccountItermDetailsAsyn()
        {
            var result = _context.AccountItermDetails;

            return await result.ToListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
