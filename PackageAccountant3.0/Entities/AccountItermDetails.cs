using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PackageAccountant3._0.Entities
{
    public class AccountItermDetails
    {
        [Key]
        public int AccountItermId { get; set; }

        public string AccountIterm { get; set; }
        public string UserId { get; set; }
    }
}
