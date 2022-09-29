using DomainModel.Model;
using DomainModel.Model.Context;
using Infrastructure.Repository.Abstract;

namespace Infrastructure.Repository
{
    public class DepartmentRepository : GenericRepository<Department>
    {
        public DepartmentRepository(BusinessModelContext context) : base(context) { }
    }
}
