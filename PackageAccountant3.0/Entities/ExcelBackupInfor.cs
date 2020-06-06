using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PackageAccountant3._0.Entities
{
    public class ExcelBackupInfor
    {
        public string UserId { get; set; }
        public DateTime backupdate { get; set; }
        public string backuppath { get; set; }
        public string size { get; set; }
        [Key]
        public int id { get; set; }
    }
}
