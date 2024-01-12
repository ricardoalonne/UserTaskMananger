using Microsoft.AspNetCore.Mvc;
using UserTaskMananger.DTOs.Request;
using UserTaskMananger.Service.Structure;

namespace UserTaskManangerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTaskController : ControllerBase
    {
        private readonly IUserTaskService _userTaskService;

        public UserTaskController(IUserTaskService userTaskService)
        {
            this._userTaskService = userTaskService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var userTasks = await _userTaskService.Get();

                if (userTasks == null) return NoContent();

                return Ok(userTasks);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("total")]
        public async Task<IActionResult> GetTotal()
        {
            try
            {
                var total= await _userTaskService.GetTotal();

                return Ok(total);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var userTask = await _userTaskService.FindById(id);

                if (userTask == null) return NoContent();

                return Ok(userTask);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserTaskRequest request)
        {
            try
            {
                var result = await _userTaskService.Create(request);

                return result ? new ObjectResult(result) { StatusCode = StatusCodes.Status201Created } : BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UserTaskRequest request)
        {
            try
            {
                if (id <= 0) return new ObjectResult(id) { StatusCode = StatusCodes.Status304NotModified };

                var result = await _userTaskService.Update(id, request);

                return result ? new ObjectResult(result) { StatusCode = StatusCodes.Status201Created } : BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id, [FromBody] UserTaskRequest request)
        {
            try
            {
                var result = await _userTaskService.Delete(id);

                return result ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
