using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.Abstract
{
    public abstract class IDTO<TEntity> where TEntity : class
    {
         public abstract TEntity ToBaseEntity();
         public abstract void CopyDataToEntity(TEntity oldEntity);
    }
}
