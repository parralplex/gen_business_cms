using DomainModel.Model.Context;
using DomainModel.Model;
using Infrastructure.Repository.Abstract;


namespace Infrastructure.Repository
{
    public class ProjectManagerRepository : GenericRepository<ProjectManager>
    {
        public ProjectManagerRepository(BusinessModelContext context) : base(context) { }
    }
}
