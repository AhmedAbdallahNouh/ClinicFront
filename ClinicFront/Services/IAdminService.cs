using ClinicModels.DTOs.DoctorDTO;
using ClinicModels.DTOs.MainDTO;
using ClinicModels.DTOs.UserDTO;

namespace ClinicFront.Services
{
    public interface IAdminService
    {
        Task<HttpResponseMessage> AddUser(UserRegistritionDTO userRegistritionDTO);
        Task<HttpResponseMessage> AddAdmin(AdminRegiterationDTO adminRegiterationDTO);
        Task<HttpResponseMessage> AddDoctor(DoctorRegisterationByAmdinDTO doctorRegisterationByAmdin);
        Task DeleteUser(string id);
        Task<List<AdminRegiterationDTO>> getallAdmins();
        Task<List<DoctorDTO>> getallDoctors();
        Task<List<DoctorDTO>> GetDoctorspagination();
        Task<List<DoctorDTO>> getdoctorsflags();
        Task<DoctorDTO> getDoctorbyid(string id);
        Task<AdminRegiterationDTO> GetAdminByIdAsync(string id);
        Task<HttpResponseMessage> UpdateDoctor(DoctorDTO doctorDTO);
        Task<HttpResponseMessage> UpdateDoctorAds(UpdateDoctorAds UpdateDoctorAds);
        Task<HttpResponseMessage> UpdateAdminAsync(AdminUpdatingProfileDTO adminUpdatingProfileDTO);
        Task<HttpResponseMessage> UpdateDoctor_AsDelete(string ID);
    }
}