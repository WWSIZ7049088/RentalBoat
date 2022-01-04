using BoatRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoatRental.Data
{
    public static class DbInitializer
    {
        public static void Initialize(BoatRentalContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var users = new User[]
            {
                new User { FirstName = "Piotr", LastName="Uba", PhoneNumber=123456789, EmailAddress="maniek@cos.cos"},
                new User { FirstName = "Jan", LastName="Kowalski", PhoneNumber=55959595, EmailAddress="brak@cos.cos"},
                new User { FirstName = "Robert", LastName="Kubica", PhoneNumber=123456789, EmailAddress="bob@cos.cos"},
            };

            context.Users.AddRange(users);
            context.SaveChanges();

            var boat = new Boat[]
            {
                new Boat { BoatName="Santa Maria", BoatType="środlądowa"},
                new Boat { BoatName="Extazy", BoatType="Imprezowa"}
            };

            context.Boat.AddRange(boat);
            context.SaveChanges();

            var reservation = new Reservation[]
            {
                new Reservation { UserID = 1, BoatID = 1},
                new Reservation { UserID = 2, BoatID =2 }
            };

            context.Reservations.AddRange(reservation);
            context.SaveChanges();
        }
    }
}
