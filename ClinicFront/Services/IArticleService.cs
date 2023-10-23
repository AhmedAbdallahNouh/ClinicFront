using ClinicModels.DTOs.ArticleDto;

namespace ClinicFront.Services
{
    public interface IArticleService
    {
        Task<HttpResponseMessage> AddArticle(ArticleDto articleDto);
        Task<HttpResponseMessage> DeleteArticle(int id);
        Task<List<ArticleDto>> getallArticles();
        Task<ArticleDto> getArticlebyid(int id);
        Task<HttpResponseMessage> UpdateArticle(ArticleDto articleDto);
    }
}