using Microsoft.Data.SqlClient;
using Task_Management_System.DTOs;
using Task_Management_System.Models;
using Task_Management_System.Repository.Interface;

namespace Task_Management_System.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString =
                configuration.GetConnectionString("DefaultConnection");
        }

        public void CreateUser(CreateUserDto dto)
        {
            using SqlConnection con =
                new SqlConnection(_connectionString);

            string query = @"INSERT INTO Users
                            (UserName, Email)
                            VALUES
                            (@UserName, @Email)";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@UserName", dto.UserName);
            cmd.Parameters.AddWithValue("@Email", dto.Email);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new();

            using SqlConnection con =
                new SqlConnection(_connectionString);

            string query = "SELECT * FROM Users";

            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                users.Add(new User
                {
                    UserId = Convert.ToInt32(reader["Id"]),
                    UserName = reader["UserName"].ToString(),
                    Email = reader["Email"].ToString()
                });
            }

            return users;
        }
    }
}