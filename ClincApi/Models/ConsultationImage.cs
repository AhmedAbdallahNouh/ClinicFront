using System.ComponentModel.DataAnnotations.Schema;

namespace ClincApi.Models
{
    public class ConsultationImage
    {
        public int Id { get; set; }
        public string Image { get; set; }

        [ForeignKey(nameof(Consultation))]
        public int ConsultationId { get; set; }
        public Consultation Consultation { get; set; }
    }
}
