
namespace DomainModel.DTO
{
    public class DepartmentDTO
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; } = null!;
        public int DivisionId { get; set; }
        public string? Objective { get; set; }
    }
}
