using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace business_hierarchy_cms.Services.Abstract
{
    public interface ICRUDService<TDTO> where TDTO : class
    {
        public void Insert(TDTO entity);
        public void Remove(TDTO entity);
        public void Update(TDTO entity);
    }
}
