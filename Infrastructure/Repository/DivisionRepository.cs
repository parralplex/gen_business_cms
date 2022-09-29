using DomainModel.Model;
using DomainModel.Model.Context;
using Infrastructure.Repository.Abstract;

namespace Infrastructure.Repository
{
    public class DivisionRepository : GenericRepository<Division>
    {
        public DivisionRepository(BusinessModelContext context) : base(context) { }
    }
}
