using System.Text.Json;
using System.Text;
using ClinicModels.DTOs.DoctorDTO;
using ClinicModels.DTOs.MainDTO;
using ClinicModels.DTOs.DoctorServiceDTO;
using ClinicModels;
using static System.Net.WebRequestMethods;
using ClinicModels.DTOs.ArticleDto;

namespace ClinicFront.Services
{
    public class ServicesService : IServicesService
    {
        private readonly HttpClient _http;

        public ServicesService(HttpClient http)
        {
            this._http = http;
        }
        //public async Task<List<ServiceDTO>> GetAllServices(string id)
        //{
        //    //var doctorId = new StringContent(JsonSerializer.Serialize(id), Encoding.UTF8, "application/json");
        //    var response = await _http.GetAsync("/api/Service" + id);
        //    var stream = await response.Content.ReadAsStreamAsync();
        //    var t = await JsonSerializer.DeserializeAsync<List<ServiceDTO>>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        //    return t;
        //}

        public async Task<List<ServiceDTO>> GetAllServicesForOneDoctor(string id)
        {
            //var doctorId = new StringContent(JsonSerializer.Serialize(id), Encoding.UTF8, "application/json");
            //var response = await _http.GetAsync($"/api/getallservicesforonedoctor/{id}");
            //var stream = await response.Content.ReadAsStreamAsync();
            //var t = await JsonSerializer.DeserializeAsync<List<ServiceDTO>>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            //return t;
            return await JsonSerializer.DeserializeAsync<List<ServiceDTO>>
                (await _http.GetStreamAsync($"/api/getallservicesforonedoctor/{id}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        } 
        
        public async Task<ServiceDTO> GetServiceWithHisDoctors(int id)
        {
            return await JsonSerializer.DeserializeAsync<ServiceDTO>
                 (await _http.GetStreamAsync($"/api/doctorid/{id}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        } 
        
        public async Task<ServiceDTO> GetServiceByid(int id)
        {
            //var doctorId = new StringContent(JsonSerializer.Serialize(id), Encoding.UTF8, "application/json");
            var response = await _http.GetAsync("/api/Service/" + id);
            var stream = await response.Content.ReadAsStreamAsync();
            var t = await JsonSerializer.DeserializeAsync<ServiceDTO>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return t;
        }
        public async Task<HttpResponseMessage> AddService(ServiceDTO ServiceDTO)
        {
            var Service = new StringContent(JsonSerializer.Serialize(ServiceDTO), Encoding.UTF8, "application/json");
            var response = await _http.PostAsync("/api/Service", Service);
            return response;
        }

        public async Task<HttpResponseMessage> UpdateService(ServiceDTO doctorServiceDTO)
        {
            var doctorService = new StringContent(JsonSerializer.Serialize(doctorServiceDTO), Encoding.UTF8, "application/json");
            return await _http.PutAsync("/api/Service", doctorService);
        }


        public async Task<HttpResponseMessage> DeleteService(int id)
        {
            return await _http.DeleteAsync($"/api/Service?id={id}");
        }
    }
}
