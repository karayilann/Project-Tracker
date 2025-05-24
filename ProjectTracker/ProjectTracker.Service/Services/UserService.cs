using System.Linq.Expressions;
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

        public Task<User?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> WhereAsync(Expression<Func<User, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public User FindUser(GetUserDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}
