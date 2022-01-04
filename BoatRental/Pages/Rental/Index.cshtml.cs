using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BoatRental.Data;
using BoatRental.Models;

namespace BoatRental.Pages.Rental
{
    public class IndexModel : PageModel
    {
        public IEnumerable<Reservation> reservations { get; set; }
        public IEnumerable<User> user { get; set; }
        public IEnumerable<Boat> boat { get; set; }

        private readonly BoatRental.Data.BoatRentalContext _context;

        public IndexModel(BoatRental.Data.BoatRentalContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var reserverationViewModel = (from r in _context.Reservations
                                          join u in _context.Users on r.UserID equals u.ID
                                          join b in _context.Boat on r.BoatID equals b.ID
                                          select new {  u,b }).ToList();
            return Page();
        }

        [BindProperty]
        public Reservation Reservation { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Reservations.Add(Reservation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
