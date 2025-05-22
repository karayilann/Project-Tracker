using ProjectTracker.Core.Entities;

public class User : BaseEntity
{
    public string Surname { get; set; }
    public string Mail { get; set; }
    public int RoleId { get; set; }
    public Role? Role { get; set; }
    public List<WorkItem>? WorkItems { get; set; } = new List<WorkItem>();
    public List<Project>? Projects { get; set; } = new List<Project>();
}