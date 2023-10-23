using ClincApi.Models;
using ClinicModels.DTOs.ConsultationImageDTO;

namespace ClincApi.Repositeries
{
    public interface IConsultationImageRepo
    {
        Task<int> AddConsultationImages(List<ConsultationImage> consultationImages);
        ConsultationImage ConvertToConsultationImage(ConsulationImageDTO consulationImageDTO);
    }
}