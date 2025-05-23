using Homework_Organizer.BLL.DTO;
using Homework_Organizer.BLL.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Homework_Organizer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeWorkController : ControllerBase
    {
        private readonly IHomeworkTaskService homeworkTaskService;

        public HomeWorkController(IHomeworkTaskService homeworkTaskService)
        {
            this.homeworkTaskService = homeworkTaskService;
        }
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] HomeworkDto homeworkDto)
        {
            var result = await homeworkTaskService.Create(homeworkDto);
            if (result.Item1)
                return Ok(new
                {
                    Message = "Task Created Successfully",
                    Data = homeworkDto
                });
            return BadRequest(result.Item2);
        }
        [HttpPost("complete/{id}")]
        public async Task<IActionResult> Complete(int id)
        {
            var (Success, ErrorMessage) = await homeworkTaskService.Complete(id);
            if (Success)
                return Ok("Task Marked as completed");
            return BadRequest(ErrorMessage);

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var tasks =  homeworkTaskService.GetAll();
                return Ok(tasks);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
