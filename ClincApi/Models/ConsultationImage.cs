using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClincApi.Models
{
    public class ConsultationImage
    {
        public int Id { get; set; }
        public string Image { get; set; }
        [ForeignKey("Consultation")]
        public int ConsultationId { get; set; }
        public virtual Consultation Consultation { get; set; } = new Consultation();
    }
}
