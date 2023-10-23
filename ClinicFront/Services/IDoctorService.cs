using ClinicModels.DTOs.DoctorServiceDTO;

namespace ClinicFront.Services
{
    public interface IDoctorService
    {
        Task<HttpResponseMessage> AddService(ServiceDTO doctorServiceDTO);
        Task<HttpResponseMessage> DeleteService(int id);
        Task<List<ServiceDTO>> GetAllService(string id);
        Task<HttpResponseMessage> UpdateService(ServiceDTO doctorServiceDTO);
    }
}