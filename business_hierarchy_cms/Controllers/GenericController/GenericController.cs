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

        [HttpPost]
        public ActionResult Insert(DTO dto)
        {
            try
            {
                service.Insert(dto);
                return StatusCode(201, "DTO insert succesfull");
            }
            catch (System.Web.Http.HttpResponseException exp)
            {
                switch (exp.Response.StatusCode)
                {
                    case System.Net.HttpStatusCode.NotFound:
                        return NotFound();
                    case System.Net.HttpStatusCode.InternalServerError:
                        return StatusCode(500, exp.Response.ReasonPhrase);
                }
            }
            return StatusCode(500, "Unknown server error");

        }

        [HttpPut]
        public ActionResult Update(DTO dto)
        {
            try
            {
                service.Update(dto);
                return Ok();
            }
            catch (System.Web.Http.HttpResponseException exp)
            {
                switch (exp.Response.StatusCode)
                {
                    case System.Net.HttpStatusCode.NotFound:
                        return NotFound();
                    case System.Net.HttpStatusCode.InternalServerError:
                        return StatusCode(500, exp.Response.ReasonPhrase);
                }
            }
            return StatusCode(500, "Unknown server error");
        }

        [HttpDelete]
        public ActionResult Delete(DTO dto)
        {
            try
            {
                service.Remove(dto);
                return Ok();
            }
            catch (System.Web.Http.HttpResponseException exp)
            {
                switch (exp.Response.StatusCode)
                {
                    case System.Net.HttpStatusCode.NotFound:
                        return NotFound();
                    case System.Net.HttpStatusCode.InternalServerError:
                        return StatusCode(500, exp.Response.ReasonPhrase);
                }
            }
            return StatusCode(500, "Unknown server error");
        }
    }
}
