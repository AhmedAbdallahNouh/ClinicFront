namespace ClincApi.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<AppUser>? AppUser { get; set; }
        //Relation between category and Service
        public List<Service> doctorServices { get; set;} = new List<Service>();
        public List<Consultation>? Consultations { get; set; } 
    }
}
