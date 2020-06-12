using System.ComponentModel.DataAnnotations;

namespace PackageAccountant3._0.Model
{
    public class AccountTypeDetailsAddDto
    {
        [Required(ErrorMessage = "{0}这个字段是必填的")]
        public string AccountType { get; set; }
        [Required(ErrorMessage = "{0}这个字段是必填的")]
        public string UserId { get; set; }
    }
}
