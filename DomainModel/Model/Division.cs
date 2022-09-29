
namespace DomainModel.Model
{
    public partial class Division
    {
        public Division()
        {
            Departments = new HashSet<Department>();
        }

        public int DivisionId { get; set; }
        public string Name { get; set; } = null!;
        public int BusinessId { get; set; }
        public string? Objective { get; set; }

        public virtual Business Business { get; set; } = null!;
        public virtual Director? Director { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
    }
}
