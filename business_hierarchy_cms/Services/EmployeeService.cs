using business_hierarchy_cms.Exceptions;
using business_hierarchy_cms.Services.Abstract;
using DomainModel.DTO;
using DomainModel.DTO.Abstract;
using DomainModel.Model;
using Infrastructure.UnitOfWork;
using System.Net;

namespace business_hierarchy_cms.Services
{
    public class EmployeeService : GenericService<Employee, EmployeeDTO>
    {
        private UnitOfWorkManager workManager;
        public EmployeeService(IUnitOfWork pWorkManager) : base(pWorkManager, ((UnitOfWorkManager)pWorkManager).EmployeeRepository)
        {
            workManager = (UnitOfWorkManager)pWorkManager;
        }

        protected override Employee? FindByID(EmployeeDTO dto)
        {
            var employeeList = workManager.EmployeeRepository.Find(e => e.EmployeeId == dto.EmployeeId).ToList();
            if (employeeList.Count > 0)
            {
                return employeeList[0];
            }
            return null;
        }

        public void AssignProject(int projectId, int employeeId)
        {
            var employee = CheckEmployeeExistance(employeeId);
            var project = CheckProjectExistance(projectId);

            if (employee.BusinessId != project.Department.Division.BusinessId)
            {
                HttpExceptions.ThrowHttpResponseExp(HttpStatusCode.BadRequest, "This employee is not part the business");
            }

            employee.Projects.Add(project);
            workManager.SaveChanges();
        }

        public void RemoveFromProject(int projectId, int employeeId)
        {
            var employee = CheckEmployeeExistance(employeeId);
            var project = CheckProjectExistance(projectId);

            employee.Projects.Remove(project);
            workManager.SaveChanges();
        }

        private Employee CheckEmployeeExistance(int employeeId)
        {
            var employee = FindByID(new EmployeeDTO() { EmployeeId = employeeId });
            if (employee == null)
            {
                HttpExceptions.ThrowHttpResponseExp(HttpStatusCode.NotFound,"Employee with this ID doesnt exists in database");
            }
            return employee;
        }
        private Project CheckProjectExistance(int projectId)
        {
            var projectList = workManager.ProjectRepository.Find(e => e.ProjectId == projectId).ToList();
            if (projectList.Count == 0)
            {
                HttpExceptions.ThrowHttpResponseExp(HttpStatusCode.NotFound, "Project with this ID  doesnt exists in database");
            }
            return projectList[0];
        }
    }
}
