using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClincApi.Models
{
    public class Article
    {
        public int Id { get; set; }
        public  string Title { get; set; }
        public  string SubTitle { get; set; }
        public  string Content { get; set; }
        public  string ArticleImage { get; set; }
        public  DateTime ArticleDate { get; set; }

        [ForeignKey("AppUser")]
        public string AppUserId { get; set; }
        public AppUser? AppUser { get; set; } = new AppUser();
        public virtual List<Section>? Sections { get; set; } = new List<Section>();

    }
}
