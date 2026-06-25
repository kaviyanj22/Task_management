namespace Task_Management_System.Models
{
    public class TaskItem
    {
        public int TaskId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string status {  get; set; } = string.Empty;
        public string CreatedDate { get; set; } = string.Empty;
        public int UserId {  get; set; }
    }
}
