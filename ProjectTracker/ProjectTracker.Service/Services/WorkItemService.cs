using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ProjectTracker.Core.Entities;
using ProjectTracker.Core.Interfaces.Services;
using ProjectTracker.Core.Interfaces.UnitOfWork;

namespace ProjectTracker.Service.Services
{
    public class WorkItemService : IWorkItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public WorkItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<WorkItem>> GetAllAsync()
        {
            return await _unitOfWork.WorkItem.GetAllWithIncludesAsync(x=> x.AssignedUser, x=> x.Project);
        }

        public async Task<WorkItem?> GetByIdAsync(int id)
        {
            var items = await _unitOfWork.WorkItem.GetAllWithIncludesAsync(x => x.Project, x => x.AssignedUser);
            return items.FirstOrDefault(x => x.Id == id);
        }

        public async Task<List<WorkItem>> WhereAsync(Expression<Func<WorkItem, bool>> expression)
        {
            return await _unitOfWork.WorkItem.WhereAsync(expression);
        }

        public async Task AddAsync(WorkItem entity)
        {
            await _unitOfWork.WorkItem.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(WorkItem entity)
        {
            _unitOfWork.WorkItem.Update(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.WorkItem.GetByIdAsync(id);
            if (entity != null)
            {
                _unitOfWork.WorkItem.Delete(entity);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
