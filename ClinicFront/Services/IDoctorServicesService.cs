using ClinicModels.DTOs.DoctorServiceDTO;

namespace ClinicFront.Services
{
    public interface IDoctorServicesService
    {
        Task<HttpResponseMessage> AddServiceToDoctor(DoctorServiceDto doctorServiceDTO);
        Task<HttpResponseMessage> DeleteServiceFromDoctor(DoctorServiceDto doctorServiceDto);
    }
}