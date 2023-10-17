using System.Text.Json;
using System.Text;
using ClinicModels.DTOs.DoctorDTO;
using ClinicModels.DTOs.MainDTO;
using ClinicModels.DTOs.DoctorServiceDTO;
using ClinicModels;
using static System.Net.WebRequestMethods;

namespace ClinicFront.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly HttpClient _http;

        public DoctorService(HttpClient http)
        {
            this._http = http;
        }
        public async Task<List<DoctorServiceDTO>> GetAllService(string id)
        {
            //var doctorId = new StringContent(JsonSerializer.Serialize(id), Encoding.UTF8, "application/json");
            var response = await _http.GetAsync("/api/DoctorService" + id);
            var stream = await response.Content.ReadAsStreamAsync();
            var t = await JsonSerializer.DeserializeAsync<List<DoctorServiceDTO>>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return t;
        }
        public async Task<HttpResponseMessage> AddService(DoctorServiceDTO doctorServiceDTO)
        {
            var doctorService = new StringContent(JsonSerializer.Serialize(doctorServiceDTO), Encoding.UTF8, "application/json");
            var response = await _http.PostAsync("/api/DoctorService", doctorService);
            return response;
        }

        public async Task<HttpResponseMessage> UpdateService(DoctorServiceDTO doctorServiceDTO)
        {
            var doctorService = new StringContent(JsonSerializer.Serialize(doctorServiceDTO), Encoding.UTF8, "application/json");
           return await _http.PutAsync("/api/DoctorService", doctorService);
        }

        public async Task<HttpResponseMessage> DeleteService(int id)
        {
          return  await _http.DeleteAsync("/api/DoctorService/" + id);
        }
    }
}
