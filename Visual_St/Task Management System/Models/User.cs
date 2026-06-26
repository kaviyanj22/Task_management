using Task_Management_System.DTOs;

namespace Task_Management_System.Models
{
    public class User
    {
        public int UserId { get; set; } 
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public List<TaskItemResponseDto> Tasks { get; set; }
    }
}









