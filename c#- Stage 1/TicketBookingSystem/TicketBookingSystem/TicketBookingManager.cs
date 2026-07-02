using System;
using System.Collections.Generic;
using System.Text;

namespace TicketBookingSystem
{
    internal class TicketBookingManager
    {
        List<TicketBooking> list = new List<TicketBooking>();

        public void AddBooking(TicketBooking booking)
        {
            foreach (TicketBooking item in list)
            {
                if(item.BookingID == booking.BookingID)
                {
                    throw new Exception("Booking ID already exists");
                }
            }

            list.Add(booking);
            Console.WriteLine("Booking Confirm Successfully");
        }


        public void DisplayAllBookings()
        {
            if (list.Count == 0)
            {
                throw new Exception("No bookings available");
            }

            foreach(TicketBooking item in list)
            {
                item.DisplayDetails();
            }
        }


        public void DeleteBooking(int id)
        {
            foreach (TicketBooking item in list)
            {
                if (item.BookingID == id)
                {
                    list.Remove(item);
                    Console.WriteLine($"Booking with ID {id} cancelled successfully");
                }
            }

            throw new BookingNotFoundException($"No Booking found with ID {id}");
        }



    }
}
