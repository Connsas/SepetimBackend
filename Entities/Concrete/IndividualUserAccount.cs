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
    [Table("IndividualUserAccounts")]
    public class IndividualUserAccount: UserAccount
    {
        public long NationalId { get; set; }
    }
}
