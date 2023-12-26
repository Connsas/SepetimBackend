using Core.Entities;
using Core.Entities;

namespace Core.Utilities.Security.JWT;

public interface ITokenHelper
{
    AccessToken CreateToken(UserAccount user, List<OperationClaim> operationClaims);
}