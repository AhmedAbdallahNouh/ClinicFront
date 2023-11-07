using ClinicModels.DTOs.DoctorServiceDTO;
using System.Text.Json;
using System.Text;

namespace ClinicFront.Services
{
    public class DoctorServicesService : IDoctorServicesService
    {
        private readonly HttpClient _http;

        public DoctorServicesService(HttpClient http)
        {
            this._http = http;
        }

        public async Task<HttpResponseMessage> AddServiceToDoctor(DoctorServiceDto doctorServiceDTO)
        {
            var doctorService = new StringContent(JsonSerializer.Serialize(doctorServiceDTO), Encoding.UTF8, "application/json");
            var response = await _http.PostAsync("/api/DoctorService", doctorService);
            return response;
        }

        public async Task<HttpResponseMessage> DeleteServiceFromDoctor(DoctorServiceDto doctorServiceDto)
        {
            return await _http.DeleteAsync($"/api/DoctorService/{doctorServiceDto.DoctorServiceId}/{doctorServiceDto.ServiceId}");
        }
    }
}
