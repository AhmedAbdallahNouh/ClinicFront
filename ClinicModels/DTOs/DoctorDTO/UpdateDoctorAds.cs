using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicModels.DTOs.DoctorDTO
{
    public class UpdateDoctorAds
    {
        public string Id { get; set; }
        public int? AdvertisementFlag { get; set; }
        public DateTime? EndSubscriptionDate { get; set; }
        public DateTime? VisitedDoctorPage { get; set; }
    }
}
