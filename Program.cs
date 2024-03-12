using System;
using MySql.Data.MySqlClient;
using ScotRail;
using System.Collections.Generic;
class Program
{
    static async void Main()
    {
        string connectionString = "Server=127.0.0.1;Database=scotrail;User ID=root;Password=root;";
        MySqlDatabase database = new MySqlDatabase(connectionString);
        await MySqlDatabase.TestConnectionAsync();

         List<Seat> seats = new List<Seat>();
        for (int i = 0; i < 8; i++)
        {
            Seat seat = new Seat(i + 1);
            seats.Add(seat);
        }
        while (true) 
        {
            Console.WriteLine("1: Display Available Seats");
            Console.WriteLine("2: Booking");
            Console.WriteLine("3: Cancel Booking");
            Console.WriteLine("4: Exit");
            Console.WriteLine("Please Select an Option From 1-4:");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Display Available Seats
                    DisplayAvailableSeats(seats);
                    break;
                case "2":
                    // Booking
                    BookSeat(seats);
                    break;
                case "3":
                    // Cancel Booking
                    CancelBooking(seats);
                    break;
                case "4":
                    // Exit
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option. Please select again.");
                    break;
            }
        }
    }
    static void DisplayAvailableSeats(List<Seat> seats)
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
        // Implement booking logic here
    }

    static void CancelBooking(List<Seat> seats)
    {
        // Implement cancellation logic here
    }
}