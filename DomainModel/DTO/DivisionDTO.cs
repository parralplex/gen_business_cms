
using DomainModel.DTO.Abstract;
using DomainModel.Model;

namespace DomainModel.DTO
{
    public class DivisionDTO : IDTO<Division>
    {
        public int DivisionId { get; set; }
        public string Name { get; set; } = null!;
        public int BusinessId { get; set; }
        public string? Objective { get; set; }

        public override void CopyDataToEntity(Division oldEntity)
        {
            oldEntity.Name = Name;
            oldEntity.BusinessId = BusinessId;  
            oldEntity.Objective = Objective;
            oldEntity.DivisionId = DivisionId;
        }

        public override Division ToBaseEntity()
        {
            return new Division
            {
                DivisionId = DivisionId,
                Name = Name,
                BusinessId = BusinessId,
                Objective = Objective
            };
        }
    }
}
