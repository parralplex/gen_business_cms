using business_hierarchy_cms.Services.Abstract;
using DomainModel.DTO;
using DomainModel.Extensions;
using DomainModel.Model;
using Infrastructure.UnitOfWork;

namespace business_hierarchy_cms.Services
{
    public class DivisionService : ICRUDService<DivisionDTO>
    {
        private UnitOfWorkManager workManager;
        public DivisionService(IUnitOfWork pWorkManager)
        {
            workManager = (UnitOfWorkManager)pWorkManager;
        }
        public DivisionDTO? FindByID(int id)
        {
            var divisionList = workManager.DivisionRepository.Find(e => e.DivisionId == id).ToList();
            if (divisionList.Count > 0)
            {
                return divisionList[0].ToBaseDTO();
            }
            return null;
        }

        public IEnumerable<DivisionDTO> GetAll()
        {
            var divisions = new HashSet<DivisionDTO>();
            foreach (var division in workManager.DivisionRepository.GetAll())
            {
                divisions.Add(division.ToBaseDTO());
            }
            return divisions;
        }

        public bool Insert(DivisionDTO entity)
        {
            try
            {
                workManager.DivisionRepository.Insert(entity.ToBaseEntity());
                workManager.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Remove(DivisionDTO entity)
        {
            var division = workManager.DivisionRepository.Find(e => e.DivisionId == entity.DivisionId).ToList()[0];
            try
            {
                workManager.DivisionRepository.Remove(division);
                workManager.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Update(DivisionDTO entity)
        {
            var division = workManager.DivisionRepository.Find(e => e.DivisionId == entity.DivisionId).ToList()[0];
            division.BusinessId = entity.BusinessId;
            division.DivisionId = entity.DivisionId;
            division.Name = entity.Name;
            division.Objective = entity.Objective;
            try
            {
                workManager.DivisionRepository.Update(division);
                workManager.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool MakeDirector(int divisionId, int employeeId)
        {
            var division = workManager.DivisionRepository.Find(e => e.DivisionId == divisionId).ToList()[0];
            var empEntity = FindByID(employeeId);
            if (empEntity == null)
            {
                return false;
            }
            var employee = workManager.EmployeeRepository.Find(e => e.EmployeeId == employeeId).ToList()[0];

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
