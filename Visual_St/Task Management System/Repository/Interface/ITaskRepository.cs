using Task_Management_System.DTOs;
using Task_Management_System.Models;

namespace Task_Management_System.Repository.Interface
{
    public interface ITaskRepository
    {
        void CreateTask(CreateTaskItemDto dto);
        List<TaskItem> GetAllTasks();

        void Updatetask(int id,UpdateTaskItemDto dto);

        void DeleteTask(int id);

        List<TaskItemResponseDto> SearchTasks(string name);
    }
}
