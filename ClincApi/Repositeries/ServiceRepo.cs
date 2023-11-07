using ClincApi.Models;
using ClinicModels.DTOs.DoctorServiceDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace ClincApi.Repositeries
{
    public class ServiceRepo : IServiceRepo
    {
        private readonly ClinicDBContext _clinicDBContext;

        public ServiceRepo(ClinicDBContext clinicDBContext)
        {
            this._clinicDBContext = clinicDBContext;
        }

        //GetALL

        //public async Task<List<Service>> GetAllServices(string doctorId)
        //{
        //    List<Service> Service = await _clinicDBContext.Services.Include(ds => ds.doctorService).ToListAsync();
        //    return Service;
        //}

        public async Task<List<Service>> GetAllServicesToOneDoctor(string doctorId)
        {
            List<Service> Service = await _clinicDBContext.Services.Include(ds => ds.doctorService).Where(ds => ds.doctorService.Any(d => d.Doctor_Id == doctorId)).Include(ds => ds.category).ToListAsync();
            return Service;
        }

        public async Task<Service> GetServiceByIdWithInclude(int serviceId)
        {
            Service service = await _clinicDBContext.Services.Where(s => s.Id == serviceId).Include(s => s.doctorService).ThenInclude(ds => ds.AppUser).FirstOrDefaultAsync();
            return service;
        }

        public Service GetServiceByIdWithOutclude(int serviceId)
        {
            Service Service = _clinicDBContext.Services.Where(s => s.Id == serviceId).FirstOrDefault();
            return Service;
        }

        public async Task<Service> AddService(Service service)
        {
            try
            {
                await _clinicDBContext.Services.AddAsync(service);
                await _clinicDBContext.SaveChangesAsync();

                return service;
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateService(Service service)
        {
            try
            {
                _clinicDBContext.Entry(service).State = EntityState.Modified;
                _clinicDBContext.SaveChanges();

                return true;
            }
            catch { return false; }
        }

        public bool DeleteService(Service service)
        {
            if (service != null)
            {
                try
                {
                    _clinicDBContext.Services.Remove(service);
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
