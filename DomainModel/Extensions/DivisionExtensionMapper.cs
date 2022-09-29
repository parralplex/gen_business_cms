using DomainModel.DTO;
using DomainModel.Model;

namespace DomainModel.Extensions
{
    public static class DivisionExtensionMapper
    {
        public static DivisionDTO? ToBaseDTO(this Division division)
        {
            if (division != null)
            {
                return new DivisionDTO
                {
                    DivisionId = division.DivisionId,
                    Name = division.Name,
                    BusinessId = division.BusinessId,
                    Objective = division.Objective
                };
            }
            return null;
        }

        public static Division? ToBaseEntity(this DivisionDTO division)
        {
            if (division != null)
            {
                return new Division
                {
                    DivisionId = division.DivisionId,
                    Name = division.Name,
                    BusinessId = division.BusinessId,
                    Objective = division.Objective
                };
            }
            return null;
        }
    }
}
