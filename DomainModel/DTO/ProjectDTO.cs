
using DomainModel.DTO.Abstract;
using DomainModel.Model;

namespace DomainModel.DTO
{
    public class ProjectDTO : IDTO<Project>
    {
        public int ProjectId { get; set; }
        public string Name { get; set; } = null!;
        public int DepartmentId { get; set; }
        public string ProductName { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime? FinishesAt { get; set; }
        public DateTime StartsAt { get; set; }

        public override void CopyDataToEntity(Project oldEntity)
        {
            oldEntity.ProjectId = ProjectId;
            oldEntity.Name = Name;
            oldEntity.DepartmentId = DepartmentId;
            oldEntity.ProductName = ProductName;
            oldEntity.Description = Description;
            oldEntity.FinishesAt = FinishesAt;
            oldEntity.StartsAt = StartsAt;
        }

        public override Project ToBaseEntity()
        {
            return new Project
            {
                ProjectId = ProjectId,
                Name = Name,
                DepartmentId = DepartmentId,
                ProductName = ProductName,
                Description = Description,
                FinishesAt = FinishesAt,
                StartsAt = StartsAt,
            };
        }
    }
}
