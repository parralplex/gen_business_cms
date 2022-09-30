using business_hierarchy_cms.Services.Abstract;
using DomainModel.DTO;
using DomainModel.Model;
using Infrastructure.UnitOfWork;

namespace business_hierarchy_cms.Services
{
    public class BusinessUnitService : GenericService<Business, BusinessDTO>
    {
        private UnitOfWorkManager workManager;
        public BusinessUnitService(IUnitOfWork pWorkManager):base(pWorkManager, ((UnitOfWorkManager)pWorkManager).BusinessRepository)
        {
            workManager = (UnitOfWorkManager)pWorkManager;
        }

        public override void Remove(BusinessDTO entity)
        {
            var business = workManager.BusinessRepository.Find(e => e.BusinessId == entity.BusinessID).ToList()[0];
            foreach (var Employee in business.Employees)
            {
                workManager.EmployeeRepository.Remove(Employee);
            }
            base.Remove(entity);
        }

        protected override Business? FindByID(BusinessDTO dto)
        {
            var businessList = workManager.BusinessRepository.Find(e => e.BusinessId == dto.BusinessID).ToList();
            if (businessList.Count > 0)
            {
                return businessList[0];
            }
            return null;
        }

        public bool MakeCeo(int businessId, int employeeId)
        {
            var business = FindByID(new BusinessDTO() { BusinessID = businessId });
            if (business == null)
            {
                return false;
            }


            var employeeList = workManager.EmployeeRepository.Find(e => e.EmployeeId == employeeId).ToList();
            if (employeeList.Count == 0)
            {
                return false;
            }
            var employee = employeeList[0];

            if (business.BusinessId != employee.BusinessId)
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
