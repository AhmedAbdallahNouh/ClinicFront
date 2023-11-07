using ClinicModels.DTOs.ArticleDto;
using ClinicModels.DTOs.DoctorDTO;
using ClinicModels.DTOs.DoctorServiceDTO;
using ClinicModels.DTOs.MainDTO;
using ClinicModels.DTOs.UserDTO;
using System.Text;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace ClinicFront.Services
{
    public class AdminService : IAdminService
    {
        private readonly HttpClient _http;

        public AdminService(HttpClient http)
        {
            this._http = http;
        }

        public async Task<List<AdminRegiterationDTO>> getallAdmins()
        {
            var response = await JsonSerializer.DeserializeAsync<List<AdminRegiterationDTO>>
                (await _http.GetStreamAsync("/api/getalladmins"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            if (response == null)
            {
                // Handle the "NotFound" response
                return new List<AdminRegiterationDTO>(); // Return an empty list
            }
            else
            {
                return response;
            }
        }

        public async Task<List<DoctorDTO>> getallDoctors()
        {
            return await JsonSerializer.DeserializeAsync<List<DoctorDTO>>
                (await _http.GetStreamAsync("/api/getalldoctors"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
        public async Task<List<DoctorDTO>> GetDoctorspagination()
        {
            return await JsonSerializer.DeserializeAsync<List<DoctorDTO>>
                (await _http.GetStreamAsync("/api/getdoctorspagination"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<List<DoctorDTO>> getdoctorsflags()
        {
            try
            {
                var response = await JsonSerializer.DeserializeAsync<List<DoctorDTO>>
                    (await _http.GetStreamAsync("/api/getdoctorsflags"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                if (response == null)
                {
                    // Handle the "NotFound" response
                    return new List<DoctorDTO>(); // Return an empty list
                }
                else
                {
                    return response;
                }
            }
            catch
            {
                return new List<DoctorDTO>();
            }
        }

        public async Task<DoctorDTO> getDoctorbyid(string id)
        {
            return await JsonSerializer.DeserializeAsync<DoctorDTO>
                (await _http.GetStreamAsync("/api/getdoctorbyid/" + id), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
        public async Task<AdminRegiterationDTO> GetAdminByIdAsync(string id)
        {
            return await JsonSerializer.DeserializeAsync<AdminRegiterationDTO>
                (await _http.GetStreamAsync("/api/getadminbyid/" + id), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
        public async Task<HttpResponseMessage> AddUser(UserRegistritionDTO userRegistritionDTO)
        {
            var newUserToAdd = new StringContent(JsonSerializer.Serialize(userRegistritionDTO), Encoding.UTF8, "application/json");
            var response = await _http.PostAsync("/api/userregistration", newUserToAdd);
            return response;
        }

        public async Task<HttpResponseMessage> AddAdmin(AdminRegiterationDTO adminRegiterationDTO)
        {
            var newAdminToAdd = new StringContent(JsonSerializer.Serialize(adminRegiterationDTO), Encoding.UTF8, "application/json");
            var response = await _http.PostAsync("/api/AppUser", newAdminToAdd);
            return response;
        }

        public async Task<HttpResponseMessage> AddDoctor(DoctorRegisterationByAmdinDTO doctorRegisterationByAmdin)
        {
            var newDoctorToAdd = new StringContent(JsonSerializer.Serialize(doctorRegisterationByAmdin), Encoding.UTF8, "application/json");
            var response = await _http.PostAsync("/api/doctorregister", newDoctorToAdd);
            return response;
        }

        public async Task<HttpResponseMessage> UpdateDoctor_AsDelete(string id)
        {
            var doctorid = new StringContent(JsonSerializer.Serialize(id), Encoding.UTF8, "application/json");
            var response =   await _http.PutAsync("/api/deletedoctor/" + id, doctorid);
            return response;
        }
        public async Task<HttpResponseMessage> UpdateDoctorAds(UpdateDoctorAds UpdateDoctorAds)
        {
            var updateDoctorAds = new StringContent(JsonSerializer.Serialize(UpdateDoctorAds), Encoding.UTF8, "application/json");
          return  await _http.PutAsync("/api/EndSubscriptionDate", updateDoctorAds);
        }
        public async Task<HttpResponseMessage> UpdateDoctor(DoctorDTO doctorDTO)
        {
            var doctorUpdatingProfileDTO = new StringContent(JsonSerializer.Serialize(UpdateDoctorAds), Encoding.UTF8, "application/json");
            return await _http.PutAsync("/api/editdoctorprofile", doctorUpdatingProfileDTO);
        }

        public async Task<HttpResponseMessage> UpdateAdminAsync(AdminUpdatingProfileDTO adminUpdatingProfileDTO)
        {
            var AdminToUpdateProfile = new StringContent(JsonSerializer.Serialize(adminUpdatingProfileDTO), Encoding.UTF8, "application/json");
            var response = await _http.PutAsync("/api/AppUser", AdminToUpdateProfile);
            return response;
        }
        //public async Task<HttpResponseMessage> AddUser()
        //{
        //    var newAdminToAdd = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");
        //    var response = await _http.PostAsync("/api/AppUser", newAdminToAdd);
        //    return response;
        //}
        //public async Task<HttpResponseMessage> GetUserBuId(string id)
        //{
        //    var userId = new StringContent(JsonSerializer.Serialize(id), Encoding.UTF8, "application/json");
        //    var response = await _http.PostAsync("/api/getuserbyid", userId);
        //    var stream = await response.Content.ReadAsStreamAsync();
        //    var t = await JsonSerializer.DeserializeAsync<bool>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
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
        public async Task DeleteUser(string id)
        {
            await _http.DeleteAsync("/api/Delete" + id);
        }
    }
}
