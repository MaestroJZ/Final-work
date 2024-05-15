using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class BaseController : ControllerBase
{
    protected IActionResult ResponseException(Exception ex)
    {
        return StatusCode(500, $"Internal server error: {ex.Message}");
    }

    protected IActionResult ResponseOk(object data, bool successed = true)
    {
        var result = new { result = data, successed = successed };
        return Ok(result);
    }

    protected IActionResult ResponseNotFound(bool successed = false)
    {
        var result = new { result = "Ақпарат жоқ", successed = successed };
        return NotFound(result);
    }
    
    protected IActionResult ResponseError(object data, bool successed = false)
    {
        var result = new { result = data, successed = successed };
        return BadRequest(result);
    }
}
