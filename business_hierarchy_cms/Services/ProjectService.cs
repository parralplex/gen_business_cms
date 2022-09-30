using business_hierarchy_cms.Services.Abstract;
using DomainModel.DTO;
using DomainModel.Model;
using Infrastructure.UnitOfWork;

namespace business_hierarchy_cms.Services
{
    public class ProjectService : GenericService<Project, ProjectDTO>
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

        public bool MakeProjectManager(int projectId, int employeeId)
        {
            var project = FindByID(new ProjectDTO() { ProjectId = projectId });
            if (project == null)
            {
                return false;
            }


            var employeeList = workManager.EmployeeRepository.Find(e => e.EmployeeId == employeeId).ToList();
            if (employeeList.Count == 0)
            {
                return false;
            }
            var employee = employeeList[0];

            if (project.Department.Division.Business.BusinessId != employee.BusinessId)
            {
                return false;
            }

            if (project.ProjectManager != null)
            {
                workManager.ProjectManagerRepository.Remove(project.ProjectManager);
            }

            if (employee.Ceo != null)
            {
                workManager.CeoRepository.Remove(employee.Ceo);
            }
            if (employee.DepartmentChief != null)
            {
                workManager.DepartmentChiefRepository.Remove(employee.DepartmentChief);
            }
            if (employee.Director != null)
            {
                workManager.DirectorRepository.Remove(employee.Director);
            }

            try
            {
                workManager.ProjectManagerRepository.Insert(new ProjectManager() { ProjectId = projectId, EmployeeId = employeeId });
                workManager.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool RemoveProjectManager(int projectId)
        {
            var project = workManager.ProjectRepository.Find(e => e.ProjectId == projectId).ToList()[0];
            if (project.ProjectManager == null)
            {
                return false;
            }

            try
            {
                workManager.ProjectManagerRepository.Remove(project.ProjectManager);
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
