using System.Text.Json;
using System.Text;
using ClinicModels.DTOs.MainDTO;

namespace ClinicFront.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient http;

        public UserService(HttpClient http)
        {
            this.http = http;
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

        //public async Task<HttpResponseMessage> AddUser(UserDtos user)
        //{
        //    var newuser = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");
        //    var response = await http.PostAsync("/api/User", newuser);
        //    return response;
        //}

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
