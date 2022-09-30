using business_hierarchy_cms.Exceptions;
using business_hierarchy_cms.Services.Abstract;
using DomainModel.DTO;
using DomainModel.Model;
using Infrastructure.UnitOfWork;
using System.Net;

namespace business_hierarchy_cms.Services
{
    public class ProjectService : GenericOrganisationalUnitService<Project, ProjectDTO>
    {
        private UnitOfWorkManager workManager;
        public ProjectService(IUnitOfWork pWorkManager) : base(pWorkManager, ((UnitOfWorkManager)pWorkManager).ProjectRepository)
        {
            workManager = (UnitOfWorkManager)pWorkManager;
        }

        protected override Project? FindByID(ProjectDTO dto)
        {
            var projectList = workManager.ProjectRepository.Find(e => e.ProjectId == dto.ProjectId).ToList();
            if (projectList.Count > 0)
            {
                return projectList[0];
            }
            return null;
        }

        protected override void AssignPosition(int organisationUnitId, int employeeId)
        {
            workManager.ProjectManagerRepository.Insert(new ProjectManager() { ProjectId = organisationUnitId, EmployeeId = employeeId });
        }

        protected override void CheckEmployeeContract(int organisationUnitId, int employeeBusinessId)
        {
            var project = FindByID(new ProjectDTO() { ProjectId = organisationUnitId });
            if (project == null)
            {
                HttpExceptions.ThrowHttpResponseExp(HttpStatusCode.NotFound, " Project with this ID doesnt exists in database");
            }

            if (project.Department.Division.BusinessId != employeeBusinessId)
            {
                HttpExceptions.ThrowHttpResponseExp(HttpStatusCode.BadRequest, " This employee is not part the business");
            }

            if (project.ProjectManager != null)
            {
                workManager.ProjectManagerRepository.Remove(project.ProjectManager);
            }
        }

        protected override object? GetCurrentLeader(int organisationUnitId)
        {
            var projectList = workManager.ProjectRepository.Find(e => e.ProjectId == organisationUnitId).ToList();
            if (projectList.Count > 0)
            {
                return projectList[0].ProjectManager;
            }
            return null;
        }

        protected override void RemoveLeader(object leader)
        {
            workManager.ProjectManagerRepository.Remove((ProjectManager)leader);
        }
    }
}
