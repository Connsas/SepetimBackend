using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Concrete.EntityFramework;

public class EfCommentDal : EfEntityRepositoryBase<Comment, SepetimContext>, ICommentDal
{
    public List<CommentForShowDto> GetCommentDto(long productId)
    {
        using (SepetimContext context = new SepetimContext())
        {
            var result = from comment in context.Comments
                join user in context.UserAccounts on comment.UserId equals user.UserId
                where comment.ProductId == productId
                select new CommentForShowDto()
                {
                    CommentId = comment.CommentId,
                    UserId = comment.UserId,
                    ProductId = comment.ProductId,
                    CommentText = comment.CommentText,
                    SendDate = comment.SendDate,
                    UserFullName = user.Name + " " + user.Surname
                };
            var resultList = result.ToList();
            return resultList;
        }
    }
}