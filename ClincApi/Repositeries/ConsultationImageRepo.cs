using ClincApi.Models;
using ClinicModels.DTOs.ConsultationImageDTO;
using System.Collections.Generic;

namespace ClincApi.Repositeries
{
    public class ConsultationImageRepo : IConsultationImageRepo
    {
        private readonly ClinicDBContext _clinicDBContext;

        public ConsultationImageRepo(ClinicDBContext clinicDBContext)
        {
            this._clinicDBContext = clinicDBContext;
        }
        public ConsultationImage ConvertToConsultationImage(ConsulationImageDTO consulationImageDTO)
        {
            return new ConsultationImage()
            {
                Image = consulationImageDTO.Image,
                ConsultationId = consulationImageDTO.ConsultationId,
                Id = consulationImageDTO.Id

            };
        }
        public async Task<int> AddConsultationImages(List<ConsultationImage> consultationImages)
        {
            try
            {

                foreach (var consultationImage in consultationImages)
                {
                    ConsultationImage consultationImageToAdd = new ConsultationImage()
                    {
                        Id = consultationImage.Id,
                        Image = consultationImage.Image
                    };
                    await _clinicDBContext.ConsultationImages.AddAsync(consultationImage);
                }
                //await _clinicDBContext.ConsultationImages.AddRangeAsync(consultationImages);

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
