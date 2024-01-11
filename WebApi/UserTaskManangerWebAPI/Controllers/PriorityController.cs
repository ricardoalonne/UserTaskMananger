using Microsoft.AspNetCore.Mvc;
using UserTaskMananger.DTOs.Request;
using UserTaskMananger.Service.Structure;

namespace UserTaskManangerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriorityController : ControllerBase
    {
        private readonly IPriorityService _priorityService;

        public PriorityController(IPriorityService priorityService)
        {
            this._priorityService = priorityService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var priorities = await _priorityService.Get();

                if (priorities == null) return NoContent();

                return Ok(priorities);
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
                var priority = await _priorityService.FindById(id);

                if (priority == null) return NoContent();

                return Ok(priority);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PriorityRequest request)
        {
            try
            {
                var result = await _priorityService.Create(request);

                return result ? new ObjectResult(result) { StatusCode = StatusCodes.Status201Created } : BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] PriorityRequest request)
        {
            try
            {
                if (id <= 0) return new ObjectResult(id) { StatusCode = StatusCodes.Status304NotModified };

                var result = await _priorityService.Update(id, request);

                return result ? new ObjectResult(result) { StatusCode = StatusCodes.Status201Created } : BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id, [FromBody] PriorityRequest request)
        {
            try
            {
                var result = await _priorityService.Delete(id);

                return result ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
