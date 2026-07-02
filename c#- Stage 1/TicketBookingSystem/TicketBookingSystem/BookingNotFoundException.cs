using System;
using System.Collections.Generic;
using System.Text;

namespace TicketBookingSystem
{
    internal class BookingNotFoundException:Exception
    {

        public BookingNotFoundException(string message) : base(message) { }
    }
}
