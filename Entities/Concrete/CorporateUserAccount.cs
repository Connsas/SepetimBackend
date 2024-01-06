using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    [Table("CorporateUserAccounts")]
    public class CorporateUserAccount: UserAccount
    {
        public long CorporateId { get; set; }
        public string CorporateName { get; set; }
        public string TaxNumber { get; set; }

    }
}
