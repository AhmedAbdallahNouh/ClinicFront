using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClincApi.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public string? Video { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        //relation between appUser And Post
        [ForeignKey("AppUser")]
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        //relation between Post And PostImage
        public List<PostImage>? PostImages { get; set; } = new List<PostImage>();

    }
}
