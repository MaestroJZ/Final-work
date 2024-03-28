using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class BaseController : ControllerBase
{
    /// <summary>
    /// Обработка исключений и возврат соответствующего HTTP-ответа.
    /// </summary>
    /// <param name="ex">Исключение.</param>
    /// <returns>HTTP-ответ с кодом 500 и сообщением об ошибке.</returns>
    protected IActionResult ResponseException(Exception ex)
    {
        return StatusCode(500, $"Internal server error: {ex.Message}");
    }

    /// <summary>
    /// Формирование успешного HTTP-ответа.
    /// </summary>
    /// <param name="data">Данные для возврата.</param>
    /// <param name="successed">Признак успешности операции (по умолчанию true).</param>
    /// <returns>HTTP-ответ с кодом 200 и указанными данными.</returns>
    protected IActionResult ResponseOk(object data, bool successed = true)
    {
        var result = new { result = data, successed = successed };
        return Ok(result);
    }

    /// <summary>
    /// Формирование HTTP-ответа с кодом 404 Not Found.
    /// </summary>
    /// <param name="data">Данные для возврата.</param>
    /// <param name="successed">Признак успешности операции (по умолчанию false).</param>
    /// <returns>HTTP-ответ с кодом 404 и указанными данными.</returns>
    protected IActionResult ResponseNotFound(bool successed = false)
    {
        var result = new { result = "No Data", successed = successed };
        return NotFound(result);
    }
    protected IActionResult ResponseUnauthorized(bool successed = false)
    {
        var result = new { result = "User unauthorized", successed = successed };
        return Unauthorized(result);
    }
}
