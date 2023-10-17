using ClinicModels.DTOs.DoctorDTO;
using ClinicModels.DTOs.MainDTO;

namespace ClinicFront.Services
{
    public interface IAdminService
    {
        Task<HttpResponseMessage> AddAdmin(AdminRegiterationDTO adminRegiterationDTO);
        Task<HttpResponseMessage> AddDoctor(DoctorRegisterationByAmdinDTO doctorRegisterationByAmdin);
        Task DeleteUser(string id);
        Task<List<AdminRegiterationDTO>> getallAdmins();
        Task<List<DoctorDTO>> getallDoctors();
        Task<List<int>> getdoctorsflags();
        Task<DoctorDTO> getDoctorbyid(string id);
        Task<AdminRegiterationDTO> GetAdminByIdAsync(string id);
        Task<HttpResponseMessage> UpdateDoctor(DoctorDTO doctorDTO);
        Task<HttpResponseMessage> UpdateAdminAsync(AdminUpdatingProfileDTO adminUpdatingProfileDTO);
        Task<HttpResponseMessage> UpdateDoctor_AsDelete(string id);
    }
}