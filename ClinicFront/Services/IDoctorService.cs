using ClinicModels.DTOs.DoctorServiceDTO;

namespace ClinicFront.Services
{
    public interface IDoctorService
    {
        Task<HttpResponseMessage> AddService(DoctorServiceDTO doctorServiceDTO);
        Task<HttpResponseMessage> DeleteService(int id);
        Task<List<DoctorServiceDTO>> GetAllService(string id);
        Task<HttpResponseMessage> UpdateService(DoctorServiceDTO doctorServiceDTO);
    }
}