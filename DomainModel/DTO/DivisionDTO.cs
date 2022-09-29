
namespace DomainModel.DTO
{
    public class DivisionDTO
    {
        public int DivisionId { get; set; }
        public string Name { get; set; } = null!;
        public int BusinessId { get; set; }
        public string? Objective { get; set; }
    }
}
