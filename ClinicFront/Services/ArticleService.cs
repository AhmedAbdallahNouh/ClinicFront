using ClinicModels;
using System.Text.Json;
using System.Text;
using ClinicModels.DTOs.ArticleDto;

namespace ClinicFront.Services
{
    public class ArticleService : IArticleService
    {
        private readonly HttpClient http;

        public ArticleService(HttpClient http)
        {
            this.http = http;
        }

        public async Task<List<ArticleDto>> getallArticles()
        {
            return await JsonSerializer.DeserializeAsync<List<ArticleDto>>
                (await http.GetStreamAsync("/api/Article/"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<ArticleDto> getArticlebyid(int id)
        {
            return await JsonSerializer.DeserializeAsync<ArticleDto>
                (await http.GetStreamAsync("/api/Article" + id), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<HttpResponseMessage> AddArticle(ArticleDto articleDto)
        {
            var newarticle = new StringContent(JsonSerializer.Serialize(articleDto), Encoding.UTF8, "application/json");
            var response = await http.PostAsync("/api/Article", newarticle);
            return response;
        }

        public async Task<HttpResponseMessage> UpdateArticle(ArticleDto articleDto)
        {
            var newarticle = new StringContent(JsonSerializer.Serialize(articleDto), Encoding.UTF8, "application/json");
            return await http.PutAsync("/api/Article" + articleDto.Id, newarticle);
        }

        public async Task<HttpResponseMessage> DeleteArticle(int id)
        {
            return await http.DeleteAsync("/api/Article/" + id);
        }
    }
}
