using ClinicModels.DTOs.ConsultationDTO;

namespace ClinicFront.Services
{
    public interface IConsultationService
    {
        Task<HttpResponseMessage> AddConsultation(AddConsultationDTO consultationDto);
        Task<HttpResponseMessage> DeleteConsultation(int id);
        Task<List<CnosultationDTO>> GetAllConsultations();
        Task<List<CnosultationDTO>> GetAllForDoctorByCategoryId(int catergoryId);
        Task<CnosultationDTO> GetById(int id);
        Task<HttpResponseMessage> UpdateConsultation(CnosultationDTO consultationDto);
    }
}