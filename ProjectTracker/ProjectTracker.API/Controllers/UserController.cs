using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectTracker.Core.DTOs.UserDto;
using ProjectTracker.Core.DTOs.UserDtos;
using ProjectTracker.Core.Entities;
using ProjectTracker.Core.Interfaces.Services;

namespace ProjectTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllAsync();
            if (users == null || !users.Any())
            {
                return NotFound("No users found.");
            }

            var userDtos = _mapper.Map<List<UserSimpleDto>>(users);
            return Ok(userDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound($"User with ID {id} not found.");
            }

            var userDto = _mapper.Map<UserSimpleDto>(user);
            return Ok(userDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(CreateUserDto createUserDto)
        {
            if (createUserDto == null)
            {
                return BadRequest("Invalid user data.");
            }

            var user = _mapper.Map<User>(createUserDto);
            await _userService.AddAsync(user);
            return Ok($"{createUserDto.Name} adlı kullanıcı eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserDto updateUserDto)
        {
            if (updateUserDto == null)
            {
                return BadRequest("Invalid user data.");
            }

            var user = _mapper.Map<User>(updateUserDto);
            await _userService.UpdateAsync(user);
            return Ok($"{updateUserDto.Name} adlı kullanıcı güncellendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound($"User with ID {id} not found.");
            }

            await _userService.DeleteAsync(id);
            return Ok($"User with ID {id} deleted successfully.");
        }

        [HttpGet("Find")]
        public async Task<IActionResult> FindUser([FromQuery]FindUserDto userDto)
        {
            if (userDto == null || userDto.Name.Length <= 0)
            {
                return BadRequest("Invalid user data.");
            }

            var user = await _userService.FindUser(userDto);
            if (user == null)
            {
                return NotFound($"User with name {userDto.Name} not found.");
            }

            var userSimpleDtos = _mapper.Map<List<UserWithDetailsDto>>(user);
            return Ok(userSimpleDtos);


        }
    }
}