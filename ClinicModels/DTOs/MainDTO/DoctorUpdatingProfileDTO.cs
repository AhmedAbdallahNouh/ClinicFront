using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicModels.DTOs.MainDTO
{
    public class DoctorUpdatingProfileDTO : RegistraionBaseDTO
    {

        //[MaxLength(20)]
        public int? LocationLat { get; set; }

        //[MaxLength(20)]
        public int? LocationLong { get; set; }

        [MaxLength(100)]
        public string? FaceBook { get; set; }

        [MaxLength(100)]
        public string? Instgram { get; set; }

        //[MaxLength(50)]
        public int? WhatsUpNumber { get; set; }
    }
}
