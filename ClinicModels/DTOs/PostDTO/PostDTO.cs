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
        public string? Image { get; set; }
        public string? Video { get; set; }
        public string AppUserId { get; set; }
    }
}
