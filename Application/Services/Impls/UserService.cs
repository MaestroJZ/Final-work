using Application.DTOs;
using AutoMapper;
using Domain.Models;
using Infrastructure.DAO;
using Infrastructure.DAO.Repositories;
using Microsoft.Extensions.Configuration;

namespace Application.Services.Impls;

public class UserService : BaseService<User, UserRequestDto>, IUserService
{
    private readonly DataContext _context;
    private readonly IBaseRepository<User> _repository;
    private readonly IMapper _mapper;
    private string JwtKey;
    private readonly JwtService _jwtService;
    private readonly IHashPasswordService _hashPasswordService;

    public UserService(IBaseRepository<User> repository, IMapper mapper, IConfiguration configuration,
        IHashPasswordService hashPasswordService) : base(repository, mapper)
    {
        _repository = repository;
        _mapper = mapper;
        JwtKey = configuration.GetSection("JWTSettings:Key").Value;
        _jwtService = new JwtService(JwtKey);
        _hashPasswordService = hashPasswordService;
    }

    /// <inheritdoc/>
    public async Task<UserResponseDto> Login(UserRequestDto userRequestDto)
    {
        var user = await _repository.SelectFirst(u => u.Login == userRequestDto.Login);
        if (user != null)
        {
            var isPasswordValid = BCrypt.Net.BCrypt.Verify(userRequestDto.Password, user.HashPassword);
            if (isPasswordValid)
            {
                string token = _jwtService.GenerateToken(user.Login);
                UserResponseDto userResponseDto = new UserResponseDto()
                {
                    Token = token
                };
                return await Task.FromResult(userResponseDto);
            }
        }

        UserResponseDto notFound = new UserResponseDto()
        {
            Token = ""
        };
        return await Task.FromResult(notFound);
    }

    /// <inheritdoc/>
    public async Task<User> Register(UserRequestDto userRequestDto)
    {
        var user = await _repository.SelectFirst(u => u.Login == userRequestDto.Login);

        if (user == null)
        {
            var (hashedPassword, salt) = _hashPasswordService.HashPassword(userRequestDto.Password);
            var newUser = new User
            {
                Login = userRequestDto.Login,
                HashPassword = hashedPassword,
                Salt = salt
            };
            _repository.Insert(newUser);
            return await Task.FromResult(newUser);
        }

        return null;
    }
}