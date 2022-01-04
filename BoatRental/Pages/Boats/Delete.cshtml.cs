using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BoatRental.Data;
using BoatRental.Models;

namespace BoatRental.Pages.Boats
{
    public class DeleteModel : PageModel
    {
        private readonly BoatRental.Data.BoatRentalContext _context;

        public DeleteModel(BoatRental.Data.BoatRentalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Boat Boat { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Boat = await _context.Boat.FirstOrDefaultAsync(m => m.ID == id);

            if (Boat == null)
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

            Boat = await _context.Boat.FindAsync(id);

            if (Boat != null)
            {
                _context.Boat.Remove(Boat);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
