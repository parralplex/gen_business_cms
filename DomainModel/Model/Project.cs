
namespace DomainModel.Model
{
    public partial class Project
    {
        public Project()
        {
            Employees = new HashSet<Employee>();
        }

        public int ProjectId { get; set; }
        public string Name { get; set; } = null!;
        public int DepartmentId { get; set; }
        public string ProductName { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime? FinishesAt { get; set; }
        public DateTime StartsAt { get; set; }

        public virtual Department Department { get; set; } = null!;
        public virtual ProjectManager? ProjectManager { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
