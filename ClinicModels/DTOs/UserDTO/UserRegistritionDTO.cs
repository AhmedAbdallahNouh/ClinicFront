using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicModels.DTOs.UserDTO
{
    public class UserRegistritionDTO
    {
        public string? Id { get; set; }

        [Required(ErrorMessage = "يجب ادخال الأسم الأول")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "يجب ادخال الأسم الأخير")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "يجب ادخال صورة")]
        public string Image { get; set; }

        public int? Age { get; set; }

        [Required(ErrorMessage = "يجب ادخال الايميل")]
        [EmailAddress(ErrorMessage = "عنوان البريد الإلكتروني غير صحيح")] 
        public string? Username { get; set; }

        [Required(ErrorMessage = "يجب ادخال الباسورد")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "تأكيد الباسورد لا يساوى الباسورد")]
        public string ConfirmPassword { get; set; }
    }
}

