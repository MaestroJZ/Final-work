using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class CandidatesController(ICandidateService service) : BaseController
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
    
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CandidateDto dto)
    {
        try
        {
            await service.Add(dto);
            
            return ResponseOk("Үміткер қосылды");
        }
        catch (Exception ex)
        {
            return ResponseException(ex);
        }
    }

    [Authorize]
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] CandidateDto dto)
    {
        try
        {
            await service.Update(dto);
            
            return ResponseOk("Үміткер жаңартылды");
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
            
            return ResponseOk("Үміткер жойылды");
        }
        catch (Exception ex)
        {
            return ResponseException(ex);
        }
    }
}