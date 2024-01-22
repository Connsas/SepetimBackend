using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract;

public interface ICommentService
{
    IResult Add(Comment comment);
    IResult Delete(Comment comment);
    IResult Update(Comment comment);
    IDataResult<List<Comment>> GetAll();
    IDataResult<List<Comment>> GetByProductId(long productId);
}