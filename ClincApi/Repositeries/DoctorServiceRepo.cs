using ClincApi.Models;
using ClinicModels.DTOs.DoctorServiceDTO;
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

        public DoctorService GetDoctorServiceById(string doctorid, int serviceId)
        {
            DoctorService doctorService = _clinicDBContext.DoctorServices.Where(s => s.Doctor_Id == doctorid && s.Service_Id == serviceId).FirstOrDefault();
            return doctorService;
        }

        public async Task<DoctorService> AddServiceToDoctor(DoctorService doctorService)
        {
            try
            {
                await _clinicDBContext.DoctorServices.AddAsync(doctorService);
                await _clinicDBContext.SaveChangesAsync();

                return doctorService;
            }
            catch
            {
                return null;
            }
        }

        public bool DeleteServiceFromDoctor(DoctorService doctorService)
        {
            if (doctorService != null)
            {
                try
                {
                    _clinicDBContext.DoctorServices.Remove(doctorService);
                    _clinicDBContext.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
    }
}
