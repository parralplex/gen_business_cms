using business_hierarchy_cms.Exceptions;
using business_hierarchy_cms.Services.Abstract;
using DomainModel.DTO;
using DomainModel.DTO.Abstract;
using DomainModel.Model;
using Infrastructure.UnitOfWork;
using System.Net;

namespace business_hierarchy_cms.Services
{
    public class DepartmentService : GenericOrganisationalUnitService<Department, DepartmentDTO>
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

        protected override void AssignPosition(int organisationUnitId, int employeeId)
        {
            workManager.DepartmentChiefRepository.Insert(new DepartmentChief() { DepartmentId = organisationUnitId, EmployeeId = employeeId });
        }

        protected override void CheckEmployeeContract(int organisationUnitId, int employeeBusinessId)
        {
            var department = FindByID(new DepartmentDTO() { DepartmentId = organisationUnitId });
            if (department == null)
            {
                HttpExceptions.ThrowHttpResponseExp(HttpStatusCode.NotFound, " Department with this ID doesnt exists in database");
            }

            if (department.Division.BusinessId != employeeBusinessId)
            {
                HttpExceptions.ThrowHttpResponseExp(HttpStatusCode.BadRequest, " This employee is not part the business");
            }

            if (department.DepartmentChief != null)
            {
                workManager.DepartmentChiefRepository.Remove(department.DepartmentChief);
            }
        }

        protected override object? GetCurrentLeader(int organisationUnitId)
        {
            var departmentList = workManager.DepartmentRepository.Find(e => e.DepartmentId == organisationUnitId).ToList();
            if (departmentList.Count > 0)
            {
                return departmentList[0].DepartmentChief;
            }
            return null;
        }

        protected override void RemoveLeader(object leader)
        {
            workManager.DepartmentChiefRepository.Remove((DepartmentChief)leader);
        }
    }
}
