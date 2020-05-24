using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PackageAccountant3._0.Model
{
    public class IncomeExpenseDetailsDto
    {
        public DateTime PTime { get; set; }
        public string PType { get; set; }
        public decimal Amount { get; set; }
        public string Comments { get; set; }
    }
}
