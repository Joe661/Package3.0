using PackageAccountant3._0.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PackageAccountant3._0.Service
{
    public interface IUserInfoBll
    {
         Task<UserInfo> GetUserInfo(string username);
         Task<bool>  CheckUserInfo(string username);
         Task<bool> SetUserSession(string username);
    }
}
