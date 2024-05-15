using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class UsersController(IUserService service) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Login(UserRequestDto userRequestDto)
    {
        try
        {
            var user = await service.Login(userRequestDto);
            
            return !string.IsNullOrEmpty(user.Token) ? ResponseOk(user.Token) : ResponseError("Сіз енгізген мәләметтер жоқ");
        }
        catch (Exception ex)
        {
            return ResponseException(ex);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] UserRequestDto userRequestDto)
    {
        try
        {
            var user = await service.Register(userRequestDto);
            
            if (user != null)
            {
                return ResponseOk("Сәтті");
            }

            return ResponseError("Қате");
        }
        catch (Exception ex)
        {
            return ResponseException(ex);
        }
    }
}