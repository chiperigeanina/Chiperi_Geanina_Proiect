using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Chiperi_Geanina_Proiect.Models
{
    public class Brand
    {
        public int ID { get; set; }

        [Display(Name = "Brand")]
        public string BrandName { get; set; }
        public ICollection<Phone> Phones { get; set; }
    }
}
