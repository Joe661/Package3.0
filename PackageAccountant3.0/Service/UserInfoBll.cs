using Microsoft.AspNetCore.Http;
using PackageAccountant3._0.Data;
using PackageAccountant3._0.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PackageAccountant3._0.Service
{
    public class UserInfoBll:IUserInfoBll
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public readonly EFPackageDbContext _context;
        public UserInfoBll(EFPackageDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<UserInfo> GetUserInfo(string username)
        {
            try
            {
                return new UserInfo();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> CheckUserInfo(string username)
        {
            UserInfo info = await GetUserInfo(username);
            if (info == null)
                return false;
            else
                return true;

        }

        public async Task<bool> SetUserSession(string username)
        {
            var user = await GetUserInfo(username);
            var result = await CheckUserInfo(username);
            if (result)
            {
                _session.SetString("username",username);
            }
            return result;
        }
    }
}
