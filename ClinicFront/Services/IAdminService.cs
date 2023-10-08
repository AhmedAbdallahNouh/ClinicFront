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
        Task<DoctorDTO> getDoctorbyid(string id);
        void UpdateDoctor(DoctorDTO doctorDTO);
        void UpdateDoctor_AsDelete(string id);
    }
}