using business_hierarchy_cms.Services.Abstract;
using DomainModel.DTO;
using DomainModel.DTO.Abstract;
using DomainModel.Model;
using Infrastructure.UnitOfWork;

namespace business_hierarchy_cms.Services
{
    public class DepartmentService : GenericService<Department, DepartmentDTO>
    {
        private UnitOfWorkManager workManager;
        public DepartmentService(IUnitOfWork pWorkManager) : base(pWorkManager, ((UnitOfWorkManager)pWorkManager).DepartmentRepository)
        {
            workManager = (UnitOfWorkManager)pWorkManager;
        }

        protected override Department? FindByID(DepartmentDTO dto)
        {
            var departmentList = workManager.DepartmentRepository.Find(e => e.DepartmentId == dto.DepartmentId).ToList();
            if (departmentList.Count > 0)
            {
                return departmentList[0];
            }
            return null;
        }

        public bool MakeChief(int departmentId, int employeeId)
        {
            var department = FindByID(new DepartmentDTO() { DepartmentId = departmentId });
            if (department == null)
            {
                return false;
            }


            var employeeList = workManager.EmployeeRepository.Find(e => e.EmployeeId == employeeId).ToList();
            if (employeeList.Count == 0)
            {
                return false;
            }
            var employee = employeeList[0];

            if (department.Division.Business.BusinessId != employee.BusinessId)
            {
                return false;
            }

            if (department.DepartmentChief != null) 
            {
                workManager.DepartmentChiefRepository.Remove(department.DepartmentChief);
            }

            if (employee.Ceo != null)
            {
                workManager.CeoRepository.Remove(employee.Ceo);
            }
            if (employee.ProjectManager != null)
            {
                workManager.ProjectManagerRepository.Remove(employee.ProjectManager);
            }
            if (employee.Director != null)
            {
                workManager.DirectorRepository.Remove(employee.Director);
            }

            try
            {
                workManager.DepartmentChiefRepository.Insert(new DepartmentChief() { DepartmentId = departmentId, EmployeeId = employeeId });
                workManager.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool RemoveChief(int departmentId)
        {
            var department = workManager.DepartmentRepository.Find(e => e.DepartmentId == departmentId).ToList()[0];
            if (department.DepartmentChief == null)
            {
                return false;
            }

            try
            {
                workManager.DepartmentChiefRepository.Remove(department.DepartmentChief);
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
