using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PackageAccountant3._0.Helper
{
    public interface IOfficeHelper
    {
        DataTable ReadExcelToDataTable(string fileName, string sheetName = null, bool isFirstRowColumn = true);
    }
}
