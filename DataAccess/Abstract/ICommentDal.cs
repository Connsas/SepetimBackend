using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;
using System.Linq.Expressions;

namespace DataAccess.Abstract;

public interface ICommentDal : IEntityRepository<Comment>
{
    List<CommentForShowDto> GetCommentDto(long productId);
}