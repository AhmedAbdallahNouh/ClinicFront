using ClinicModels.DTOs.ConsultationImageDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicModels.DTOs.ConsultationDTO
{
    public class CnosultationDTO : BaseConsultationDTO
    {
        
        public string? Answer { get; set; }                        
        public CategoryDTO? categoryDTO { get; set; } = new CategoryDTO();
        public  List<ConsulationImageDTO> consultationImageDTOs { get; set; } = new List<ConsulationImageDTO>(); //4


    }
}
