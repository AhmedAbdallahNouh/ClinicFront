using Azure;
using ClincApi.Models;
using ClincApi.Repositeries;
using ClinicModels;
using ClinicModels.DTOs.ArticleDto;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClincApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleRepo _ArticleRepo;

        public ArticleController(IArticleRepo ArticleRepo)
        {
            _ArticleRepo = ArticleRepo;
        }


        [HttpGet]
        public ActionResult GetAllArticles()
        {
            try
            {
                List<Article> articles = _ArticleRepo.GetAllArticle();
                if (articles == null)
                {
                    return NotFound();
                }
                else
                {
                    List<ArticleDto> articleDtos = new List<ArticleDto>();
                    foreach (Article article in articles)
                    {
                        ArticleDto articleDto = new ArticleDto()
                        {
                            Id = article.Id,
                            Title = article.Title,
                            SubTitle = article.SubTitle,
                            ArticleImage = article.ArticleImage,
                            AppUserId = article.AppUser.Id,
                            AppUserNmae = article.AppUser.FirstName + article.AppUser.LastName,
                            ArticleDate = article.ArticleDate,
                            Sections = article.Sections.Select(x => new SectionDto() {Id = x.Id,Title = x.Title,Content = x.Content,SectionImage = x.SectionImage,ArticleId = x.Id }).ToList()
                        };
                        articleDtos.Add(articleDto);
                    }
                    return Ok(articleDtos);
                }
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult GetArticleById(int id)
        {
            Article article = _ArticleRepo.GetArticleByIdWithInclude(id);
            if (article == null)
            {
                return NotFound();
            }
            ArticleDto articleDto = new ArticleDto()
            {
                Id = article.Id,
                Title = article.Title,
                SubTitle = article.SubTitle,
                ArticleImage = article.ArticleImage,
                AppUserId = article.AppUserId,
                AppUserNmae = article.AppUser.FirstName + article.AppUser.LastName,
                AppUserImage = article.AppUser.Image,
                Sections = article.Sections.Select(x => new SectionDto() { Id = x.Id, Title = x.Title, Content = x.Content, SectionImage = x.SectionImage, ArticleId = x.Id }).ToList()
            };
            return Ok(articleDto);
        }

        [HttpPut]
        public ActionResult UpdateArticle(ArticleDto articleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                Article article = new Article()
                {
                    Id = articleDto.Id,
                    Title = articleDto.Title,
                    SubTitle = articleDto.SubTitle,
                    ArticleImage = articleDto.ArticleImage,
                    AppUserId = articleDto.AppUserId,
                    Sections = articleDto.Sections.Select(x => new Section() { Id = x.Id, Title = x.Title, Content = x.Content, SectionImage = x.SectionImage, ArticleId = x.Id }).ToList()
                };
                _ArticleRepo.UpdateArticle(article);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public ActionResult AddArticle(ArticleDto articleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                Article article = new Article()
                {
                    Id = articleDto.Id,
                    Title = articleDto.Title,
                    SubTitle = articleDto.SubTitle,
                    ArticleImage = articleDto.ArticleImage,
                    AppUserId = articleDto.AppUserId,
                    Sections = articleDto.Sections.Select(x => new Section() { Id = x.Id, Title = x.Title, Content = x.Content, SectionImage = x.SectionImage, ArticleId = x.Id }).ToList()
                };

                var response =  _ArticleRepo.addArticle(article);
                if (response == "Added")
                {
                    return NoContent();
                }
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public ActionResult DeleteArticle(int id)
        {
            var article = _ArticleRepo.GetArticleByIdWithLessInclude(id);
            if (article == null)
            {
                return NotFound();
            }
            else
            {
                var response = _ArticleRepo.deleteArticle(article);
                if (response == true)
                {
                    return NoContent();
                }
                return BadRequest("There Is Error In Server");
            }
        }
    }
}
