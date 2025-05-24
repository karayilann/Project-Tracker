using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectTracker.Core.DTOs.WorkItemDto;
using ProjectTracker.Core.Entities;
using ProjectTracker.Core.Interfaces.Services;

namespace ProjectTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkItemController : ControllerBase
    {
        private readonly IWorkItemService _workItemService;
        private readonly IMapper _mapper;

        public WorkItemController(IWorkItemService workItemService, IMapper mapper)
        {
            _workItemService = workItemService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllWorkItems()
        {
            var workItems = await _workItemService.GetAllAsync();
            if (workItems == null || !workItems.Any())
            {
                return NotFound("No work items found.");
            }

            var workItemDtos = _mapper.Map<List<WorkItemDto>>(workItems);
            return Ok(workItemDtos);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkItemById(int id)
        {
            var workItem = await _workItemService.GetByIdAsync(id);
            if (workItem == null)
            {
                return NotFound($"Work item with ID {id} not found.");
            }

            var workItemDto = _mapper.Map<WorkItemDto>(workItem);
            return Ok(workItemDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddWorkItem(CreateWorkItemDto createWorkItemDto)
        {
            if (createWorkItemDto == null)
            {
                return BadRequest("Invalid work item data.");
            }

            var workItem = _mapper.Map<WorkItem>(createWorkItemDto);
            await _workItemService.AddAsync(workItem);
            return Ok($"{createWorkItemDto.Name} adlı iş öğesi eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWorkItem([FromBody] UpdateWorkItemDto updateWorkItemDto)
        {
            if (updateWorkItemDto == null)
            {
                return BadRequest("Invalid work item data.");
            }

            var workItem = _mapper.Map<WorkItem>(updateWorkItemDto);

            if (updateWorkItemDto.AssignedUserId.HasValue)
            {
                workItem.AssignedUserId = updateWorkItemDto.AssignedUserId.Value;
            }
            else
            {
                workItem.AssignedUserId = null;
                workItem.AssignedUser = null;
            }

            await _workItemService.UpdateAsync(workItem);
            return Ok($"{updateWorkItemDto.Name} adlı iş öğesi güncellendi.");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkItem(int id)
        {
            var workItem = await _workItemService.GetByIdAsync(id);
            if (workItem == null)
            {
                return NotFound($"Work item with ID {id} not found.");
            }

            await _workItemService.DeleteAsync(id);
            return Ok($"Work item with ID {id} deleted successfully.");
        }

    }

}