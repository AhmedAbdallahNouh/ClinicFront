using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicModels
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="إختر فئة لتعديلها أو حذفها أو قم بإدحال إسم فئة جديدة")]
        public string Name { get; set; }
    }
}
