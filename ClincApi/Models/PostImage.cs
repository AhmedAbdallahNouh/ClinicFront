using System.ComponentModel.DataAnnotations.Schema;

namespace ClincApi.Models
{
    public class PostImage
    {
        public int Id { get; set; }
        public string? Image { get; set; }
        [ForeignKey("Post")]
        public int postId { get; set; }
        public Post? Post { get; set; }

        public static implicit operator List<object>(PostImage v)
        {
            throw new NotImplementedException();
        }
    }
}
