using ClincApi.Models;

namespace ClincApi.Repositeries
{
    public interface IArticleRepo
    {
        string addArticle(Article article);
        bool deleteArticle(Article article);
        List<Article> GetAllArticle();
        List<Article> GetArticlespagination();
        Article GetArticleByIdWithInclude(int id);
        Article GetArticleByIdWithLessInclude(int id);
        void UpdateArticle(Article article);
    }
}