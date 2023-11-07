using ClinicModels.DTOs.DoctorServiceDTO;

namespace ClinicFront.Services
{
    public interface IServicesService
    {
        Task<HttpResponseMessage> AddService(ServiceDTO ServiceDTO);
        Task<HttpResponseMessage> DeleteService(int id);
        //Task<List<ServiceDTO>> GetAllServices(string id);
        Task<List<ServiceDTO>> GetAllServicesForOneDoctor(string id);
        Task<ServiceDTO> GetServiceWithHisDoctors(int id);
        Task<ServiceDTO> GetServiceByid(int id);
        Task<HttpResponseMessage> UpdateService(ServiceDTO doctorServiceDTO);
    }
}