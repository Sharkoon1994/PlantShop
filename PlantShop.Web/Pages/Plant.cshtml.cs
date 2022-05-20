using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlantShop.Api.Models;

namespace PlantShop.Web.Pages
{
    public class PlantModel : PageModel
    {
        private readonly Api.Data.PlantContext _context;

        public PlantModel(Api.Data.PlantContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Plant Plant { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
          {
              return Page();
          }

          _context.Plants.Add(Plant);
          await _context.SaveChangesAsync();

          return RedirectToPage("./Index");
        }
    }
}