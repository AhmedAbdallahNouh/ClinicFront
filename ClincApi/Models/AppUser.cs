using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClincApi.Models
{
    public class AppUser : IdentityUser
    {
       
        [MaxLength(50)]
        public string? FirstName { get; set; }

        [MaxLength(50)]
        public string? LastName { get; set; }
        public int? Age { get; set; }

        [MaxLength(100)]
        public string? Address { get; set; }

        public string? Discription { get; set; }

        public int? LocationLat { get; set; }

        public int? LocationLong { get; set; }

        public int? AdvertisementFlag { get; set; }

        [MaxLength(100)]
        public string? FaceBook { get; set; }

        [MaxLength(100)]
        public string? Instgram { get; set; }

        [MaxLength(50)]
        public string? WhatsUpNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime? StartSubscriptionDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EndSubscriptionDate { get; set; }
        public string? Image { get; set; }
        public string? CoverImage { get; set; }
        public int Delete_Doctor { get; set; }
        //relation between category and appUser
        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public virtual Category? Category { get; set; }

        //relation between category and appUser 
        public virtual List<Post>? Posts { get; set; }
        //Relation between Doctorservice and Appuser
        public List<DoctorService>? doctorService { get; set; } = new List<DoctorService>();
        //Relation between Articles and Appuser
        public virtual List<Article>? Articles { get; set; }
    }
}
