
namespace DomainModel.Model
{
    public partial class Department
    {
        public Department()
        {
            Projects = new HashSet<Project>();
        }

        public int DepartmentId { get; set; }
        public string Name { get; set; } = null!;
        public int DivisionId { get; set; }
        public string? Objective { get; set; }

        public virtual Division Division { get; set; } = null!;
        public virtual DepartmentChief? DepartmentChief { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
