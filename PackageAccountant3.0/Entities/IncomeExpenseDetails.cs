﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PackageAccountant3._0.Entities
{
    public class IncomeExpenseDetails
    {
        public DateTime PTime { get; set; }
        public string PType { get; set; }
        public int AccountItermId { get; set; }
        public decimal Amount { get; set; }
        public int AccountTypeId { get; set; }
        public string Comments { get; set; }
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
    }
}
