using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class CorporateUserAccount: UserAccount
    {
        public long CorporateId { get; set; }
        public string CorporateName { get; set; }
        public string TaxNumber { get; set; }

    }
}
