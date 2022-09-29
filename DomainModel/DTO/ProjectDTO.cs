
namespace DomainModel.DTO
{
    public class ProjectDTO
    {
        public int ProjectId { get; set; }
        public string Name { get; set; } = null!;
        public int DepartmentId { get; set; }
        public string ProductName { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime? FinishesAt { get; set; }
        public DateTime StartsAt { get; set; }
    }
}
