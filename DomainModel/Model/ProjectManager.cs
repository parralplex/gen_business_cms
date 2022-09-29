
namespace DomainModel.Model
{
    public partial class ProjectManager
    {
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; } = null!;
        public virtual Project Project { get; set; } = null!;
    }
}
