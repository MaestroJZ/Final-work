using Application.DTOs;
using Domain.Models;

namespace Application.Services;

public interface IUserService : IBaseService<User, UserRequestDto>
{
    Task<UserResponseDto> Login(UserRequestDto userRequestDto);

    Task<User> Register(UserRequestDto userRequestDto);

}
