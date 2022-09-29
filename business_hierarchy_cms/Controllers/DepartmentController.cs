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

        protected override int GetDTOID(DepartmentDTO dto)
        {
            return dto.DepartmentId;
        }

        [Route("chief")]
        [HttpPost]
        public ActionResult MakeChief(DepartmentDTO dto, int employeeId)
        {
            var businessEntity = ((DepartmentService)service).FindByID(GetDTOID(dto));
            if (businessEntity == null)
                return NotFound();

            var res = ((DepartmentService)service).MakeChief(businessEntity.DepartmentId, employeeId);
            if (res)
                return Ok();
            return StatusCode(500);
        }

        [Route("chief")]
        [HttpDelete]
        public ActionResult DeleteChief(DepartmentDTO dto)
        {
            var entity = service.FindByID(GetDTOID(dto));
            if (entity == null)
                return NotFound();

            var res = ((DepartmentService)service).RemoveChief(entity.DepartmentId);
            if (res)
                return Ok();
            return StatusCode(500);
        }
    }
}
