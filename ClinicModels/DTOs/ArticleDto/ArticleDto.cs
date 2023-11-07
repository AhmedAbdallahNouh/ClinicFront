using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicModels.DTOs.ArticleDto
{
    public class ArticleDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "يرجى إدخال العنوان.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "يرجى إدخال نبذه عن المقال.")]
        public string SubTitle { get; set; }
        [Required(ErrorMessage = "يرجى إدخال نص المقال.")]
        public string Content { get; set; }
        [Required(ErrorMessage = "يرجى إدخال صورة.")]
        public string ArticleImage { get; set; }
        public DateTime ArticleDate { get; set; }
        public string?AppUserId { get; set; }
        public string? AppUserNmae { get; set; }
        public string? AppUserImage { get; set; }
        public virtual List<SectionDto>? Sections { get; set; } = new List<SectionDto>();
    }
}
