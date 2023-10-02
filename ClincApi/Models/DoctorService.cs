using System.ComponentModel.DataAnnotations.Schema;

namespace ClincApi.Models
{
    public class DoctorService
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Discription { get; set; }
        public string? Image { get; set; }

        //Relation between Doctorservice and Appuser
        [ForeignKey("AppUser")]
        public string AppUser_Id { get; set; }
        public AppUser AppUser { get; set; }
    }
}