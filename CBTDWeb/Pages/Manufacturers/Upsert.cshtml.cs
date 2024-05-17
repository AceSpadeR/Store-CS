using DataAccess;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CBTDWeb.Pages.Manufacturers
{
    public class UpsertModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]  
        public Manufacturer objManufacturer { get; set; }

        public UpsertModel(ApplicationDbContext db)  //dependency injection
        {
            _db = db;
        }

        public IActionResult OnGet(int? id)
        {
            objManufacturer = new Manufacturer();


            if (id != 0)
            {
                objManufacturer = _db.Manufacturers.Find(id);
            }

            if (objManufacturer == null)  
            {
                return NotFound();  
            }


            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (objManufacturer.Id == 0)
            {
                _db.Manufacturers.Add(objManufacturer);
                TempData["success"] = "Manufacturer added Successfully";
            }
            else
            {
                _db.Manufacturers.Update(objManufacturer);
                TempData["success"] = "Manufacturer updated Successfully";
            }
            _db.SaveChanges();

            return RedirectToPage("./Index");
        }



    }
}