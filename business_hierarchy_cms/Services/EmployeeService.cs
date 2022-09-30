using business_hierarchy_cms.Services.Abstract;
using DomainModel.DTO;
using DomainModel.Model;
using Infrastructure.UnitOfWork;

namespace business_hierarchy_cms.Services
{
    public class EmployeeService : GenericService<Employee, EmployeeDTO>
    {
        private UnitOfWorkManager workManager;
        public EmployeeService(IUnitOfWork pWorkManager) : base(pWorkManager, ((UnitOfWorkManager)pWorkManager).EmployeeRepository)
        {
            workManager = (UnitOfWorkManager)pWorkManager;
        }

        protected override Employee? FindByID(EmployeeDTO dto)
        {
            var employeeList = workManager.EmployeeRepository.Find(e => e.EmployeeId == dto.EmployeeId).ToList();
            if (employeeList.Count > 0)
            {
                return employeeList[0];
            }
            return null;
        }
    }
}
