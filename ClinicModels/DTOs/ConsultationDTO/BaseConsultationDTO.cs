using ClinicModels.DTOs.ConsultationImageDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicModels.DTOs.ConsultationDTO
{
    public class BaseConsultationDTO
    {
        public int Id { get; set; }
        [Required]
        public string Question { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public List<ConsulationImageDTO>? consultationImageDTOs { get; set; } = new List<ConsulationImageDTO>();
        public DoctorDTO.DoctorDTO? DoctorDTO { get; set; } 

    }
}
