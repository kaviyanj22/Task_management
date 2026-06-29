using Microsoft.Data.SqlClient;
using System.Xml.Linq;
using Task_Management_System.DTOs;
using Task_Management_System.Models;
using Task_Management_System.Repository.Interface;
namespace Task_Management_System.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly string _connectionString;

        public TaskRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void CreateTask(CreateTaskItemDto dto)
        {
            using SqlConnection con = new SqlConnection(_connectionString);

            string query = "select*from Tasks";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@Title", dto.Title);
            cmd.Parameters.AddWithValue("@Description", dto.Description);
            cmd.Parameters.AddWithValue("@Status", dto.Status);
            cmd.Parameters.AddWithValue("@UserId", dto.UserId);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        public List<TaskItem> GetAllTasks()
        {
            List<TaskItem> tasks = new();

            using SqlConnection con = new SqlConnection(_connectionString);

            string query = "SELECT * FROM Tasks";

            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                tasks.Add(new TaskItem
                {
                    TaskId = Convert.ToInt32(reader["TaskId"]),
                    Title = reader["Title"].ToString(),
                    Description = reader["Description"].ToString(),
                    status = reader["status"].ToString(),
                    UserId = Convert.ToInt32(reader["UserId"])
                });
            }

            return tasks;
        }

        public void Updatetask(int Id, UpdateTaskItemDto dto)
        {
            using SqlConnection con = new SqlConnection(_connectionString);

            string query = @"UPDATE Tasks
                     SET Title = @Title,
                         Description = @Description,
                         Status = @Status,
                         UserId = @UserId
                     WHERE TaskId = @Id";



            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@Title", dto.Title);
            cmd.Parameters.AddWithValue("@Description", dto.Description);
            cmd.Parameters.AddWithValue("@Status", dto.Status);
            cmd.Parameters.AddWithValue("@UserId", dto.UserId);

            con.Open();
            cmd.ExecuteNonQuery();
        }
        public void DeleteTask(int id)
        {
            using SqlConnection con = new SqlConnection(_connectionString);

            string query = "DELETE FROM Tasks WHERE TaskId= @Id";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@Id", id);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        public List<TaskItemResponseDto> SearchTasks(string name)
        {
            List<TaskItemResponseDto> tasks = new();

            using SqlConnection con = new SqlConnection(_connectionString);

            string query = @"
    SELECT t.TaskId,
           t.Title,
           t.Description,
           t.Status,
           t.CreatedDate,
           t.UserId,
           u.UserName
    FROM Tasks t
    INNER JOIN Users u
        ON t.UserId = u.UserId
    WHERE t.Title LIKE @Name";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@Name", "%" + name + "%");

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                tasks.Add(new TaskItemResponseDto
                {
                    TaskId = Convert.ToInt32(reader["TaskId"]),
                    Title = reader["Title"].ToString(),
                    Description = reader["Description"].ToString(),
                    Status = reader["Status"].ToString(),
                    UserId = Convert.ToInt32(reader["UserId"]),
                    UserName = reader["UserName"].ToString()
                });
            }

            return tasks;
        }

        public void ChangeStatus(int id, ChangeStatusDto dto)
        {
            using SqlConnection con = new SqlConnection(_connectionString);

            string query = @"UPDATE Tasks
                     SET Status = @Status
                     WHERE TaskId = @TaskId";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@TaskId", id);
            cmd.Parameters.AddWithValue("@Status", dto.Status);

            con.Open();

            int rows = cmd.ExecuteNonQuery();

            if (rows == 0)
            {
                throw new Exception("Task not found");
            }
        }

      

    }
}
