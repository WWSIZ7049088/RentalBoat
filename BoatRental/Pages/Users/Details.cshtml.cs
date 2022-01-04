using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BoatRental.Data;
using BoatRental.Models;

namespace BoatRental.Pages.Users
{
    public class DetailsModel : PageModel
    {
        private readonly BoatRental.Data.BoatRentalContext _context;

        public DetailsModel(BoatRental.Data.BoatRentalContext context)
        {
            _context = context;
        }

        public User Users { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Users = await _context.Users.FirstOrDefaultAsync(m => m.ID == id);

            if (Users == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
