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
            var businessEntity = ((BusinessUnitService)service).FindByID(GetDTOID(dto));
            if (businessEntity == null)
                return NotFound();

            var res = ((BusinessUnitService)service).MakeCeo(businessEntity.BusinessID, employeeId);
            if (res)
                return Ok();
            return StatusCode(500);
        }

        [Route("ceo")]
        [HttpDelete]
        public ActionResult DeleteCeo(BusinessDTO dto)
        {
            var entity = ((BusinessUnitService)service).FindByID(GetDTOID(dto));
            if (entity == null)
                return NotFound();

            var res = ((BusinessUnitService)service).RemoveCeo(entity.BusinessID);
            if (res)
                return Ok();
            return StatusCode(500);
        }

        protected override int GetDTOID(BusinessDTO dto)
        {
            return dto.BusinessID;
        }
    }
}
