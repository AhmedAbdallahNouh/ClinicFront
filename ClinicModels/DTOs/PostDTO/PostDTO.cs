using ClinicModels.DTOs.DoctorServiceDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ClinicModels
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public List<PostImageDTO>? Images { get; set; } = new List<PostImageDTO>();
        public DateTime Date { get; set; }

        public string? Video { get; set; }
        public string AppUserId { get; set; }
    }
}
