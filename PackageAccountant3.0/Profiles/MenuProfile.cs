﻿using AutoMapper;
using PackageAccountant3._0.Entities;
using PackageAccountant3._0.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PackageAccountant3._0.Profiles
{
    public class MenuProfile:Profile
    {
        public MenuProfile()
        {
            CreateMap<Menu, MenuDto>();
        }
    }
}
