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


        [HttpGet]
        public ActionResult GetAllPosts()
        {
            List<Post> posts = _PostRepo.GetAllPosts();
            if (posts == null)
            {
                return NotFound();
            }
            else
            {
                List<PostDTO> postDTOs = new List<PostDTO>();
                foreach (Post post in posts)
                {
                    PostDTO postDTO = new PostDTO()
                    {
                        Id = post.Id,
                        Text = post.Text,
                        Video = post.Video,
                        AppUserId = post.AppUserId
                    };
                    postDTOs.Add(postDTO);
                }
                return Ok(postDTOs);
            }
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
               
               if(postDTO.Image != null)
               {
                    List<PostImage> postImages = new List<PostImage>();
                    foreach (var image in postDTO.Image)
                    {
                        PostImage img = new PostImage()
                        {
                            Image = image,
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
