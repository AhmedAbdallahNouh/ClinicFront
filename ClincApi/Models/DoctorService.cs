using System.ComponentModel.DataAnnotations.Schema;

namespace ClincApi.Models
{
    public class DoctorService
    {
        [ForeignKey("Service")]
        public int Service_Id { get; set; }
        public Service? Service { get; set; }

        [ForeignKey("AppUser")]
        public string Doctor_Id { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
