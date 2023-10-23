using ClincApi.Models;

namespace ClincApi.Repositeries
{
    public interface IDoctorServiceRepo
    {
        Task<DoctorService> AddServiceToDoctor(DoctorService doctorService);
        bool DeleteServiceFromDoctor(DoctorService doctorService);
        DoctorService GetDoctorServiceById(string doctorid, int serviceId);
    }
}