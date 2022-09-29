using DomainModel.Model.Context;
using DomainModel.Model;
using Infrastructure.Repository.Abstract;


namespace Infrastructure.Repository
{
    public class DirectorRepository : GenericRepository<Director>
    {
        public DirectorRepository(BusinessModelContext context) : base(context) { }
    }
}
