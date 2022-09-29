using DomainModel.DTO;
using DomainModel.Model;

namespace DomainModel.Extensions
{
    public static class BusinessExtensionMapper
    {
        public static BusinessDTO? ToBaseDTO(this Business bussiness)
        {
            if (bussiness != null)
            {
                return new BusinessDTO
                {
                    BusinessID = bussiness.BusinessId,
                    Name = bussiness.Name,
                    Description = bussiness.Description,
                };
            }
            return null;
        }

        public static Business? ToBaseEntity(this BusinessDTO bussiness)
        {
            if (bussiness != null)
            {
                return new Business
                {
                    BusinessId = bussiness.BusinessID,
                    Name = bussiness.Name,
                    Description = bussiness.Description,
                };
            }
            return null;
        }
    }
}
