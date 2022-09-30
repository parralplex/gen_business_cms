
using DomainModel.Model;
using Infrastructure.UnitOfWork;

namespace Infrastructure
{
    public class GraphQLQuery
    {
        public IQueryable<Business> GetBusinesses([Service] IUnitOfWork context) =>
            ((UnitOfWorkManager)context).BusinessRepository.Query;        
        public IQueryable<Employee> GetEmployees([Service] IUnitOfWork context) =>
            ((UnitOfWorkManager)context).EmployeeRepository.Query;        
        public IQueryable<Division> GetDivisions([Service] IUnitOfWork context) =>
            ((UnitOfWorkManager)context).DivisionRepository.Query;
        public IQueryable<Department> GetDepartments([Service] IUnitOfWork context) =>
            ((UnitOfWorkManager)context).DepartmentRepository.Query;                
        public IQueryable<Project> GetProjects([Service] IUnitOfWork context) =>
            ((UnitOfWorkManager)context).ProjectRepository.Query;

    }
}
