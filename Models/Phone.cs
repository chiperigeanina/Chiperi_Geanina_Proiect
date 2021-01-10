using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chiperi_Geanina_Proiect.Models
{
    public class Phone
    {
        public int ID { get; set; }

        [Display(Name = "Product")]
        public string Model { get; set; }
        public string Type { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public int BrandID { get; set; }
        public Brand Brand { get; set; }

        public ICollection<PhoneCategory> PhoneCategories { get; set; }
    }
}
