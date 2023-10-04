using ClinicModels.DTOs.DoctorServiceDTO;
using ClinicModels.DTOs.MainDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicModels.DTOs.DoctorDTO
{
    public class DoctorDTO : DoctorUpdatingProfileDTO
    {
        public DoctorDTO()
        {
            
        }
        public DoctorDTO(string id, string firstName, string lastName, int? age, string phoneNumber, string address, int? locationLate, int? LocationLong, string facebook, string instgram, int? whatsUpNumber)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.PhoneNumber = phoneNumber;
            this.Address = address;
            this.LocationLat = locationLate;
            this.LocationLong = LocationLong;
            this.FaceBook = facebook;
            this.Instgram = instgram;
            this.WhatsUpNumber = whatsUpNumber;
        }
        public CategoryDTO categoryDTO { get; set; }  = new CategoryDTO();
        public List<DoctorServiceDTO.DoctorServiceDTO> doctorServiceDTOs { get; set; } = new List<DoctorServiceDTO.DoctorServiceDTO>();
    }
}
