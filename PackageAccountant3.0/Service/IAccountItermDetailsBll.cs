using PackageAccountant3._0.Entities;
using PackageAccountant3._0.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PackageAccountant3._0.Service
{
    public interface IAccountItermDetailsBll
    {
        Task<List<AccountItermDetails>> GetAccountItermDetailsAsyn();
        void AddAccountItermDetails(AccountItermDetails addDto);
        Task<bool> SaveAsync();
    }
}
