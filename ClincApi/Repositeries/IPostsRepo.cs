using ClincApi.Models;

namespace ClincApi.Repositeries
{
    public interface IPostsRepo
    {
        Post addPost(Post post);
        void deletePost(int id);
        List<Post> GetAllPosts(string id);
        Post GetPostById(int id);
        void UpdatePost(Post post);
    }
}