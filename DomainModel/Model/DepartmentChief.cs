
namespace DomainModel.Model
{
    public partial class DepartmentChief
    {
        public int DepartmentId { get; set; }
        public int EmployeeId { get; set; }

        public virtual Department Department { get; set; } = null!;
        public virtual Employee Employee { get; set; } = null!;
    }
}
