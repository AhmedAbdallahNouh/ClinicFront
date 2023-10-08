using ClinicModels.DTOs.DoctorDTO;

namespace ClinicFront.Services
{
    public interface IDoctorService
    {
        Task<DoctorDTO> GetDoctorById(string id);
        Task<HttpResponseMessage> UpdateDoctorProfile(DoctorDTO doctorDTO);
    }
}