using System.Text.Json;
using System.Text;
using ClinicModels.DTOs.DoctorDTO;

namespace ClinicFront.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly HttpClient _http;

        public DoctorService(HttpClient http)
        {
            this._http = http;
        }
        public async Task<DoctorDTO> GetDoctorById(string id)
        {
            //var doctorId = new StringContent(JsonSerializer.Serialize(id), Encoding.UTF8, "application/json");
            var response = await _http.GetAsync($"/api/getdoctorbyid/?id={id}");
            var stream = await response.Content.ReadAsStreamAsync();
            var t = await JsonSerializer.DeserializeAsync<DoctorDTO>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return t;
        }
    }
}
