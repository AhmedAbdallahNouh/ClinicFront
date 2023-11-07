using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ClinicModels.DTOs.DoctorServiceDTO
{
    public class ServiceDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "يجب إدخال عنوان")]
        public string Title { get; set; }
        public string? Discription { get; set; }
        public string? Image { get; set; }
        public string? DoctorId { get; set; }
        [Required(ErrorMessage = "يجب إدخال تخصص")]
        public int Category_Id { get; set; }
        public string? Category_Name { get; set; }
        public List<ClinicModels.DTOs.DoctorDTO.DoctorDTO> doctorDTOs { get; set; } = new List<DoctorDTO.DoctorDTO>();
    }
}
