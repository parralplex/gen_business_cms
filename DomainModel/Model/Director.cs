
namespace DomainModel.Model
{
    public partial class Director
    {
        public int DivisionId { get; set; }
        public int EmployeeId { get; set; }

        public virtual Division Division { get; set; } = null!;
        public virtual Employee Employee { get; set; } = null!;
    }
}
