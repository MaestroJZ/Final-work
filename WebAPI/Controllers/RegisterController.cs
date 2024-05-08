using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class RegisterController(IVoterService service) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] VoterDto dto)
    {
        try
        {
            await service.Add(dto);
            
            return ResponseOk("Added");
        }
        catch (Exception ex)
        {
            return ResponseException(ex);
        }
    }
}