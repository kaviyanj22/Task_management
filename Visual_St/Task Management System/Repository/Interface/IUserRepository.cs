using Task_Management_System.DTOs;
using Task_Management_System.Models;

namespace Task_Management_System.Repositories
{
    public interface IUserRepository
    {
        void CreateUser(CreateUserDto dto);
        List<User> GetAllUsers();
    }
}