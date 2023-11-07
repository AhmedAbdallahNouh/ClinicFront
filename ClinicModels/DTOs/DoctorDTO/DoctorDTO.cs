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
        public DateTime? StartSubscriptionDate { get; set; }
        public DateTime? EndSubscriptionDate { get; set; }
        public DateTime? VisitedDoctorPage { get; set; }
        public string? CoverImage { get; set; }
        public string? UserName { get; set; }
        public int Delete_Doctor { get; set; }
        public int? AdvertisementFlag { get; set; }

        public DoctorDTO()
        {

        }
        public DoctorDTO(string id, string? firstName, string? lastName, int? age, string? phoneNumber, string? address, int? locationLate, int? LocationLong,
                        string? facebook, string? instgram, string? whatsUpNumber, DateTime? StartSubscriptionDate, DateTime? EndSubscriptionDate, int Delete_Doctor, string? Image, string? CoverImage, int? advertisementFlag,DateTime? VisitedDoctorPage, string? userName, string? discription, string? Email)
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
            this.Discription = discription;
            this.Email = Email;
            this.WhatsUpNumber = whatsUpNumber;
            this.StartSubscriptionDate = StartSubscriptionDate;
            this.EndSubscriptionDate = EndSubscriptionDate;
            this.Delete_Doctor = Delete_Doctor;
            this.Image = Image;
            this.CoverImage = CoverImage;
            this.AdvertisementFlag = advertisementFlag;
            this.VisitedDoctorPage = VisitedDoctorPage;
            this.UserName = userName;
        }
        public int? CategoryId { get; set; }
        public CategoryDTO? categoryDTO { get; set; } = new CategoryDTO();
        public List<ServiceDTO>? doctorServiceDTOs { get; set; } = new List<ServiceDTO>();
    }
}
