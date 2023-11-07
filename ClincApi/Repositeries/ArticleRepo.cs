using ClincApi.Models;
using ClinicModels;
using Microsoft.EntityFrameworkCore;

namespace ClincApi.Repositeries
{
    public class ArticleRepo : IArticleRepo
    {
        ClinicDBContext _ArticleDBContext;
        public ArticleRepo(ClinicDBContext ArticleDBContext)
        {
            _ArticleDBContext = ArticleDBContext;
        }

        public List<Article> GetAllArticle()
        {
            return _ArticleDBContext.Articles.Include(x => x.AppUser).Select(a => new Article { Id = a.Id, Title = a.Title, SubTitle = a.SubTitle, ArticleImage = a.ArticleImage, ArticleDate = a.ArticleDate }).ToList();
        }

        public List<Article> GetArticlespagination()
        {
            var allarticles = _ArticleDBContext.Articles.ToList();
            var result = allarticles.Skip(0).Take(5).ToList();
            var total = _ArticleDBContext.Categories.Count();
            //var pages = (int)Math.Ceiling((decimal)total / 10);
            //double orderCafeTotalPrice = 0;

            return result;
        }

        public Article GetArticleByIdWithInclude(int id)
        {
            return _ArticleDBContext.Articles.Where(x => x.Id == id).Include(x => x.AppUser).Include(x => x.Sections).SingleOrDefault();
        }

        public Article GetArticleByIdWithLessInclude(int id)
        {
            return _ArticleDBContext.Articles.Find(id);
        }

        public string addArticle(Article article)
        {
            try
            {
                _ArticleDBContext.Articles.Add(article);
                _ArticleDBContext.SaveChanges();
                return "Added";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public void UpdateArticle(Article article)
        {
            _ArticleDBContext.Entry(article).State = EntityState.Modified;
            _ArticleDBContext.SaveChanges();
        }

        public bool deleteArticle(Article article)
        {
            if (article != null)
            {
                try
                {
                    _ArticleDBContext.Remove(article);
                    _ArticleDBContext.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
    }
}
