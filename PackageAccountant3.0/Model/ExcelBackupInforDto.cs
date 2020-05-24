using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PackageAccountant3._0.Model
{
    public class ExcelBackupInforDto
    {
        public DateTime backupdate { get; set; }
        public string backuppath { get; set; }
        public string size { get; set; }
    }
}
