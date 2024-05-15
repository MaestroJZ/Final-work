using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

//[Authorize]
public class VotersController(IVoterService service) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get(Guid id)
    {
        try
        {
            var candidate = await service.Get(id);
            
            return candidate == null ? ResponseNotFound() : ResponseOk(candidate);
        }
        catch (Exception ex)
        {
            return ResponseException(ex);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var candidates = await service.GetAll(x => x.IsDeleted == false);

            return ResponseOk(candidates);
        }
        catch (Exception ex)
        {
            return ResponseException(ex);
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] VoterDto dto)
    {
        try
        {
            var check = await service.GetAll(x => x.PhoneNumber == dto.PhoneNumber);
            
            if (check.Count == 0)
            {
                var id = await service.Add(dto);
                return ResponseOk(id);
            }

            var voter = check.First(x => x.PhoneNumber == dto.PhoneNumber);
            return ResponseOk(voter);
        }
        catch (Exception ex)
        {
            return ResponseException(ex);
        }
    }

    [Authorize]
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] VoterDto dto)
    {
        try
        {
            await service.Update(dto);
            
            return ResponseOk("Жаңартылды");
        }
        catch (Exception ex)
        {
            return ResponseException(ex);
        }
    }
    
    [Authorize]
    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            await service.Delete(id);
            
            return ResponseOk("Жойылды");
        }
        catch (Exception ex)
        {
            return ResponseException(ex);
        }
    }
}