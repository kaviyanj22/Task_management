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

        public void AddUser(CreateUserDto dto)
        {
            using SqlConnection con = new SqlConnection(_connectionString);

            string query = @"INSERT INTO Users(UserName, Email)
                             VALUES(@UserName, @Email)";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@UserName", dto.UserName);
            cmd.Parameters.AddWithValue("@Email", dto.Email);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        public User GetUserById(int id)
        {
            User user = null;

            using SqlConnection con = new SqlConnection(_connectionString);

            string query = "SELECT * FROM Users WHERE UserId = @UserId";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@UserId", id);

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                user = new User
                {
                    UserId = Convert.ToInt32(reader["UserId"]),
                    UserName = reader["UserName"].ToString(),
                    Email = reader["Email"].ToString()
                };
            }

            return user;
        }

        public UserWithTasksDto GetUserWithTasks(int id)
        {
            UserWithTasksDto user = null;

            using SqlConnection con = new SqlConnection(_connectionString);

            string query = @"
        SELECT
            u.UserId,
            u.UserName,
            u.Email,
            t.TaskId,
            t.Title,
            t.Description,
            t.Status,
            t.CreatedDate
        FROM Users u
        LEFT JOIN Tasks t
            ON u.UserId = t.UserId
        WHERE u.UserId = @UserId";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@UserId", id);

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (user == null)
                {
                    user = new UserWithTasksDto
                    {
                        UserId = Convert.ToInt32(reader["UserId"]),
                        UserName = reader["UserName"].ToString(),
                        Email = reader["Email"].ToString(),
                        Tasks = new List<TaskItemResponseDto>()
                    };
                }

                if (reader["TaskId"] != DBNull.Value)
                {
                    user.Tasks.Add(new TaskItemResponseDto
                    {
                        TaskId = Convert.ToInt32(reader["TaskId"]),
                        Title = reader["Title"].ToString(),
                        Description = reader["Description"].ToString(),
                        Status = reader["Status"].ToString(),
                       // CreatedDate = reader["CreatedDate"].ToString()
                    });
                }
            }

            return user;
        }

    }
}