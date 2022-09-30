using business_hierarchy_cms.Exceptions;
using DomainModel.DTO.Abstract;
using Infrastructure.Repository.Abstract;
using Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Web.Http;

namespace business_hierarchy_cms.Services.Abstract
{
    public abstract class GenericService<TEntity, TDTO> :ICRUDService<TDTO> where TDTO : IDTO<TEntity> where TEntity : class
    {
        private IUnitOfWork workManager;
        private GenericRepository<TEntity> entityRepository;
        public GenericService(IUnitOfWork pWorkManager, GenericRepository<TEntity> repo)
        {
            workManager = pWorkManager;
            entityRepository = repo;
        }
        protected abstract TEntity? FindByID(TDTO dto);

        public virtual void Insert(TDTO entity)
        {
            try
            {
                entityRepository.Insert(entity.ToBaseEntity());
                workManager.SaveChanges();
            }
            catch (DbUpdateConcurrencyException exp)
            {
                HttpExceptions.ThrowHttpResponseExp(HttpStatusCode.InternalServerError, exp.Message + " " + exp.Source + " detected concurrency issues.");
            }
            catch (DbUpdateException exp)
            {
                HttpExceptions.ThrowHttpResponseExp(HttpStatusCode.InternalServerError, exp.Message + "DTO insertion failed in " + exp.Source);
            }
        }

        public virtual void Remove(TDTO entity)
        {
            var business = FindByID(entity);
            if(business == null)
            {
                HttpExceptions.ThrowHttpResponseExp(HttpStatusCode.NotFound, entity + " doesnt exists in database");
            }
            try
            {
                entityRepository.Remove(business);
                workManager.SaveChanges();
            }
            catch (DbUpdateConcurrencyException exp)
            {
                HttpExceptions.ThrowHttpResponseExp(HttpStatusCode.InternalServerError, exp.Message + " " + exp.Source + " detected concurrency issues.");
            }
            catch (DbUpdateException exp)
            {
                HttpExceptions.ThrowHttpResponseExp(HttpStatusCode.InternalServerError, exp.Message + " DTO removal failed in " + exp.Source);
            }
        }

        public virtual void Update(TDTO entity)
        {
            var business = FindByID(entity);
            if (business == null)
            {
                HttpExceptions.ThrowHttpResponseExp(HttpStatusCode.NotFound, entity + " doesnt exists in database");
            }
            entity.CopyDataToEntity(business);
            try
            {
                entityRepository.Update(business);
                workManager.SaveChanges();
            }
            catch (DbUpdateConcurrencyException exp)
            {
                HttpExceptions.ThrowHttpResponseExp(HttpStatusCode.InternalServerError, exp.Message + " " + exp.Source + " detected concurrency issues.");
            }
            catch (DbUpdateException exp)
            {
                HttpExceptions.ThrowHttpResponseExp(HttpStatusCode.InternalServerError, exp.Message + " DTO update failed in " + exp.Source);
            }
        }
    }
}
