namespace ClincApi.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public AppUser AppUser { get; set; }
        List<ConsultationImage>? ConsultationImages { get; }
    }
}
