using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PackageAccountant3._0.Model
{
    public class AccountItermDetailsAddDto
    {
        [Required(ErrorMessage = "{0}这个字段是必填的")]
        public string AccountIterm { get; set; }
        [Required(ErrorMessage = "{0}这个字段是必填的")]
        public string UserId { get; set; }
    }
}
