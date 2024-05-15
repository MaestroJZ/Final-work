using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;


public class ElectionsController(IElectionService service) : BaseController
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
    
    [HttpGet]
    public async Task<IActionResult> GetActiveElections()
    {
        try
        {
            var candidates = await service.GetAll(
                x => x.IsDeleted == false
                && x.EndDate > DateTime.UtcNow);

            return ResponseOk(candidates);
        }
        catch (Exception ex)
        {
            return ResponseException(ex);
        }
    }
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] ElectionDto dto)
    {
        try
        {
            await service.Add(dto);
            
            return ResponseOk("Сайлау қосылды");
        }
        catch (Exception ex)
        {
            return ResponseException(ex);
        }
    }
    [Authorize]
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] ElectionDto dto)
    {
        try
        {
            await service.Update(dto);
            
            return ResponseOk("Сайлау жаңартылды");
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
            
            return ResponseOk("Сайлау жойылды");
        }
        catch (Exception ex)
        {
            return ResponseException(ex);
        }
    }
}