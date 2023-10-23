namespace ClincApi.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public AppUser AppUser { get; set; }
        public List<DoctorService> doctorServices { get; set;} = new List<DoctorService>();
        public List<Consultation>? Consultations { get; set; } 
    }
}
