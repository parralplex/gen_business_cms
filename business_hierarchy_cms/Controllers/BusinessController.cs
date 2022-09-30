using business_hierarchy_cms.Controllers.GenericController;
using business_hierarchy_cms.Services;
using business_hierarchy_cms.Services.Abstract;
using DomainModel.DTO;
using Microsoft.AspNetCore.Mvc;


namespace business_hierarchy_cms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessController : GenericController<BusinessDTO>
    {
        public BusinessController(ICRUDService<BusinessDTO> service) : base(service)
        {
        }

        [Route("ceo")]
        [HttpPost]
        public ActionResult MakeCeo(BusinessDTO dto, int employeeId)
        {
            ((BusinessUnitService)service).MakeLeaderOfThisUnit(dto.BusinessID, employeeId);
            return Ok();
        }

        [Route("ceo")]
        [HttpDelete]
        public ActionResult DeleteCeo(BusinessDTO dto)
        {
            ((BusinessUnitService)service).RemoveLeaderOfThisUnit(dto.BusinessID);
            return Ok();
        }
    }
}
