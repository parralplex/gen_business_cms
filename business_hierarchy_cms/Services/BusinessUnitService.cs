using business_hierarchy_cms.Services.Abstract;
using DomainModel.DTO;
using DomainModel.Extensions;
using DomainModel.Model;
using Infrastructure.UnitOfWork;

namespace business_hierarchy_cms.Services
{
    public class BusinessUnitService : ICRUDService<BusinessDTO> 
    {
        private UnitOfWorkManager workManager;
        public BusinessUnitService(IUnitOfWork pWorkManager)
        {
            workManager = (UnitOfWorkManager)pWorkManager;
        }
        public bool Insert(BusinessDTO entity)
        {
            try
            {
                workManager.BusinessRepository.Insert(entity.ToBaseEntity());
                workManager.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool Remove(BusinessDTO entity)
        {
            var business = workManager.BusinessRepository.Find(e => e.BusinessId == entity.BusinessID).ToList()[0];
            try
            {
                foreach (var Employee in business.Employees)
                {
                    workManager.EmployeeRepository.Remove(Employee);
                }
                workManager.BusinessRepository.Remove(business);
                workManager.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool Update(BusinessDTO entity)
        {
            var business = workManager.BusinessRepository.Find(e => e.BusinessId == entity.BusinessID).ToList()[0];
            business.BusinessId = entity.BusinessID;
            business.Description = entity.Description;
            business.Name = entity.Name;
            try
            {
                workManager.BusinessRepository.Update(business);
                workManager.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public BusinessDTO? FindByID(int id)
        {
            var businessList = workManager.BusinessRepository.Find(e => e.BusinessId == id).ToList();
            if (businessList.Count > 0)
            {
                return businessList[0].ToBaseDTO();
            }
            return null;
        }

        public IEnumerable<BusinessDTO> GetAll()
        {
            var businesses = new HashSet<BusinessDTO>();
            foreach (var business in workManager.BusinessRepository.GetAll())
            {
                businesses.Add(business.ToBaseDTO());
            }
            return businesses;
        }

        public bool MakeCeo(int businessId, int employeeId)
        {
            var business = workManager.BusinessRepository.Find(e => e.BusinessId == businessId).ToList()[0];

            var empEntity = FindByID(employeeId);
            if(empEntity == null)
            {
                return false;
            }
            var employee = workManager.EmployeeRepository.Find(e => e.EmployeeId == employeeId).ToList()[0];

            if(business.BusinessId != employee.BusinessId)
            {
                return false;
            }

            if (business.Ceo != null)
            {
                workManager.CeoRepository.Remove(business.Ceo);
            }

            if (employee.DepartmentChief != null) 
            {
                workManager.DepartmentChiefRepository.Remove(employee.DepartmentChief);
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
                workManager.CeoRepository.Insert(new Ceo() { BusinessId = businessId, EmployeeId = employeeId});
                workManager.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool RemoveCeo(int businessId)
        {
            var business = workManager.BusinessRepository.Find(e => e.BusinessId == businessId).ToList()[0];
            if (business.Ceo == null)
            {
                return false;
            }

            try
            {
                workManager.CeoRepository.Remove(business.Ceo);
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
