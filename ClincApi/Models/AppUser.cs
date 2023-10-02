using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClincApi.Models
{
    public class AppUser : IdentityUser
    {
       
        [MaxLength(50)]
        public string? firstName { get; set; }

        [MaxLength(50)]
        public string? LastName { get; set; }
        [MaxLength(10)]
        public int Age { get; set; }

        [MaxLength(100)]
        public string? Address { get; set; }

        [MaxLength(20)]
        public int LocationLat { get; set; }

        [MaxLength(20)]
        public int LocationLong { get; set; }

        [MaxLength(100)]
        public string? FaceBook { get; set; }

        [MaxLength(100)]
        public string? Instgram { get; set; }

        [MaxLength(50)]
        public int WhatsUpNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime? StartSubscriptionDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EndSubscriptionDate { get; set; }

        //relation between category and appUser
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        //relation between category and appUser
     
        public virtual List<Post>? Posts { get; set; }


        //Relation between Doctorservice and Appuser

        public virtual List<DoctorService>? Services { get; set; }
    }
}
