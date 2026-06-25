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

        

    }
}