using ClincApi.Models;

namespace ClincApi.Repositeries
{
    public interface IServiceRepo
    {
        Task<Service> AddService(Service service);
        bool DeleteService(Service service);
        Task<List<Service>> GetAllServicesToOneDoctor(string doctorId);
        Task<Service> GetServiceByIdWithInclude(int serviceId);
        Service GetServiceByIdWithOutclude(int serviceId);
        bool UpdateService(Service service);
    }
}