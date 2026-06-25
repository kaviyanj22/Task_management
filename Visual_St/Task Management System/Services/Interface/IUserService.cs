using Task_Management_System.DTOs;
using Task_Management_System.Models;

namespace Task_Management_System.Services
{
    public interface IUserService
    {
        void CreateUser(CreateUserDto dto);
        List<User> GetAllUsers();
    }
}