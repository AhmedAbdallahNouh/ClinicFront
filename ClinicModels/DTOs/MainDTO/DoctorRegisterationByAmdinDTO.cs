using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicModels.DTOs.MainDTO
{
    public class DoctorRegisterationByAmdinDTO : RegiterationPasswordUserName
    {
        [Required(ErrorMessage = "يجب إختيار قسم")]
        public int CategoryId { get; set; }
        //[DataType(DataType.Date)]
        [Required(ErrorMessage = "يجب إدخال تاريخ بداية الإشتراك")]
        public DateTime? StartSubscriptionDate { get; set; }

        [Required(ErrorMessage = "يجب إدخال تاريخ نهاية الإشتراك")]
        public DateTime? EndSubscriptionDate { get; set; }


    }
}
