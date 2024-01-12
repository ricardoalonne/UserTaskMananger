using Microsoft.AspNetCore.Mvc;
using UserTaskMananger.DTOs.Request;
using UserTaskMananger.Service.Structure;

namespace UserTaskManangerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var users = await _userService.Get();

                if (users == null) return NoContent();

                return Ok(users);
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
                var total = await _userService.GetTotal();

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
                var user = await _userService.FindById(id);

                if (user == null) return NoContent();

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserRequest request)
        {
            try
            {
                var result = await _userService.Create(request);

                return result ? new ObjectResult(result) { StatusCode = StatusCodes.Status201Created } : BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UserRequest request)
        {
            try
            {
                if (id <= 0) return new ObjectResult(id) { StatusCode = StatusCodes.Status304NotModified };

                var result = await _userService.Update(id, request);

                return result ? new ObjectResult(result) { StatusCode = StatusCodes.Status201Created } : BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id, [FromBody] UserRequest request)
        {
            try
            {
                var result = await _userService.Delete(id);

                return result ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
