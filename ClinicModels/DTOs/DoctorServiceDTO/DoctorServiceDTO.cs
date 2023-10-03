using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicModels.DTOs.DoctorServiceDTO
{
    public class DoctorServiceDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Discription { get; set; }
        public string? Image { get; set; }
        public string? DoctorId { get; set; }
    }
}
