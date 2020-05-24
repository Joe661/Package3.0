using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PackageAccountant3._0.Entities
{
    public class UserInfo
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        [Key]
        public int UserId { get; set; }
    }
}
