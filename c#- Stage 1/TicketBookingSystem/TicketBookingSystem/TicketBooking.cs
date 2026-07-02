using System;
using System.Collections.Generic;
using System.Text;

namespace TicketBookingSystem
{
    internal class TicketBooking
    {
        internal int BookingID { get; set; }
        internal string CustomerName { get; set; }
        internal string EventName { get; set; }
        internal string BookingDate { get; set; }
        internal string ContactInfo { get; set; }

        public TicketBooking(int bookingId, string customerName, string eventName, string bookingDate, string contactInfo)
        {
            BookingID = bookingId;
            CustomerName = customerName;
            EventName = eventName;
            BookingDate = bookingDate;
            ContactInfo = contactInfo;
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Customer: {CustomerName}, ID: {BookingID}, Event: {EventName}, Date: {BookingDate}, Contact: {ContactInfo}");
        }

    }
}
