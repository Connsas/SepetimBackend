using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract;

public interface ITicketService
{
    IResult Add(Ticket ticket);
    IResult Delete(Ticket ticket);
    IResult Update(Ticket ticket);
    IDataResult<List<Ticket>> GetAll();
}