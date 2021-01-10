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
    public class DeleteModel : PageModel
    {
        private readonly Chiperi_Geanina_Proiect.Data.Chiperi_Geanina_ProiectContext _context;

        public DeleteModel(Chiperi_Geanina_Proiect.Data.Chiperi_Geanina_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Phone Phone { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Phone = await _context.Phone.FirstOrDefaultAsync(m => m.ID == id);

            if (Phone == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Phone = await _context.Phone.FindAsync(id);

            if (Phone != null)
            {
                _context.Phone.Remove(Phone);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
