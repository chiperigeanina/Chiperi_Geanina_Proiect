using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Chiperi_Geanina_Proiect.Models;

namespace Chiperi_Geanina_Proiect.Data
{
    public class Chiperi_Geanina_ProiectContext : DbContext
    {
        public Chiperi_Geanina_ProiectContext (DbContextOptions<Chiperi_Geanina_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Chiperi_Geanina_Proiect.Models.Phone> Phone { get; set; }

        public DbSet<Chiperi_Geanina_Proiect.Models.Brand> Brand { get; set; }

        public DbSet<Chiperi_Geanina_Proiect.Models.Category> Category { get; set; }
    }
}
