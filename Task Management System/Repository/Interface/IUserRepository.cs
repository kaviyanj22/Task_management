using Task_Management_System.DTOs;
using Task_Management_System.Models;

namespace Task_Management_System.Repositories
{
    public interface IUserRepository
    {
        void CreateUser(CreateUserDto dto);

        void AddUser(CreateUserDto dto);
        User GetUserById(int id);
        UserWithTasksDto GetUserWithTasks(int id);
        List<User> GetAllUsers();

        
        
    }
}