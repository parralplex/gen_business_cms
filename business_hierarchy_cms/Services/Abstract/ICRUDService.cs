using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace business_hierarchy_cms.Services.Abstract
{
    public interface ICRUDService<TDTO> where TDTO : class
    {
        public TDTO? FindByID(int id);
        public bool Insert(TDTO entity);
        public bool Remove(TDTO entity);
        public bool Update(TDTO entity);
        public IEnumerable<TDTO> GetAll();
    }
}
