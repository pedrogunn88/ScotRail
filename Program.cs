using System;
using MySql.Data.MySqlClient;
using ScotRail;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScotRail
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string connectionString = "Server=127.0.0.1;Database=scotrail;User ID=root;Password=root;";
            MySqlDatabase database = new MySqlDatabase(connectionString);
      await database.TestConnectionAsync();

            List<Seat> seats = new List<Seat>();
            for (int i = 0; i < 8; i++)
            {
                Seat seat = new Seat(i + 1);
                seats.Add(seat);
            }
            while (true)
            {
                Console.WriteLine("1: Seat Availibility");
                Console.WriteLine("2: Booking");
                Console.WriteLine("3: Cancel Booking");
                Console.WriteLine("4: Exit");
                Console.WriteLine("Please Select an Option From 1-4:");

                string choice = Console.ReadLine();
       switch (choice)
                {
                    case "1":
                        availableSeats(seats);
                        break;
                    case "2":
                        BookSeat(seats);
                        break;
                    case "3":
                        CancelBooking(seats);
                        break;
                    case "4":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please select again.");
                        break;
                }
            }
        }
        static void availableSeats(List<Seat> seats)
        {
            Console.WriteLine("Available Seats:");
            foreach (var seat in seats)
            {
                if (seat.Occupant == null)
                {
                Console.WriteLine($"Seat {seat.SeatNumber} is available.");
                }
            }
        }
        static void BookSeat(List<Seat> seats)
        {
            Console.WriteLine("Enter the seat number you wish to book:");
            if (!int.TryParse(Console.ReadLine(), out int seatNo) || seatNo < 1 || seatNo > seats.Count)
            {
                Console.WriteLine("Invalid seat number.");
                return;
            }
            Seat seatToBook = seats[seatNo - 1];
            if (seatToBook.Occupant != null)
            {
        Console.WriteLine($"Seat {seatNo} is already booked.");
            return;
            }
            Console.WriteLine("Please enter your name:");
       string custName = Console.ReadLine();
          Console.WriteLine("Please enter your email address:");
           string custEmail = Console.ReadLine();
           Customer customer = new OrdinaryPassenger(custName, custEmail);
            string connectionString = "Server=127.0.0.1;Database=scotrail;User ID=root;Password=root;";
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO booking (customer_id, seat_id, date, price) VALUES (@CustomerId, @SeatId, @Date, @Price)";
                    command.Parameters.AddWithValue("@CustomerId", 1); 
                    command.Parameters.AddWithValue("@SeatId", seatNo); 
                    command.Parameters.AddWithValue("@Date", DateTime.Now); 
                    command.Parameters.AddWithValue("@Price", 10.00); 
                    command.ExecuteNonQuery();
                }
            }
            seatToBook.Occupant = customer;
            Console.WriteLine($"Seat {seatNo} booked successfully for {custName}.");
        }
        static void CancelBooking(List<Seat> seats)
        {
            Console.WriteLine("Enter seat number to cancel booking:");
            if (!int.TryParse(Console.ReadLine(), out int cancelSeat) || cancelSeat < 1 || cancelSeat > seats.Count)
            {
               Console.WriteLine("Invalid seat number.");
                return;
            }
         Seat seatToCancel = seats[cancelSeat - 1];
         if (seatToCancel.Occupant == null)
            {
                Console.WriteLine($"Seat {cancelSeat} is not booked.");
                return;
            }
            string customerName = seatToCancel.Occupant.Name;
            seatToCancel.Occupant = null;
     Console.WriteLine($"Booking for seat {cancelSeat} for customer {customerName} cancelled successfully.");
        }
    }
}