using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PackageAccountant3._0.Entities
{
    public class Menu
    {
        [Key]
        public int MenuId { get; set; }
       public int ParentMenuId { get; set; }
        public string MenuName { get; set; }
        public string Herf { get; set; }
    }
}
