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

        [Route("projectManager")]
        [HttpPost]
        public ActionResult MakeProjectManager(ProjectDTO dto, int employeeId)
        {
            var res = ((ProjectService)service).MakeProjectManager(dto.ProjectId, employeeId);
            if (res)
                return Ok();
            return StatusCode(500);
        }

        [Route("projectManager")]
        [HttpDelete]
        public ActionResult DeleteProjectManager(ProjectDTO dto)
        {
            var res = ((ProjectService)service).RemoveProjectManager(dto.ProjectId);
            if (res)
                return Ok();
            return StatusCode(500);
        }
    }
}
