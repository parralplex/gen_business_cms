using DomainModel.Model;
using DomainModel.Model.Context;
using Infrastructure.Repository.Abstract;

namespace Infrastructure.Repository
{
    public class ProjectRepository : GenericRepository<Project>
    {
        public ProjectRepository(BusinessModelContext context) : base(context) { }
    }
}
