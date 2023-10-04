using ClinicModels.DTOs.MainDTO;
using System.Text;
using System.Text.Json;

namespace ClinicFront.Services
{
    public class AdminService : IAdminService
    {
        private readonly HttpClient _http;

        public AdminService(HttpClient http)
        {
            this._http = http;
        }

        //public async Task<List<UserDtos>> getallusers()
        //{
        //    return await JsonSerializer.DeserializeAsync<List<UserDtos>>
        //        (await http.GetStreamAsync("/api/User"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        //}

        //public async Task<UserDtos> getbyid(string id)
        //{
        //    return await JsonSerializer.DeserializeAsync<UserDtos>
        //        (await http.GetStreamAsync("/api/User" + id), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        //}

        public async Task<HttpResponseMessage> AddDoctor(DoctorRegisterationByAmdinDTO doctorRegisterationByAmdin)
        {
            var newDoctorToAdd = new StringContent(JsonSerializer.Serialize(doctorRegisterationByAmdin), Encoding.UTF8, "application/json");
            var response = await _http.PostAsync("/api/doctorregister", newDoctorToAdd);
            return response;
        }

        public async Task<HttpResponseMessage> AddAdmin(AdminRegiterationDTO adminRegiterationDTO)
        {
            var newAdminToAdd = new StringContent(JsonSerializer.Serialize(adminRegiterationDTO), Encoding.UTF8, "application/json");
            var response = await _http.PostAsync("/api/AppUser", newAdminToAdd);
            return response;
        }
        public async Task<HttpResponseMessage> GetUserBuId(string id)
        {
            var userId = new StringContent(JsonSerializer.Serialize(id), Encoding.UTF8, "application/json");
            var response = await _http.PostAsync("/api/getuserbyid", userId);
            var stream = await response.Content.ReadAsStreamAsync();
            var t = await JsonSerializer.DeserializeAsync<bool>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return response;
        }

        //public async Task<bool> Login(LoginDTO loginDTO)
        //{
        //    var login = new StringContent(JsonSerializer.Serialize(loginDTO), Encoding.UTF8, "application/json");
        //    var response = await http.PostAsync("/api/login", login);
        //    var stream = await response.Content.ReadAsStreamAsync();
        //    var t = await JsonSerializer.DeserializeAsync<bool>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        //    return t;
        //}

        //public async void UpdateUser(UserDtos user)
        //{
        //    var newuser = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");
        //    await http.PutAsync("/api/User" + user.Id, newuser);
        //}
    }
}
