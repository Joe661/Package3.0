using PackageAccountant3._0.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PackageAccountant3._0.Service
{
    public interface IUserInfoBll
    {
         Task<UserInfo> GetUserInfoAsync(string username);
         Task<bool> CheckUserInfoAsync(string username);
         Task<bool> SetUserSessionAsync(string username);
    }
}
