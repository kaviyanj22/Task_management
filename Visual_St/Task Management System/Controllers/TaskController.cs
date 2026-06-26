using Microsoft.AspNetCore.Mvc;
using Task_Management_System.DTOs;
using Task_Management_System.Services;
using Task_Management_System.Services.Interface;

namespace Task_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _service;

        public TasksController(ITaskService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult CreateTask(CreateTaskItemDto dto)
        {
            _service.CreateTask(dto);

            return Ok("Task Created Successfully");
        }

        [HttpGet]
        public IActionResult GetAllTasks()
        {
            return Ok(_service.GetAllTasks());
        }

        [HttpPut("{id}")]
        public IActionResult Updatetask(int id, UpdateTaskItemDto dto)
        {
            try
            {
                _service.Updatetask(id, dto);

                return Ok("Task Updated Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            try
            {
                _service.DeleteTask(id);

                return Ok("Task Deleted Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("search")]
        public IActionResult SearchTasks(string name)
        {
            return Ok(_service.SearchTasks(name));
        }

        [HttpPut("{id}/status")]
        public IActionResult ChangeStatus(int id, ChangeStatusDto dto)
        {
            try
            {
                _service.ChangeStatus(id, dto);

                return Ok("Task Status Updated Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

       

    }

}