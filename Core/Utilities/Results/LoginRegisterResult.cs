using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class LoginRegisterResult<T>
    {

        public LoginRegisterResult(IDataResult<T> dataResult, long userId, string userName, string userSurname)
        {
            UserId = userId;
            UserName = userName;
            UserSurname = userSurname;
            Data = dataResult.Data;
            Message = dataResult.Message;
            Success = dataResult.Success;
        }

        public T Data { get; }
        public string Message { get; }
        public bool Success { get; }
        public long UserId { get;}

        public string UserName { get; }
        public string UserSurname { get; }
    }
}
