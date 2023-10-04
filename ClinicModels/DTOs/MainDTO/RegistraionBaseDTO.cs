using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicModels.DTOs.MainDTO
{
    public class RegistraionBaseDTO
    {
        public string? Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        public int? Age { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        //[RegularExpression("^01[0125][0-9]{8}$")]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
