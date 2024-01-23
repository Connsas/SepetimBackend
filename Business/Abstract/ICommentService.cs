using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract;

public interface ICommentService
{
    IResult Add(Comment comment);
    IResult Delete(Comment comment);
    IResult Update(Comment comment);
    IDataResult<List<Comment>> GetAll();
    IDataResult<List<CommentForShowDto>> GetByProductId(long productId);
}