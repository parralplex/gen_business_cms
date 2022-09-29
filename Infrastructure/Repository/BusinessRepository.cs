using DomainModel.Model;
using DomainModel.Model.Context;
using Infrastructure.Repository.Abstract;

namespace Infrastructure.Repository
{
    public class BusinessRepository : GenericRepository<Business>
    {
        public BusinessRepository(BusinessModelContext context) : base(context) { }
    }
}
