
using ProjectTracker.Core.DTOs.UserDtos;
using ProjectTracker.Core.Entities;

namespace ProjectTracker.Core.Interfaces.Services
{
    public interface IUserService : IService<User>
    {
        User FindUser(UserSimpleDto userDto);
    }
}
