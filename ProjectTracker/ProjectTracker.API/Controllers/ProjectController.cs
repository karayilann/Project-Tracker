﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectTracker.Core.DTOs.ProjectDtos;
using ProjectTracker.Core.DTOs.UserDtos;
using ProjectTracker.Core.Entities;
using ProjectTracker.Core.Interfaces.Services;

namespace ProjectTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public ProjectController(IProjectService projectService, IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
        {
            var projects = await _projectService.GetAllAsync();
            var dto = _mapper.Map<List<GetProjectsDto>>(projects);
            return Ok(dto);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var project = await _projectService.GetByIdAsync(id);
            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> AddProject(CreateProjectDto createProjectDto)
        {
            var project = _mapper.Map<Project>(createProjectDto);

            if (createProjectDto.AssignedUserIds != null && createProjectDto.AssignedUserIds.Any())
            {
                var users = await _projectService.GetUsersByIdsAsync(createProjectDto.AssignedUserIds);
                project.AssignedUsers = users.ToList();
            }

            await _projectService.AddAsync(project);
            return Ok("Başarıyla Eklendi");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateProject(UpdateProjectDto updateProject)
        {
            var project = _mapper.Map<Project>(updateProject);
            await _projectService.UpdateAsync(project);
            return Ok("Proje güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProject(int id)
        {
            await _projectService.DeleteAsync(id);
            return Ok("Proje silindi");
        }

    }
}
