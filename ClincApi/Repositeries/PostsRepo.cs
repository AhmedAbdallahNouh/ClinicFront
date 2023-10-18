using ClincApi.Models;
using ClinicModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ClincApi.Repositeries
{
    public class PostsRepo : IPostsRepo
    {
        ClinicDBContext _clinicDBContext;
        public PostsRepo(ClinicDBContext clinicDBContext)
        {
            _clinicDBContext = clinicDBContext;
        }
        public List<Post> GetAllPosts(string id)
        {
            return _clinicDBContext.Posts.Where(p => p.AppUserId == id).Include(x => x.AppUser).ToList();
        }
        public List<PostDTO> GetPostsPagination(string id , int page )
        {
            var allPosts = _clinicDBContext.Posts.Where(p=> p.AppUserId == id).Include(p=>p.PostImages).OrderByDescending(p => p.Date).ToList();
            var result = allPosts.Skip((page - 1) * 10).Take(10).ToList();
            //var result = (dbContext.Orders.Include(o => o.Admin).Include(o => o.Playstation).Include(o => o.OrderItemDetails)).OrderByDescending(o => o.StartTime).Skip((page - 1) * size).Take(size).ToList();
            var total = _clinicDBContext.Posts.Count();
            var pages = (int)Math.Ceiling((decimal)total / 10);
            double orderCafeTotalPrice = 0;

            //PostDTO postDTO = new PaginationVM(total, pages, false, allOrdersTotalPrice, result, orderCafeTotalPrice, orderGamingTotalPrice);
            List<PostDTO> postDTOs = new List<PostDTO>();
          foreach(var post in result)
            {
                PostDTO postDTO = new()
                {
                    Id = post.Id,
                    AppUserId = post.AppUserId,
                    Text = post.Text,
                    Video = post.Video,
                   
                };
                List<PostImageDTO> images = new List<PostImageDTO>();
                foreach(var postImage in post.PostImages)
                {
                    PostImageDTO postImageDTO = new()
                    {
                        Id = postImage.Id,
                        Image = postImage.Image,
                        PostId = postImage.Id,
                    };
                    images.Add(postImageDTO);                 
                }
                postDTO.Images = images;
                postDTOs.Add(postDTO);
            }


            return postDTOs;
        }
        public Post GetPostById(int id)
        {
            return _clinicDBContext.Posts.Include(x => x.AppUser).Where(x => x.Id == id).SingleOrDefault();
        }

        public Post addPost(Post post)
        {
            _clinicDBContext.Posts.Add(post);
            _clinicDBContext.SaveChanges();
            return post;
        }

        public void UpdatePost(Post post)
        {
            _clinicDBContext.Entry(post).State = EntityState.Modified;
            _clinicDBContext.SaveChanges();
        }

        public void deletePost(int id)
        {
            Post post = _clinicDBContext.Posts.Find(id);
            _clinicDBContext.Remove(post);
            _clinicDBContext.SaveChanges();
        }
    }
}
