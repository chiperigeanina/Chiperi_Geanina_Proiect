using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Chiperi_Geanina_Proiect.Data;
using Chiperi_Geanina_Proiect.Models;

namespace Chiperi_Geanina_Proiect.Pages.Phones
{
    public class EditModel : PhoneCategoriesPageModel
    {
        private readonly Chiperi_Geanina_Proiect.Data.Chiperi_Geanina_ProiectContext _context;

        public EditModel(Chiperi_Geanina_Proiect.Data.Chiperi_Geanina_ProiectContext context)
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

            Phone = await _context.Phone.Include(b => b.Brand).Include(b => b.PhoneCategories).ThenInclude(b => b.Category).AsNoTracking().FirstOrDefaultAsync(m => m.ID == id);

            if (Phone == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Phone);

            ViewData["BrandID"] = new SelectList(_context.Brand, "ID", "BrandName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var phoneToUpdate = await _context.Phone
            .Include(i => i.Brand)
            .Include(i => i.PhoneCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (phoneToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Phone>(
            phoneToUpdate,
            "Phone",
            i => i.Model, i => i.Type,
            i => i.Price, i => i.ReleaseDate, i => i.Brand))
            {
                UpdatePhoneCategories(_context, selectedCategories, phoneToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdatePhoneCategories(_context, selectedCategories, phoneToUpdate);
            PopulateAssignedCategoryData(_context, phoneToUpdate);
            return Page();
        }
    }
}



            /* if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Phone).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhoneExists(Phone.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PhoneExists(int id)
        {
            return _context.Phone.Any(e => e.ID == id); */

