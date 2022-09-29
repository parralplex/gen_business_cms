using business_hierarchy_cms.Services.Abstract;
using business_hierarchy_cms.Services;
using DomainModel.DTO;
using Microsoft.AspNetCore.Mvc;

namespace business_hierarchy_cms.Controllers.GenericController
{
    public abstract class GenericController<DTO> : ControllerBase, ICRUDController<DTO> where DTO : class
    {
        protected readonly ICRUDService<DTO> service;
        public GenericController(ICRUDService<DTO> pservice)

        {
            service = pservice;
        }

        [Route("all")]
        [HttpGet]
        public IEnumerable<DTO> GetAll()
        {
            return service.GetAll();
        }

        [HttpGet]
        public ActionResult<DTO> Get(int id)
        {
            var dto = service.FindByID(id);
            if (dto == null)
                return NotFound();
            return dto;
        }

        [HttpPost]
        public ActionResult Insert(DTO dto)
        {
            var res = service.Insert(dto);
            if (res)
                return StatusCode(201, "DTO insert succesfull");
            return BadRequest("Insertion failed");
        }

        [HttpPut]
        public ActionResult Update(DTO dto)
        {
            var entity = service.FindByID(GetDTOID(dto));
            if (entity == null)
                return NotFound();

            var res = service.Update(entity);
            if (res)
                return Ok();
            return StatusCode(500);
        }

        [HttpDelete]
        public ActionResult Delete(DTO dto)
        {
            var entity = service.FindByID(GetDTOID(dto));
            if (entity == null)
                return NotFound();

            var res = service.Remove(entity);
            if (res)
                return Ok();
            return StatusCode(500);
        }

        protected abstract int GetDTOID(DTO dto);
    }
}
