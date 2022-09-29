using business_hierarchy_cms.Services.Abstract;
using DomainModel.DTO;
using DomainModel.Extensions;
using Infrastructure.UnitOfWork;

namespace business_hierarchy_cms.Services
{
    public class EmployeeService : ICRUDService<EmployeeDTO>
    {
        private UnitOfWorkManager workManager;
        public EmployeeService(IUnitOfWork pWorkManager)
        {
            workManager = (UnitOfWorkManager)pWorkManager;
        }

        public EmployeeDTO? FindByID(int id)
        {
            var employeeList = workManager.EmployeeRepository.Find(e => e.EmployeeId == id).ToList();
            if (employeeList.Count > 0)
            {
                return employeeList[0].ToBaseDTO();
            }
            return null;
        }

        public IEnumerable<EmployeeDTO> GetAll()
        {
            var employees = new HashSet<EmployeeDTO>();
            foreach (var employee in workManager.EmployeeRepository.GetAll())
            {
                employees.Add(employee.ToBaseDTO());
            }
            return employees;
        }

        public bool Insert(EmployeeDTO entity)
        {
            try
            {
                workManager.EmployeeRepository.Insert(entity.ToBaseEntity());
                workManager.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Remove(EmployeeDTO entity)
        {
            var employee = workManager.EmployeeRepository.Find(e => e.EmployeeId == entity.EmployeeId).ToList()[0];
            try
            {
                workManager.EmployeeRepository.Remove(employee);
                workManager.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Update(EmployeeDTO entity)
        {
            var employee = workManager.EmployeeRepository.Find(e => e.EmployeeId == entity.EmployeeId).ToList()[0];
            employee.BusinessId = entity.BusinessId;
            employee.EmployeeId = entity.EmployeeId;
            employee.FirstName = entity.FirstName;
            employee.LastName = entity.LastName;
            employee.PhoneNumber = entity.PhoneNumber;
            employee.Email = entity.Email;
            employee.Title = entity.Title;
            try
            {
                workManager.EmployeeRepository.Update(employee);
                workManager.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
