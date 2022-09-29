using business_hierarchy_cms.Services.Abstract;
using DomainModel.DTO;
using DomainModel.Extensions;
using DomainModel.Model;
using Infrastructure.UnitOfWork;

namespace business_hierarchy_cms.Services
{
    public class ProjectService : ICRUDService<ProjectDTO>
    {
        private UnitOfWorkManager workManager;
        public ProjectService(IUnitOfWork pWorkManager)
        {
            workManager = (UnitOfWorkManager)pWorkManager;
        }
        public ProjectDTO? FindByID(int id)
        {
            var projectList = workManager.ProjectRepository.Find(e => e.ProjectId == id).ToList();
            if (projectList.Count > 0)
            {
                return projectList[0].ToBaseDTO();
            }
            return null;
        }

        public IEnumerable<ProjectDTO> GetAll()
        {
            var projects = new HashSet<ProjectDTO>();
            foreach (var project in workManager.ProjectRepository.GetAll())
            {
                projects.Add(project.ToBaseDTO());
            }
            return projects;
        }

        public bool Insert(ProjectDTO entity)
        {
            try
            {
                workManager.ProjectRepository.Insert(entity.ToBaseEntity());
                workManager.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Remove(ProjectDTO entity)
        {
            var project = workManager.ProjectRepository.Find(e => e.ProjectId == entity.ProjectId).ToList()[0];
            try
            {
                workManager.ProjectRepository.Remove(project);
                workManager.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Update(ProjectDTO entity)
        {
            var project = workManager.ProjectRepository.Find(e => e.ProjectId == entity.ProjectId).ToList()[0];
            project.ProjectId = entity.ProjectId;
            project.DepartmentId = entity.DepartmentId;
            project.Name = entity.Name;
            project.ProductName = entity.ProductName;
            project.Description = entity.Description;
            project.StartsAt = entity.StartsAt;
            project.FinishesAt = entity.FinishesAt;
            try
            {
                workManager.ProjectRepository.Update(project);
                workManager.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool MakeProjectManager(int projectId, int employeeId)
        {
            var project = workManager.ProjectRepository.Find(e => e.ProjectId == projectId).ToList()[0];
            var empEntity = FindByID(employeeId);
            if (empEntity == null)
            {
                return false;
            }
            var employee = workManager.EmployeeRepository.Find(e => e.EmployeeId == employeeId).ToList()[0];

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
