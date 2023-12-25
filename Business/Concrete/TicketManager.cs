using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class TicketManager : ITicketService
{
    private ITicketDal _ticketDal;
    private string AddedMessage = Messages.TicketMessages.Added;
    public IResult Add(Ticket ticket)
    {
        _ticketDal.Add(ticket);
        return new SuccessResult(AddedMessage);
    }

    public IDataResult<List<Ticket>> GetAll()
    {
        return new SuccessDataResult<List<Ticket>>(_ticketDal.GetAll());
    }
}