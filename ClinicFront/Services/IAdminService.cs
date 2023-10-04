using ClinicModels.DTOs.MainDTO;

namespace ClinicFront.Services
{
    public interface IAdminService
    {
        Task<HttpResponseMessage> AddDoctor(DoctorRegisterationByAmdinDTO doctorRegisterationByAmdin);
        Task<HttpResponseMessage> AddAdmin(AdminRegiterationDTO adminRegiterationDTO);
    }
}