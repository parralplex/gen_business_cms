
using DomainModel.DTO.Abstract;
using DomainModel.Model;

namespace DomainModel.DTO
{
    public class BusinessDTO : IDTO<Business>
    {
        public int BusinessID { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public override void CopyDataToEntity(Business oldEntity)
        {
            oldEntity.BusinessId = BusinessID;
            oldEntity.Name = Name;
            oldEntity.Description = Description;
        }

        public override Business ToBaseEntity()
        {
            return new Business
            {
                BusinessId = BusinessID,
                Name = Name,
                Description = Description,
            };
        }
    }
}
