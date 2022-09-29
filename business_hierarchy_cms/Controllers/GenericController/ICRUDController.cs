using DomainModel.DTO;
using Microsoft.AspNetCore.Mvc;

namespace business_hierarchy_cms.Controllers.GenericController
{
    public interface ICRUDController<DTO>  where DTO : class
    {
        public IEnumerable<DTO> GetAll();

        public ActionResult<DTO> Get(int id);

        public ActionResult Insert(DTO dto);

        public ActionResult Update(DTO dto);

        public ActionResult Delete(DTO dto);

    }
}
