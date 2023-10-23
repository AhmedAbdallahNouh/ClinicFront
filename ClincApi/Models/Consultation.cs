using ClincApi.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClincApi.Models
{
    public class Consultation
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Description { get; set; }
        public string? Answer { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public List<ConsultationImage>? ConsultationImages { get; set; }
    }
}


