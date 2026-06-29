using Microsoft.Data.SqlClient;
using Task_Management_System.DTOs;
using Task_Management_System.Models;
using Task_Management_System.Repositories;

namespace Task_Management_System.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public void CreateUser(CreateUserDto dto)
        {
            ArgumentNullException.ThrowIfNull(dto);
            if (string.IsNullOrWhiteSpace(dto.UserName))
            {
                throw new Exception("UserName is required");
            }

            if (string.IsNullOrWhiteSpace(dto.Email))
            {
                throw new Exception("Email is required");
            }

            _repository.CreateUser(dto);
        }

        public List<User> GetAllUsers()
        {
            return _repository.GetAllUsers();
        }

        public void AddUser(CreateUserDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.UserName))
            {
                throw new Exception("User Name is required");
            }

            if (string.IsNullOrWhiteSpace(dto.Email))
            {
                throw new Exception("Email is required");
            }

            _repository.AddUser(dto);
        }

        public User GetUserById(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Invalid User Id");
            }

            return _repository.GetUserById(id);
        }

        public UserWithTasksDto GetUserWithTasks(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Invalid User Id");
            }

            return _repository.GetUserWithTasks(id);
        }

    }
}