
namespace DomainModel.Model
{
    public partial class Business
    {
        public Business()
        {
            Divisions = new HashSet<Division>();
            Employees = new HashSet<Employee>();
        }

        public int BusinessId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public virtual Ceo? Ceo { get; set; }
        public virtual ICollection<Division> Divisions { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
