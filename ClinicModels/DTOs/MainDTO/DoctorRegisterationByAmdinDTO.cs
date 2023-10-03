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

        [DataType(DataType.Date)]
        public DateTime? StartSubscriptionDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EndSubscriptionDate { get; set; }
    }
}
