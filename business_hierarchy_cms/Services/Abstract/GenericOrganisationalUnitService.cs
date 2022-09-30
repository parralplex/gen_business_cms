using business_hierarchy_cms.Exceptions;
using DomainModel.DTO.Abstract;
using DomainModel.Model;
using Infrastructure.Repository.Abstract;
using Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace business_hierarchy_cms.Services.Abstract
{
    public abstract class GenericOrganisationalUnitService<TEntity, TDTO> : GenericService<TEntity, TDTO> where TEntity : class where TDTO : IDTO<TEntity>
    {
        private IUnitOfWork workManager;
        protected GenericOrganisationalUnitService(IUnitOfWork pWorkManager, GenericRepository<TEntity> repo) : base(pWorkManager, repo)
        {
            workManager = pWorkManager;
        }

        public void MakeLeaderOfThisUnit(int organisationUnitId, int employeeId)
        {
            var lWorkManager = (UnitOfWorkManager)workManager;
            var employeeList = lWorkManager.EmployeeRepository.Find(e => e.EmployeeId == employeeId).ToList();
            if (employeeList.Count == 0)
            {
                HttpExceptions.ThrowHttpResponseExp(HttpStatusCode.NotFound, " Employee with id: " + employeeId + " could not be found.");
            }
            var employee = employeeList[0];

            CheckEmployeeContract(organisationUnitId, employee.BusinessId);

            // remove previous leadership position
            if (employee.DepartmentChief != null)
            {
                lWorkManager.DepartmentChiefRepository.Remove(employee.DepartmentChief);
            }
            if (employee.ProjectManager != null)
            {
                lWorkManager.ProjectManagerRepository.Remove(employee.ProjectManager);
            }
            if (employee.Director != null)
            {
                lWorkManager.DirectorRepository.Remove(employee.Director);
            }
            if (employee.Ceo != null)
            {
                lWorkManager.CeoRepository.Remove(employee.Ceo);
            }

            try
            {
                AssignPosition(organisationUnitId, employeeId);
                workManager.SaveChanges();
            }
            catch (DbUpdateConcurrencyException exp)
            {
                HttpExceptions.ThrowHttpResponseExp(HttpStatusCode.InternalServerError, exp.Message + " " + exp.Source + " detected concurrency issues.");
            }
            catch (DbUpdateException exp)
            {
                HttpExceptions.ThrowHttpResponseExp(HttpStatusCode.InternalServerError, exp.Message + " Leadership position assignment failed " + exp.Source);
            }
        }

        protected abstract void AssignPosition(int organisationUnitId, int employeeId);
        protected abstract void CheckEmployeeContract(int organisationUnitId, int employeeBusinessId);

        public void RemoveLeaderOfThisUnit(int organisationUnitId)
        {
            var leader = GetCurrentLeader(organisationUnitId);
            if (leader == null)
            {
                HttpExceptions.ThrowHttpResponseExp(HttpStatusCode.NotFound, " OrganisationUnit with id: " + organisationUnitId + " presently doesnt have any manager.");
            }

            try
            {
                RemoveLeader(leader);
                workManager.SaveChanges();
            }
            catch (DbUpdateConcurrencyException exp)
            {
                HttpExceptions.ThrowHttpResponseExp(HttpStatusCode.InternalServerError, exp.Message + " " + exp.Source + " detected concurrency issues.");
            }
            catch (DbUpdateException exp)
            {
                HttpExceptions.ThrowHttpResponseExp(HttpStatusCode.InternalServerError, exp.Message + " Leadership removal failed " + exp.Source);
            }
        }

        protected abstract object? GetCurrentLeader(int organisationUnitId);
        protected abstract void RemoveLeader(object leader);
    }
}
