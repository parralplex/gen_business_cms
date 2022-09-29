
namespace DomainModel.Model
{
    public partial class Ceo
    {
        public int BusinessId { get; set; }
        public int EmployeeId { get; set; }

        public virtual Business Business { get; set; } = null!;
        public virtual Employee Employee { get; set; } = null!;
    }
}
