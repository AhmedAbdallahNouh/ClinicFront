using ClincApi.Models;
using ClinicModels.DTOs.DoctorServiceDTO;

namespace ClincApi.Repositeries
{
    public interface IDoctorServiceRepo
    {
        Task<DoctorServiceDTO> AddDoctorService(DoctorServiceDTO doctorServiceDTO);
        Task<DoctorServiceDTO> DeleteService(string doctorId, int serviceId);
        Task<List<DoctorService>> GetAllDoctorServices(string doctorId);
        Task<DoctorService> GetDoctorServiceById(string doctorId, int serviceId);
        Task<DoctorServiceDTO> UpdateService(DoctorServiceDTO doctorServiceDTO);
    }
}