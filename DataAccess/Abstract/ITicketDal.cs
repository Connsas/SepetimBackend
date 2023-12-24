using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract;

public interface ITicketDal : IEntityRepository<Ticket>
{
}