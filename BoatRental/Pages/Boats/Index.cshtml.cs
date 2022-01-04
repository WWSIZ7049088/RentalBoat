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
    public class IndexModel : PageModel
    {
        private readonly BoatRental.Data.BoatRentalContext _context;

        public IndexModel(BoatRental.Data.BoatRentalContext context)
        {
            _context = context;
        }

        public IList<Boat> Boat { get;set; }

        public async Task OnGetAsync()
        {
            Boat = await _context.Boat.ToListAsync();
        }
    }
}
