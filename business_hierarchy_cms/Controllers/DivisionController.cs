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

        [Route("director")]
        [HttpPost]
        public ActionResult MakeDirector(DivisionDTO dto, int employeeId)
        {
            ((DivisionService)service).MakeLeaderOfThisUnit(dto.DivisionId, employeeId);
            return Ok();
        }

        [Route("director")]
        [HttpDelete]
        public ActionResult DeleteDirector(DivisionDTO dto)
        {
            ((DivisionService)service).RemoveLeaderOfThisUnit(dto.DivisionId);
            return Ok();
        }
    }
}
