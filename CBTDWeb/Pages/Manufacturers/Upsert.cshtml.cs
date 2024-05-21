using DataAccess;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CBTDWeb.Pages.Manufacturers
{
    public class UpsertModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;  //local instance of the database service

        [BindProperty]  //synchronizes form fields with values in code behind
        public Manufacturer objManufacturer { get; set; }

        public UpsertModel(UnitOfWork unitOfWork)  //dependency injection
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult OnGet(int? id)
        {
            objManufacturer = new Manufacturer();


            if (id != 0)
            {
                objManufacturer = _unitOfWork.Manufacturer.GetById(id);
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
                _unitOfWork.Manufacturer.Add(objManufacturer);
                TempData["success"] = "Manufacturer added Successfully";
            }
            else
            {
                _unitOfWork.Manufacturer.Update(objManufacturer);
                TempData["success"] = "Manufacturer updated Successfully";
            }
            _unitOfWork.Commit();

            return RedirectToPage("./Index");
        }



    }
}
