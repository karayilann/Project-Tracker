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
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Role>> GetAllAsync()
        {
            var list = await _unitOfWork.Roles.GetAllWithIncludesAsync(x => x.AssignedUsers);
            return list;
        }

        public async Task<Role?> GetByIdAsync(int id)
        {
            return await _unitOfWork.Roles.GetByIdAsync(id);
        }

        public async Task<List<Role>> WhereAsync(Expression<Func<Role, bool>> expression)
        {
            return await _unitOfWork.Roles.WhereAsync(expression);
        }

        public async Task AddAsync(Role entity)
        {
            await _unitOfWork.Roles.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(Role entity)
        {
            _unitOfWork.Roles.Update(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.Roles.GetByIdAsync(id);
            if (entity != null)
            {
                _unitOfWork.Roles.Delete(entity);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
