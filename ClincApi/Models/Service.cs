using System.ComponentModel.DataAnnotations.Schema;

namespace ClincApi.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Discription { get; set; }
        public string? Image { get; set; }

        //Relation between Doctorservice and Service
        public List<DoctorService>? doctorService { get; set; } = new List<DoctorService>();

        //Relation between service and Category
        [ForeignKey("category")]
        public int Category_Id { get; set; }
        public Category? category { get; set; }
    }
}