using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Chiperi_Geanina_Proiect.Data;
using Chiperi_Geanina_Proiect.Models;

namespace Chiperi_Geanina_Proiect.Pages.Phones
{
    public class IndexModel : PageModel
    {
        private readonly Chiperi_Geanina_Proiect.Data.Chiperi_Geanina_ProiectContext _context;

        public IndexModel(Chiperi_Geanina_Proiect.Data.Chiperi_Geanina_ProiectContext context)
        {
            _context = context;
        }

        public IList<Phone> Phone { get;set; }
        public PhoneData PhoneD { get; set; }
        public int PhoneID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            PhoneD = new PhoneData();

            PhoneD.Phones = await _context.Phone
            .Include(b => b.Brand)
            .Include(b => b.PhoneCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Model)
            .ToListAsync();
            if (id != null)
            {
                PhoneID = id.Value;
                Phone phone = PhoneD.Phones
                .Where(i => i.ID == id.Value).Single();
                PhoneD.Categories = phone.PhoneCategories.Select(s => s.Category);
            }
        }
    }
}
