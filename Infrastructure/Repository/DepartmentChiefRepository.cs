using DomainModel.Model.Context;
using DomainModel.Model;
using Infrastructure.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class DepartmentChiefRepository : GenericRepository<DepartmentChief>
    {
        public DepartmentChiefRepository(BusinessModelContext context) : base(context) { }
    }
}

