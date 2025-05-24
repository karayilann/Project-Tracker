using System.Linq.Expressions;
using ProjectTracker.Core.DTOs.UserDto;
using ProjectTracker.Core.DTOs.UserDtos;
using ProjectTracker.Core.Entities;
using ProjectTracker.Core.Interfaces.Services;
using ProjectTracker.Core.Interfaces.UnitOfWork;

namespace ProjectTracker.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _unitOfWork.Users.GetAllWithIncludesAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _unitOfWork.Users.GetByIdAsync(id);
        }

        public async Task<List<User>> WhereAsync(Expression<Func<User, bool>> expression)
        {
            return await _unitOfWork.Users.WhereAsync(expression);
        }

        public async Task AddAsync(User entity)
        {
           await _unitOfWork.Users.AddAsync(entity);
           await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(User entity)
        {
            _unitOfWork.Users.Update(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.Users.GetByIdAsync(id);
            if (entity != null)
            {
                _unitOfWork.Users.Delete(entity);
                await _unitOfWork.SaveChangesAsync();
            }
        }
        public async Task<List<User>> FindUser(FindUserDto userDto)
        {
            return await _unitOfWork.Users.GetAllWithIncludesAsync(
                u => u.Role,
                u => u.WorkItems,
                u => u.Projects
            ).ContinueWith(task =>
                task.Result
                    .Where(u => u.Name == userDto.Name && u.Surname == userDto.Surname)
                    .ToList()
            );
        }

    }
}
