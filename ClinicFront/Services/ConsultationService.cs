using ClinicModels.DTOs.DoctorServiceDTO;
using System.Text.Json;
using System.Text;
using ClinicModels.DTOs.ConsultationDTO;
using ClinicModels;
using static System.Net.WebRequestMethods;

namespace ClinicFront.Services
{
    public class ConsultationService : IConsultationService
    {
        private readonly HttpClient _http;

        public ConsultationService(HttpClient http)
        {
            this._http = http;
        }
        public async Task<List<CnosultationDTO>> GetAllConsultations()
        {
            //var doctorId = new StringContent(JsonSerializer.Serialize(id), Encoding.UTF8, "application/json");
            var response = await _http.GetAsync("/api/Consultation");
            if(!response.IsSuccessStatusCode) return new List<CnosultationDTO>();
            var stream = await response.Content.ReadAsStreamAsync();
            var CnosultationDTOs = await JsonSerializer.DeserializeAsync<List<CnosultationDTO>>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return CnosultationDTOs;
        }
        public async Task<List<CnosultationDTO>> GetAllForDoctorByCategoryId(int catergoryId)
        {
            var response = await _http.GetAsync($"/api/getall/{catergoryId}");
            var stream = await response.Content.ReadAsStreamAsync();
            var CnosultationDTOs = await JsonSerializer.DeserializeAsync<List<CnosultationDTO>>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return CnosultationDTOs;
        }
        public async Task<CnosultationDTO> GetById(int id)
        {
            return await JsonSerializer.DeserializeAsync<CnosultationDTO>
               (await _http.GetStreamAsync($"/api/getbyid/{id}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

        }
        public async Task<HttpResponseMessage> AddConsultation(AddConsultationDTO consultationDto)
        {
            var consultationToAdd = new StringContent(JsonSerializer.Serialize(consultationDto), Encoding.UTF8, "application/json");
            var response = await _http.PostAsync("/api/Consultation", consultationToAdd);
            return response;
        }

        public async Task<HttpResponseMessage> UpdateConsultation(CnosultationDTO consultationDto)
        {
            var consultationToUpdate = new StringContent(JsonSerializer.Serialize(consultationDto), Encoding.UTF8, "application/json");
            return await _http.PutAsync("/api/Consultation", consultationToUpdate);
        }

        public async Task<HttpResponseMessage> DeleteConsultation(int id)
        {
            return await _http.DeleteAsync("/api/Consultation/" + id);
        }
    }
}
