using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectTracker.Core.Entities;
using ProjectTracker.Core.Interfaces;
using ProjectTracker.Repository.Context;

namespace ProjectTracker.Service.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProjectService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Project>> GelAllAsync()
        {
            return await _unitOfWork.Projects.GetAllAsync();
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            return await _unitOfWork.Projects.GetByIdAsync(id);
        }

        public async Task AddAsync(Project project)
        {
            await _unitOfWork.Projects.AddAsync(project);
        }

        public async Task UpdateAsync(Project project)
        {
            _unitOfWork.Projects.Update(project);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.Projects.GetByIdAsync(id);
            if (entity != null)
            {
                _unitOfWork.Projects.Delete(entity);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
