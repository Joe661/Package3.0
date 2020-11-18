using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using PackageAccountant3._0.Model;
using PackageAccountant3._0.Service;

namespace PackageAccountant3._0.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserInfoBll _userInfo;
        private readonly IMapper _mapper;

        public UserController(IUserInfoBll userInfo, IMapper mapper)
        {
            _userInfo = userInfo ?? throw new ArgumentNullException(nameof(userInfo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet(template: "{userName}")]
        public async Task<ActionResult<UserInfoDto>> GetUserInfo(string userName)
        {
            var user = await _userInfo.GetUserInfoAsync(userName);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<UserInfoDto>(user));
        }
    }
}
