using Microsoft.Data.SqlClient;
using Task_Management_System.DTOs;
using Task_Management_System.Models;
using Task_Management_System.Repository.Interface;
using Task_Management_System.Services.Interface;

namespace Task_Management_System.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public void CreateTask(CreateTaskItemDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Title))
            {
                throw new Exception("Title is required");
            }

            if (string.IsNullOrWhiteSpace(dto.Description))
            {
                throw new Exception("Description is required");
            }

            if (string.IsNullOrWhiteSpace(dto.Status))
            {
                throw new Exception("Status is required");
            }

            if (dto.UserId <= 0)
            {
                throw new Exception("Invalid User Id");
            }

            _repository.CreateTask(dto);
        }

        public List<TaskItem> GetAllTasks()
        {
            return _repository.GetAllTasks();
       
        }

        public void Updatetask(int id, UpdateTaskItemDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Title))
            {
                throw new Exception("Title is required");
            }

            if (string.IsNullOrWhiteSpace(dto.Description))
            {
                throw new Exception("Description is required");
            }

            if (string.IsNullOrWhiteSpace(dto.Status))
            {
                throw new Exception("Status is required");
            }

            if (dto.UserId <= 0)
            {
                throw new Exception("Invalid User Id");
            }

            _repository.Updatetask(id,dto);
        }

        public void DeleteTask(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Invalid Task Id");
            }

            _repository.DeleteTask(id);
        }

        public List<TaskItemResponseDto> SearchTasks(string name)
        {
            return _repository.SearchTasks(name);
        }

    }

}