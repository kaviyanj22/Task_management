using Task_Management_System.DTOs;
using Task_Management_System.Models;

namespace Task_Management_System.Services.Interface
{
    public interface ITaskService
    {
        void CreateTask(CreateTaskItemDto dto);
        List<TaskItem> GetAllTasks();

        void Updatetask(int id, UpdateTaskItemDto dto);

        void DeleteTask(int id);

        List<TaskItemResponseDto> SearchTasks(string name);
        void ChangeStatus(int id, ChangeStatusDto dto);
    }
}
