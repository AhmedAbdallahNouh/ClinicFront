using ClinicModels.DTOs.MainDTO;
using System.Text.Json;
using System.Text;
using ClinicModels;

namespace ClinicFront.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient http;

        public CategoryService(HttpClient http)
        {
            this.http = http;
        }

        public async Task<List<CategoryDTO>> getallcategory()
        {
            return await JsonSerializer.DeserializeAsync<List<CategoryDTO>>
                (await http.GetStreamAsync("/api/Category"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        //public async Task<CategoryDTO> getbycategory(int id)
        //{
        //    return await JsonSerializer.DeserializeAsync<CategoryDTO>
        //        (await http.GetStreamAsync("/api/User" + id), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        //}

        public async Task<HttpResponseMessage> Addcategory(CategoryDTO category)
        {
            var newuser = new StringContent(JsonSerializer.Serialize(category), Encoding.UTF8, "application/json");
            var response = await http.PostAsync("/api/Category", newuser);
            return response;
        }

        public async void Updatecategory(CategoryDTO categoryDTO)
        {
            var newuser = new StringContent(JsonSerializer.Serialize(categoryDTO), Encoding.UTF8, "application/json");
            await http.PutAsync("/api/Category" + categoryDTO.Id, newuser);
        }

        public async Task Deletecategory(int id)
        {
            await http.DeleteAsync("/api/Category/" + id);
        }
    }
}
