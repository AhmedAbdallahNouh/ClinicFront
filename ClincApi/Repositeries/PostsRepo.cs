using ClincApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ClincApi.Repositeries
{
    public class PostsRepo : IPostsRepo
    {
        ClinicDBContext _CategoryDbContext;
        public PostsRepo(ClinicDBContext CategoryDbContext)
        {
            _CategoryDbContext = CategoryDbContext;
        }
        public List<Post> GetAllPosts(string id)
        {
            return _CategoryDbContext.Posts.Where(p => p.AppUserId == id).Include(x => x.AppUser).ToList();
        }

        public Post GetPostById(int id)
        {
            return _CategoryDbContext.Posts.Include(x => x.AppUser).Where(x => x.Id == id).SingleOrDefault();
        }

        public Post addPost(Post post)
        {
            _CategoryDbContext.Posts.Add(post);
            _CategoryDbContext.SaveChanges();
            return post;
        }

        public void UpdatePost(Post post)
        {
            _CategoryDbContext.Entry(post).State = EntityState.Modified;
            _CategoryDbContext.SaveChanges();
        }

        public void deletePost(int id)
        {
            Post post = _CategoryDbContext.Posts.Find(id);
            _CategoryDbContext.Remove(post);
            _CategoryDbContext.SaveChanges();
        }
    }
}
