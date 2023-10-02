using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClincApi.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public string? Image { get; set; }
        public string? Video { get; set; }

        //relation between appUser And Post
        [ForeignKey("AppUser")]
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

    }
}
