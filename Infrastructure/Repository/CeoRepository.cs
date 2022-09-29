using DomainModel.Model;
using DomainModel.Model.Context;
using Infrastructure.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class CeoRepository : GenericRepository<Ceo>
    {
        public CeoRepository(BusinessModelContext context) : base(context) { }
    }
}
