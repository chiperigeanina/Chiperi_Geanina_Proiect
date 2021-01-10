using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chiperi_Geanina_Proiect.Models
{
    public class PhoneData
    {
        public IEnumerable<Phone> Phones { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<PhoneCategory> PhoneCategories { get; set; }
    }
}
