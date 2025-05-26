
using ProjectTracker.Core.DTOs.UserDto;
using ProjectTracker.Core.Entities;

namespace ProjectTracker.Core.Interfaces.Services
{
    public interface IUserService : IService<User>
    {
        Task<List<User>> FindUser(FindUserDto userDto);
        Task<User?> AuthenticateAsync(string name, string surname, string mail);

    }
}
