using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class LoginRegisterResult<T>
    {

        public LoginRegisterResult(IDataResult<T> dataResult, long userId)
        {
            UserId = userId;
            Data = dataResult.Data;
            Message = dataResult.Message;
            Success = dataResult.Success;
        }

        public T Data { get; }
        public string Message { get; }
        public bool Success { get; }
        public long UserId { get;}
    }
}
