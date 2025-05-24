using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectTracker.Core.DTOs.RoleDto;
using ProjectTracker.Core.Entities;
using ProjectTracker.Core.Interfaces.Services;

namespace ProjectTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public RoleController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _roleService.GetAllAsync();
            var map = _mapper.Map<List<RoleWithUsersDto>>(roles);
            return Ok(map);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleById(int id)
        {
            var role = await _roleService.GetByIdAsync(id);
            if (role == null)
            {
                return NotFound($"Role with ID {id} not found.");
            }

            return Ok(role);
        }

        [HttpPost]
        public async Task<IActionResult> AddRole([FromBody] CreateRoleDto createRoleDto)
        {
            if (createRoleDto == null)
            {
                return BadRequest("Invalid role data.");
            }

            var role = _mapper.Map<Role>(createRoleDto);
            await _roleService.AddAsync(role);
            return Ok($"{createRoleDto.Name} adlı rol eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleDto updateRoleDto)
        {
            if (updateRoleDto == null)
            {
                return BadRequest("Invalid role data.");
            }

            var role = _mapper.Map<Role>(updateRoleDto);
            await _roleService.UpdateAsync(role);
            return Ok($"{updateRoleDto.Name} adlı rol güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var role = await _roleService.GetByIdAsync(id);
            if (role == null)
            {
                return NotFound($"Role with ID {id} not found.");
            }

            await _roleService.DeleteAsync(id);
            return Ok($"Role with ID {id} deleted successfully.");

        }


    }
}
