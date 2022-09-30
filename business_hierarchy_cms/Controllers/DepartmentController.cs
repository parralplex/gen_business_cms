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
            var res = ((DepartmentService)service).MakeChief(dto.DepartmentId, employeeId);
            if (res)
                return Ok();
            return StatusCode(500);
        }

        [Route("chief")]
        [HttpDelete]
        public ActionResult DeleteChief(DepartmentDTO dto)
        {
            var res = ((DepartmentService)service).RemoveChief(dto.DepartmentId);
            if (res)
                return Ok();
            return StatusCode(500);
        }
    }
}
