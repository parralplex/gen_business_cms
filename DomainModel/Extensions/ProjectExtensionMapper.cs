using DomainModel.DTO;
using DomainModel.Model;

namespace DomainModel.Extensions
{
    public static class ProjectExtensionMapper
    {
        public static ProjectDTO? ToBaseDTO(this Project project)
        {
            if (project != null)
            {
                return new ProjectDTO
                {
                    ProjectId = project.ProjectId,
                    Name = project.Name,
                    DepartmentId = project.DepartmentId,
                    ProductName = project.ProductName,
                    Description = project.Description,
                    FinishesAt = project.FinishesAt,
                    StartsAt = project.StartsAt,
                };
            }
            return null;
        }

        public static Project? ToBaseEntity(this ProjectDTO project)
        {
            if (project != null)
            {
                return new Project
                {
                    ProjectId = project.ProjectId,
                    Name = project.Name,
                    DepartmentId = project.DepartmentId,
                    ProductName = project.ProductName,
                    Description = project.Description,
                    FinishesAt = project.FinishesAt,
                    StartsAt = project.StartsAt,
                };
            }
            return null;
        }
    }
}
