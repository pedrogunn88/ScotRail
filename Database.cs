using System;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace ScotRail
{
    public class MySqlDatabase
    {
        private readonly string _connectionString;

        public MySqlDatabase(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task TestConnectionAsync()
        {
            await using (var connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    Console.WriteLine("Connection opened successfully.");
                    // Perform database operations here
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"An error occurred while trying to open the MySQL connection: {ex.Message}");
                    // Handle exception
                }
            }
        }
    }
}
