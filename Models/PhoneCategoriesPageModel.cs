using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Chiperi_Geanina_Proiect.Data;

namespace Chiperi_Geanina_Proiect.Models
{
    public class PhoneCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Chiperi_Geanina_ProiectContext context,
        Phone phone)
        {
            var allCategories = context.Category;
            var phoneCategories = new HashSet<int>(
            phone.PhoneCategories.Select(c => c.PhoneID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = phoneCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdatePhoneCategories(Chiperi_Geanina_ProiectContext context,
        string[] selectedCategories, Phone phoneToUpdate)
        {
            if (selectedCategories == null)
            {
                phoneToUpdate.PhoneCategories = new List<PhoneCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var phoneCategories = new HashSet<int>
            (phoneToUpdate.PhoneCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!phoneCategories.Contains(cat.ID))
                    {
                        phoneToUpdate.PhoneCategories.Add(
                        new PhoneCategory
                        {
                            PhoneID = phoneToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (phoneCategories.Contains(cat.ID))
                    {
                        PhoneCategory courseToRemove
                        = phoneToUpdate
                        .PhoneCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }

        }
    }
}