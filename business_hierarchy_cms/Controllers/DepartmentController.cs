using business_hierarchy_cms.Services.Abstract;
using business_hierarchy_cms.Services;
using DomainModel.DTO;
using Microsoft.AspNetCore.Mvc;
using business_hierarchy_cms.Controllers.GenericController;

namespace business_hierarchy_cms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : GenericController<DepartmentDTO>
    {
        public DepartmentController(ICRUDService<DepartmentDTO> service) : base(service)
        {
        }


        [Route("chief")]
        [HttpPost]
        public ActionResult MakeChief(DepartmentDTO dto, int employeeId)
        {
            ((DepartmentService)service).MakeLeaderOfThisUnit(dto.DepartmentId, employeeId);
            return Ok();
        }

        [Route("chief")]
        [HttpDelete]
        public ActionResult DeleteChief(DepartmentDTO dto)
        {
            ((DepartmentService)service).RemoveLeaderOfThisUnit(dto.DepartmentId);
            return Ok();
        }
    }
}
