using ClinicModels.DTOs.DoctorDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicModels.DTOs.DoctorServiceDTO
{
    public class ServiceForSpecificDto : DoctorDTO.DoctorDTO
    {
        public List<ServiceDTO> serviceDTO { get; set; }
    }
}
