using business_hierarchy_cms.Services.Abstract;
using DomainModel.DTO;
using DomainModel.Extensions;
using DomainModel.Model;
using Infrastructure.UnitOfWork;

namespace business_hierarchy_cms.Services
{
    public class DepartmentService : ICRUDService<DepartmentDTO>
    {
        private UnitOfWorkManager workManager;
        public DepartmentService(IUnitOfWork pWorkManager)
        {
            workManager = (UnitOfWorkManager)pWorkManager;
        }
        public DepartmentDTO? FindByID(int id)
        {
            var departmentList = workManager.DepartmentRepository.Find(e => e.DepartmentId == id).ToList();
            if (departmentList.Count > 0)
            {
                return departmentList[0].ToBaseDTO();
            }
            return null;
        }
        public IEnumerable<DepartmentDTO> GetAll()
        {
            var departments = new HashSet<DepartmentDTO>();
            foreach (var department in workManager.DepartmentRepository.GetAll())
            {
                departments.Add(department.ToBaseDTO());
            }
            return departments;
        }

        public bool Insert(DepartmentDTO entity)
        {
            try
            {
                workManager.DepartmentRepository.Insert(entity.ToBaseEntity());
                workManager.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Remove(DepartmentDTO entity)
        {
            var department = workManager.DepartmentRepository.Find(e => e.DepartmentId == entity.DepartmentId).ToList()[0];
            try
            {
                workManager.DepartmentRepository.Remove(department);
                workManager.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Update(DepartmentDTO entity)
        {
            var department = workManager.DepartmentRepository.Find(e => e.DepartmentId == entity.DepartmentId).ToList()[0];
            department.DepartmentId = entity.DepartmentId;
            department.DivisionId = entity.DivisionId;
            department.Name = entity.Name;
            department.Objective = entity.Objective;
            try
            {
                workManager.DepartmentRepository.Update(department);
                workManager.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool MakeChief(int departmentId, int employeeId)
        {
            var department = workManager.DepartmentRepository.Find(e => e.DepartmentId == departmentId).ToList()[0];
            var empEntity = FindByID(employeeId);
            if (empEntity == null)
            {
                return false;
            }
            var employee = workManager.EmployeeRepository.Find(e => e.EmployeeId == employeeId).ToList()[0];

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
