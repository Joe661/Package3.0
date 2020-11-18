using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PackageAccountant3._0.Entities;
using PackageAccountant3._0.Model;
using PackageAccountant3._0.Service;

namespace PackageAccountant3._0.Controllers
{
    [Route("api/menu")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuBll _menu;
        private readonly IMapper _mapper;
        public MenuController(IMenuBll menu,IMapper mapper)
        {
            _menu = menu ?? throw new ArgumentNullException(nameof(menu));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet(Name =nameof(GetMenuasyn))]
        public async Task<ActionResult<List<MenuDto>>> GetMenuasyn()
        {
            var menus=await _menu.GetMenuasyn();
            if (menus == null)
                return NotFound();
            var menusDto = _mapper.Map<List<MenuDto>>(menus);
            return Ok(menusDto);
        }
    }
}
