namespace ProjectTracker.Core.DTOs.UserDtos;

public class CreateUserDto
{
    public string? Name { get; set; }
    public string Surname { get; set; }
    public string Mail { get; set; }
    public int RoleId { get; set; }
}