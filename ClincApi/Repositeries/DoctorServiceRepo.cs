using ClincApi.Models;
using ClinicModels.DTOs.DoctorServiceDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClincApi.Repositeries
{
    public class DoctorServiceRepo : IDoctorServiceRepo
    {
        private readonly ClinicDBContext _clinicDBContext;

        public DoctorServiceRepo(ClinicDBContext clinicDBContext)
        {
            this._clinicDBContext = clinicDBContext;
        }

        //GetALL
        public async Task<List<DoctorService>> GetAllDoctorServices(string doctorId)
        {
            List<DoctorService> doctorServices = await _clinicDBContext.DoctorServices.Where(ds => ds.AppUser_Id == doctorId).ToListAsync();
            return doctorServices;
        }

        public async Task<DoctorService> GetDoctorServiceById(string doctorId, int serviceId)
        {
            DoctorService doctorService = await _clinicDBContext.DoctorServices.FirstOrDefaultAsync(ds => ds.Id == serviceId && ds.AppUser_Id == doctorId);
            return doctorService;
        }

        public async Task<DoctorServiceDTO> AddDoctorService(DoctorServiceDTO doctorServiceDTO)
        {
            DoctorService doctorServiceToAdd = new DoctorService()
            {
                //ArrivalDate = dTO.ArrivalDate,
                Title = doctorServiceDTO.Title,
                Discription = doctorServiceDTO.Discription,
                Image = doctorServiceDTO.Image,
                AppUser_Id = doctorServiceDTO.DoctorId,
            };

            await _clinicDBContext.DoctorServices.AddAsync(doctorServiceToAdd);
            await _clinicDBContext.SaveChangesAsync();
            doctorServiceDTO.Id = doctorServiceToAdd.Id;
            return doctorServiceDTO;

        }

        public async Task<DoctorServiceDTO> UpdateService(DoctorServiceDTO doctorServiceDTO)
        {
            DoctorService doctorServiceToUpdate = GetDoctorServiceById(doctorServiceDTO.DoctorId, doctorServiceDTO.Id).Result;
            doctorServiceToUpdate.Title = doctorServiceDTO.Title;
            doctorServiceToUpdate.Discription = doctorServiceDTO.Discription;
            doctorServiceToUpdate.Image = doctorServiceDTO.Image;

            _clinicDBContext.DoctorServices.Update(doctorServiceToUpdate);
            await _clinicDBContext.SaveChangesAsync();
            return doctorServiceDTO;
        }
        [HttpDelete]
        public async Task<DoctorServiceDTO> DeleteService(string doctorId, int serviceId)
        {
            DoctorService doctorServiceToDelete = GetDoctorServiceById(doctorId, serviceId).Result;
            DoctorServiceDTO doctorServiceDTO = new DoctorServiceDTO()
            {
                Id = doctorServiceToDelete.Id,
                Title = doctorServiceToDelete.Title,
                Discription = doctorServiceToDelete.Discription,
                Image = doctorServiceToDelete.Image,
                DoctorId = doctorServiceToDelete.AppUser_Id
            };
            _clinicDBContext.DoctorServices.Remove(doctorServiceToDelete);
            await _clinicDBContext.SaveChangesAsync();
            return doctorServiceDTO;
        }
    }
}
