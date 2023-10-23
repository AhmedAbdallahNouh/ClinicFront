using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicModels.DTOs.ConsultationDTO
{
    public class UpdateConsultationdto : BaseConsultationDTO
    {
        public string? Answer { get; set; }
    }
}
