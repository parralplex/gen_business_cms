
using DomainModel.DTO.Abstract;
using DomainModel.Model;

namespace DomainModel.DTO
{
    public class DepartmentDTO : IDTO<Department>
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; } = null!;
        public int DivisionId { get; set; }
        public string? Objective { get; set; }

        public override void CopyDataToEntity(Department oldEntity)
        {
            oldEntity.DepartmentId = DepartmentId;
            oldEntity.Name = Name;  
            oldEntity.Objective = Objective;
            oldEntity.DivisionId = DivisionId;
        }

        public override Department ToBaseEntity()
        {
            return new Department
            {
                DepartmentId = DepartmentId,
                Name = Name,
                DivisionId = DivisionId,
                Objective = Objective
            };
        }
    }
}
