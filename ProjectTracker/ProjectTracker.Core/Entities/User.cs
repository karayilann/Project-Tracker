using ProjectTracker.Core.Entities;

public class User
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Mail { get; set; }
    public int RoleId { get; set; }
    public Role? Role { get; set; }
    public List<WorkItem>? WorkItems { get; set; }
    public List<Project>? Projects { get; set; }
}