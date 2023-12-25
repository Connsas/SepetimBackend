using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class CommentManager : ICommentService
{
    private ICommentDal _commentDal;
    private string AddedMessage = Messages.CommentMessages.Added;
    private string RemovedMessage = Messages.CommentMessages.Removed;
    private string UpdatedMessage = Messages.CommentMessages.Updated;

    public CommentManager(ICommentDal commentDal)
    {
        _commentDal = commentDal;
    }

    public IResult Add(Comment comment)
    {
        _commentDal.Add(comment);
        return new SuccessResult(AddedMessage);
    }

    public IResult Delete(Comment comment)
    {
        _commentDal.Delete(comment);
        return new SuccessResult(RemovedMessage);
    }

    public IResult Update(Comment comment)
    {
        _commentDal.Update(comment);
        return new SuccessResult(UpdatedMessage);
    }

    public IDataResult<List<Comment>> GetAll()
    {
        return new SuccessDataResult<List<Comment>>(_commentDal.GetAll());
    }
}