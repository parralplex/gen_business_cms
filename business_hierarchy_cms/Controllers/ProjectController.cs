using business_hierarchy_cms.Services.Abstract;
using business_hierarchy_cms.Services;
using DomainModel.DTO;
using Microsoft.AspNetCore.Mvc;
using business_hierarchy_cms.Controllers.GenericController;

namespace business_hierarchy_cms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : GenericController<ProjectDTO>
    {
        public ProjectController(ICRUDService<ProjectDTO> service) : base(service)
        {
        }

        protected override int GetDTOID(ProjectDTO dto)
        {
            return dto.ProjectId;
        }

        [Route("projectManager")]
        [HttpPost]
        public ActionResult MakeProjectManager(ProjectDTO dto, int employeeId)
        {
            var businessEntity = ((ProjectService)service).FindByID(GetDTOID(dto));
            if (businessEntity == null)
                return NotFound();

            var res = ((ProjectService)service).MakeProjectManager(businessEntity.ProjectId, employeeId);
            if (res)
                return Ok();
            return StatusCode(500);
        }

        [Route("projectManager")]
        [HttpDelete]
        public ActionResult DeleteProjectManager(ProjectDTO dto)
        {
            var entity = service.FindByID(GetDTOID(dto));
            if (entity == null)
                return NotFound();

            var res = ((ProjectService)service).RemoveProjectManager(entity.ProjectId);
            if (res)
                return Ok();
            return StatusCode(500);
        }
    }
}
