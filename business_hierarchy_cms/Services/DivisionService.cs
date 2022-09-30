using business_hierarchy_cms.Services.Abstract;
using DomainModel.DTO;
using DomainModel.Model;
using Infrastructure.UnitOfWork;

namespace business_hierarchy_cms.Services
{
    public class DivisionService : GenericService<Division, DivisionDTO>
    {
        private UnitOfWorkManager workManager;
        public DivisionService(IUnitOfWork pWorkManager) : base(pWorkManager, ((UnitOfWorkManager)pWorkManager).DivisionRepository)
        {
            workManager = (UnitOfWorkManager)pWorkManager;
        }
        protected override Division? FindByID(DivisionDTO dto)
        {
            var divisionList = workManager.DivisionRepository.Find(e => e.DivisionId == dto.DivisionId).ToList();
            if (divisionList.Count > 0)
            {
                return divisionList[0];
            }
            return null;
        }

        public bool MakeDirector(int divisionId, int employeeId)
        {
            var division = FindByID(new DivisionDTO() { DivisionId = divisionId });
            if (division == null)
            {
                return false;
            }


            var employeeList = workManager.EmployeeRepository.Find(e => e.EmployeeId == employeeId).ToList();
            if (employeeList.Count == 0)
            {
                return false;
            }
            var employee = employeeList[0];

            if (division.Business.BusinessId != employee.BusinessId)
            {
                return false;
            }

            if (division.Director != null)
            {
                workManager.DirectorRepository.Remove(division.Director);
            }

            if (employee.Ceo != null)
            {
                workManager.CeoRepository.Remove(employee.Ceo);
            }
            if (employee.ProjectManager != null)
            {
                workManager.ProjectManagerRepository.Remove(employee.ProjectManager);
            }
            if (employee.DepartmentChief != null)
            {
                workManager.DepartmentChiefRepository.Remove(employee.DepartmentChief);
            }

            try
            {
                workManager.DirectorRepository.Insert(new Director() { DivisionId = divisionId, EmployeeId = employeeId });
                workManager.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool RemoveDirector(int divisionId)
        {
            var division = workManager.DivisionRepository.Find(e => e.DivisionId == divisionId).ToList()[0];
            if (division.Director == null)
            {
                return false;
            }

            try
            {
                workManager.DirectorRepository.Remove(division.Director);
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
