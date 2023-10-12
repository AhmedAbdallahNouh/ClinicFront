using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicModels.DTOs.MainDTO
{
    public class RegiterationPasswordUserName
    {
        public string? Id { get; set; }

        [Required(ErrorMessage = "إسم المستخدم  إلزامى")]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "كلمة المرور إلزامية")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "تأكيد كلمة المرور إلزامية")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "تأكيد كلمة المرور وكلمة المرور لا يتطابقان")]
        public string ConfirmPassword { get; set; }
    }
}
