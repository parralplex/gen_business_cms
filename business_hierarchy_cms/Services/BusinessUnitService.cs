using business_hierarchy_cms.Exceptions;
using business_hierarchy_cms.Services.Abstract;
using DomainModel.DTO;
using DomainModel.Model;
using Infrastructure.UnitOfWork;
using System.Net;

namespace business_hierarchy_cms.Services
{
    public class BusinessUnitService : GenericOrganisationalUnitService<Business, BusinessDTO>
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

        protected override void AssignPosition(int organisationUnitId, int employeeId)
        {
            workManager.CeoRepository.Insert(new Ceo() { BusinessId = organisationUnitId, EmployeeId = employeeId });
        }

        protected override void CheckEmployeeContract(int organisationUnitId, int employeeBusinessId)
        {
            var business = FindByID(new BusinessDTO() { BusinessID = organisationUnitId });
            if (business == null)
            {
                HttpExceptions.ThrowHttpResponseExp(HttpStatusCode.NotFound, " Business with this ID doesnt exists in database");
            }

            if (business.BusinessId != employeeBusinessId)
            {
                HttpExceptions.ThrowHttpResponseExp(HttpStatusCode.BadRequest, " This employee is not part the business");
            }

            if (business.Ceo != null)
            {
                workManager.CeoRepository.Remove(business.Ceo);
            }
        }

        protected override object? GetCurrentLeader(int organisationUnitId)
        {
            var businessList = workManager.BusinessRepository.Find(e => e.BusinessId == organisationUnitId).ToList();
            if (businessList.Count > 0)
            {
                return businessList[0].Ceo;
            }
            return null;
        }

        protected override void RemoveLeader(object leader)
        {
            workManager.CeoRepository.Remove((Ceo)leader);
        }
    }
}
