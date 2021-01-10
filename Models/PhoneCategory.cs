using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chiperi_Geanina_Proiect.Models
{
    public class PhoneCategory
    {
        public int ID { get; set; }
        public int PhoneID { get; set; }
        public Phone Phone { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
