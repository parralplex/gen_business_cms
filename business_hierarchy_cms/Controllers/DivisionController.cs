using business_hierarchy_cms.Services.Abstract;
using business_hierarchy_cms.Services;
using DomainModel.DTO;
using Microsoft.AspNetCore.Mvc;
using business_hierarchy_cms.Controllers.GenericController;
using DomainModel.Model;

namespace business_hierarchy_cms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisionController : GenericController<DivisionDTO>
    {
        public DivisionController(ICRUDService<DivisionDTO> service) : base(service)
        {
        }

        protected override int GetDTOID(DivisionDTO dto)
        {
            return dto.DivisionId;
        }

        [Route("director")]
        [HttpPost]
        public ActionResult MakeDirector(DivisionDTO dto, int employeeId)
        {
            var businessEntity = ((DivisionService)service).FindByID(GetDTOID(dto));
            if (businessEntity == null)
                return NotFound();

            var res = ((DivisionService)service).MakeDirector(businessEntity.DivisionId, employeeId);
            if (res)
                return Ok();
            return StatusCode(500);
        }

        [Route("director")]
        [HttpDelete]
        public ActionResult DeleteDirector(DivisionDTO dto)
        {
            var entity = service.FindByID(GetDTOID(dto));
            if (entity == null)
                return NotFound();

            var res = ((DivisionService)service).RemoveDirector(entity.DivisionId);
            if (res)
                return Ok();
            return StatusCode(500);
        }
    }
}
