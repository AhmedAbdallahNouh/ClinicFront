using ClinicModels;
using System.Text.Json;
using System.Text;

namespace ClinicFront.Services
{
    public class PostService : IPostService
    {
        private readonly HttpClient http;

        public PostService(HttpClient http)
        {
            this.http = http;
        }

        public async Task<List<PostDTO>> getallPosts(string id,int page)
        {
            return await JsonSerializer.DeserializeAsync<List<PostDTO>>
                (await http.GetStreamAsync($"/api/getallpostsbyid/{id}/?page={page}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<PostDTO> getbyid(int id)
        {
            return await JsonSerializer.DeserializeAsync<PostDTO>
                (await http.GetStreamAsync("/api/Post" + id), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<HttpResponseMessage> AddPost(PostDTO postDTO)
        {
            var newuser = new StringContent(JsonSerializer.Serialize(postDTO), Encoding.UTF8, "application/json");
            var response = await http.PostAsync("/api/Post", newuser);
            return response;
        }

        public async Task<HttpResponseMessage> UpdatePost(PostDTO postDTO)
        {
            var newuser = new StringContent(JsonSerializer.Serialize(postDTO), Encoding.UTF8, "application/json");
           return await http.PutAsync("/api/Post" + postDTO.Id, newuser);
        }

        public async Task<HttpResponseMessage> DeletePost(int id)
        {
           return await http.DeleteAsync("/api/Post/" + id);
        }
    }
}
