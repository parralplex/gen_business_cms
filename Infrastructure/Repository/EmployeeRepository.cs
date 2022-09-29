using DomainModel.Model;
using DomainModel.Model.Context;
using Infrastructure.Repository.Abstract;

namespace Infrastructure.Repository
{
    public class EmployeeRepository : GenericRepository<Employee>
    {
        public EmployeeRepository(BusinessModelContext context) : base(context) { }
    }
}
