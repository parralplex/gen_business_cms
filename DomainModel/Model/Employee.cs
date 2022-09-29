
namespace DomainModel.Model
{
    public partial class Employee
    {
        public Employee()
        {
            Projects = new HashSet<Project>();
        }

        public int EmployeeId { get; set; }
        public int BusinessId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Title { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;

        public virtual Business Business { get; set; } = null!;
        public virtual Ceo? Ceo { get; set; }
        public virtual DepartmentChief? DepartmentChief { get; set; }
        public virtual Director? Director { get; set; }
        public virtual ProjectManager? ProjectManager { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
