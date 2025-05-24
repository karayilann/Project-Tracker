namespace ProjectTracker.Core.DTOs.UserDtos;

public class UpdateUserDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Mail { get; set; }
    public int RoleId { get; set; }
}