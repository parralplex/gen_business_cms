using business_hierarchy_cms.Exceptions;
using business_hierarchy_cms.Services.Abstract;
using DomainModel.DTO;
using DomainModel.Model;
using Infrastructure.UnitOfWork;
using System.Net;

namespace business_hierarchy_cms.Services
{
    public class DivisionService : GenericOrganisationalUnitService<Division, DivisionDTO>
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

        protected override void AssignPosition(int organisationUnitId, int employeeId)
        {
            workManager.DirectorRepository.Insert(new Director() { DivisionId = organisationUnitId, EmployeeId = employeeId });
        }

        protected override void CheckEmployeeContract(int organisationUnitId, int employeeBusinessId)
        {
            var division = FindByID(new DivisionDTO() { DivisionId = organisationUnitId });
            if (division == null)
            {
                HttpExceptions.ThrowHttpResponseExp(HttpStatusCode.NotFound, " Division with this ID doesnt exists in database");
            }

            if (division.BusinessId != employeeBusinessId)
            {
                HttpExceptions.ThrowHttpResponseExp(HttpStatusCode.BadRequest, " This employee is not part the business");
            }

            if (division.Director != null)
            {
                workManager.DirectorRepository.Remove(division.Director);
            }
        }

        protected override object? GetCurrentLeader(int organisationUnitId)
        {
            var divisionList = workManager.DivisionRepository.Find(e => e.DivisionId == organisationUnitId).ToList();
            if (divisionList.Count > 0)
            {
                return divisionList[0].Director;
            }
            return null;
        }

        protected override void RemoveLeader(object leader)
        {
            workManager.DirectorRepository.Remove((Director)leader);
        }
    }
}
