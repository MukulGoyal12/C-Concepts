using System.Xml.Linq;

namespace TicketBookingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TicketBookingManager bookTicket = new TicketBookingManager();
            bool cont = true;
            while (cont)
            {
                Console.WriteLine("Ticket Booking Menu");
                Console.WriteLine("1. Book Ticket");
                Console.WriteLine("2. Display All Bookings");
                Console.WriteLine("3. Cancel Booking");
                Console.WriteLine("4. Exit");
                Console.Write("Select Choice: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            try
                            {
                                Console.WriteLine("Enter BookingId:");
                                int BookingId = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter Customer Name:");
                                string CustomerName = Console.ReadLine();
                                Console.WriteLine("Enter Event Name:");
                                string EventName = Console.ReadLine();
                                Console.WriteLine("Enter Booking Date:");
                                string BookingDate = Console.ReadLine();
                                Console.WriteLine("Enter Contact Information:");
                                string ContactInfo = Console.ReadLine();
                                bookTicket.AddBooking(new TicketBooking(BookingId, CustomerName, EventName, BookingDate, ContactInfo)); ;
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;

                        case 2:
                            try
                            {
                                bookTicket.DisplayAllBookings(); ;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;

                        case 3:
                            try
                            {
                                Console.WriteLine("Enter BookingId:");
                                int BookingId = Convert.ToInt32(Console.ReadLine());
                                bookTicket.DeleteBooking(BookingId);
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;

                        case 4:
                            cont = false;
                            Console.WriteLine("Bye Bye Bhai");
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Please try again");
                            break;
                    }
                }
            }

        }
    }
}

