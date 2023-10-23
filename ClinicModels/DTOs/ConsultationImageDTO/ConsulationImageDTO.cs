using ClinicModels.DTOs.ConsultationDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicModels.DTOs.ConsultationImageDTO
{
    public class ConsulationImageDTO
    {
        public int Id { get; set; }
        public string Image { get; set; }

        public int ConsultationId { get; set; }
        //public CnosultationDTO? cnosultationDTO { get; set; } = new CnosultationDTO();
        
    }
}
