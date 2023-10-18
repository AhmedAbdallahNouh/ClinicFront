using ClincApi.Models;
using ClincApi.Repositeries;
using ClinicModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClincApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostsRepo _PostRepo;

        public PostController(IPostsRepo PostRepo)
        {
            _PostRepo = PostRepo;
        }


        [HttpGet("/api/getallpostsbyid/{id}")]
        public ActionResult GetPostsPagination(string id, int page)
        {
            if (!string.IsNullOrEmpty(id) && page !=0)
            {
                List<PostDTO> posts = _PostRepo.GetPostsPagination(id, page);
                if (posts == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(posts);
                }
            }
            return BadRequest();        
        }

        [HttpGet("{id:int}")]
        public ActionResult GetPostById(int id)
        {
            Post post = _PostRepo.GetPostById(id);
            if (post == null)
            {
                return NotFound();
            }
            PostDTO postDTO = new PostDTO()
            {
                Id = post.Id,
                Text = post.Text,
                Video = post.Video,
                AppUserId = post.AppUserId
            };
            return Ok(postDTO);
        }

        [HttpPut]
        public ActionResult UpdatePOst(PostDTO postDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                Post post = new Post()
                {
                    Id = postDTO.Id,
                    Text = postDTO.Text,
                    Video = postDTO.Video,
                    AppUserId = postDTO.AppUserId
                };
                _PostRepo.UpdatePost(post);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
       
        [HttpPost]
        public ActionResult AddPost(PostDTO postDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                Post post = new Post()
                {
                    Text = postDTO.Text,
                    Video= postDTO.Video,
                    AppUserId = postDTO.AppUserId
                };
               
               if(postDTO.Images != null)
               {
                    List<PostImage> postImages = new List<PostImage>();
                    foreach (var image in postDTO.Images)
                    {
                        PostImage img = new PostImage()
                        {
                            Image = image.Image,
                            postId = post.Id
                        };
                        postImages.Add(img);
                    }
                    post.PostImages.AddRange(postImages);
                    _PostRepo.addPost(post);

                }
                return Ok(postDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public ActionResult DeletePost(int id)
        {
            if (_PostRepo.GetPostById(id) == null)
            {
                return NotFound();
            }
            else
            {
                _PostRepo.deletePost(id);
                return NoContent();
            }
        }
    }
}
