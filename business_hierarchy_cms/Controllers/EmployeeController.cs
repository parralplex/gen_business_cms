using business_hierarchy_cms.Services.Abstract;
using business_hierarchy_cms.Services;
using DomainModel.DTO;
using Microsoft.AspNetCore.Mvc;
using business_hierarchy_cms.Controllers.GenericController;

namespace business_hierarchy_cms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : GenericController<EmployeeDTO>
    {
        public EmployeeController(ICRUDService<EmployeeDTO> service) : base(service)
        {
        }

        protected override int GetDTOID(EmployeeDTO dto)
        {
            return dto.EmployeeId;
        }
    }
}
