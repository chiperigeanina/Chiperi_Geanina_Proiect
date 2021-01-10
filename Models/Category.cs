using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Chiperi_Geanina_Proiect.Models
{
    public class Category
    {
        public int ID { get; set; }

        [Display(Name = "Category")]
        public string CategoryName { get; set; }
        public ICollection<PhoneCategory> PhoneCategories { get; set; }
    }
}
