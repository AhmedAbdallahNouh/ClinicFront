using ClincApi.Models;
using ClinicModels.DTOs.ConsultationDTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace ClincApi.Repositeries
{
    public class ConsultationRepo : IConsultationRepo
    {
        private readonly ClinicDBContext _clinicDBContext;

        public ConsultationRepo(ClinicDBContext clinicDBContext)
        {
            _clinicDBContext = clinicDBContext;
        }
        public async Task<List<Consultation>> GetAll()
        {
            return await _clinicDBContext.Consultations.Include(c => c.ConsultationImages).Include(c=> c.Category).AsNoTracking().ToListAsync();
        } 
        public async Task<List<Consultation>> GetAllForDoctorByCategoryId(int categoryId)
        {
            return await _clinicDBContext.Consultations.Include(c => c.ConsultationImages).Where(c=> c.CategoryId == categoryId).AsNoTracking().ToListAsync();
        }
        public async Task<Consultation?> GetByID(int id)
        {
            return await _clinicDBContext.Consultations.Include(c => c.ConsultationImages).SingleOrDefaultAsync(c=> c.Id == id);
        }
        public async Task<int> Add(Consultation consultation)
        {
            try
            {
                //consultation.ConsultationImages.AddRange(consultation.ConsultationImages);
                await _clinicDBContext.Consultations.AddAsync(consultation);
                return await _clinicDBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        public async Task<int> Update(Consultation consultation)
        {
            try
            {
                _clinicDBContext.Entry(consultation).State = EntityState.Modified;
                return await _clinicDBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        public async Task<int> AnswerConsultationByDoctor(int consultationId ,string answer)
        {
            try
            {
                Consultation? consultation = GetByID(consultationId).Result;
                if (consultation is not null)
                {
                    consultation.Answer = answer;
                    _clinicDBContext.Update(consultation);
                }
                return await _clinicDBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        public async Task<int> Delete(Consultation consultation)
        {
            try
            {
                _clinicDBContext.Remove(consultation);
                return await _clinicDBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
    }
}
