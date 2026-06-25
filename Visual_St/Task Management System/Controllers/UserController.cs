using Microsoft.AspNetCore.Mvc;
using Task_Management_System.DTOs;
using Task_Management_System.Services;

namespace Task_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult CreateUser(CreateUserDto dto)
        {
            _service.CreateUser(dto);

            return Ok("User Created Successfully");
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(_service.GetAllUsers());
        }

      

    }
}