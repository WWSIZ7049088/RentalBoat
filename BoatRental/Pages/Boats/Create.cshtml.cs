using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BoatRental.Data;
using BoatRental.Models;

namespace BoatRental.Pages.Boats
{
    public class CreateModel : PageModel
    {
        private readonly BoatRental.Data.BoatRentalContext _context;

        public CreateModel(BoatRental.Data.BoatRentalContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Boat Boat { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Boat.Add(Boat);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
