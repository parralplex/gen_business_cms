using DomainModel.DTO;
using DomainModel.Model;

namespace DomainModel.Extensions
{
    public static class DepartmentExtensionMapper
    {
        public static DepartmentDTO? ToBaseDTO(this Department department)
        {
            if (department != null)
            {
                return new DepartmentDTO
                {
                    DepartmentId = department.DepartmentId,
                    Name = department.Name,
                    DivisionId = department.DivisionId,
                    Objective = department.Objective
                };
            }
            return null;
        }

        public static Department? ToBaseEntity(this DepartmentDTO department)
        {
            if (department != null)
            {
                return new Department
                {
                    DepartmentId = department.DepartmentId,
                    Name = department.Name,
                    DivisionId = department.DivisionId,
                    Objective = department.Objective
                };
            }
            return null;
        }
    }
}
