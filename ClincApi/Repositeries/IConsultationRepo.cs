using ClincApi.Models;

namespace ClincApi.Repositeries
{
    public interface IConsultationRepo
    {
        Task<int> Add(Consultation consultation);
        Task<int> Delete(Consultation consultation);
        Task<List<Consultation>> GetAll();
        Task<List<Consultation>> GetAllForDoctorByCategoryId(int categoryId);
        Task<Consultation?> GetByID(int id);
        Task<int> Update(Consultation consultation);
    }
}