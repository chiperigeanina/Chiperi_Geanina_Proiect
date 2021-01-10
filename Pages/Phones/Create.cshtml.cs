using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Chiperi_Geanina_Proiect.Data;
using Chiperi_Geanina_Proiect.Models;

namespace Chiperi_Geanina_Proiect.Pages.Phones
{
    public class CreateModel : PhoneCategoriesPageModel

    {
        private readonly Chiperi_Geanina_Proiect.Data.Chiperi_Geanina_ProiectContext _context;

        public CreateModel(Chiperi_Geanina_Proiect.Data.Chiperi_Geanina_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["BrandID"] = new SelectList(_context.Brand, "ID", "BrandName");
            var phone = new Phone();
            phone.PhoneCategories = new List<PhoneCategory>();
            PopulateAssignedCategoryData(_context, phone);
            return Page();
        }

        [BindProperty]
        public Phone Phone { get; set; }
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newPhone = new Phone();
            if (selectedCategories != null)
            {
                newPhone.PhoneCategories = new List<PhoneCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new PhoneCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newPhone.PhoneCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Phone>(
            newPhone,
            "Phone",
            i => i.Model, i => i.Type,
            i => i.Price, i => i.ReleaseDate, i => i.BrandID))
            {
                _context.Phone.Add(newPhone);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newPhone);
            return Page();
        }


        /* To protect from overposting attacks, enable the specific properties you want to bind to, for
         more details, see https://aka.ms/RazorPagesCRUD.
       public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Phone.Add(Phone);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        } */
    }
}
