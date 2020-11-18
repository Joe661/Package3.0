using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PackageAccountant3._0.Data;
using PackageAccountant3._0.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<UserInfo> GetUserInfoAsync(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentNullException();
            }

            return await _context.UserInfo.FirstOrDefaultAsync(p => p.UserName == username);
        }

        public async Task<bool> CheckUserInfoAsync(string username)
        {
            UserInfo info = await GetUserInfoAsync(username);
            if (info == null)
                return false;
            else
                return true;

        }

        public async Task<bool> SetUserSessionAsync(string username)
        {
            var user = await GetUserInfoAsync(username);
            var result = await CheckUserInfoAsync(username);
            if (result)
            {
                _session.SetString("username",username);
            }
            return result;
        }
    }
}
