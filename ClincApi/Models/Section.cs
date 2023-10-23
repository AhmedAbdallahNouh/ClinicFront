using System.ComponentModel.DataAnnotations.Schema;

namespace ClincApi.Models
{
    public class Section
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string? SectionImage { get; set; }
        [ForeignKey("ArticleId")]
        public int ArticleId { get; set; }
        public Article Article { get; set; } = new Article();
    }
}
