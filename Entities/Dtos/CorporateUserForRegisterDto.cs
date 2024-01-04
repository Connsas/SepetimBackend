using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class CorporateUserForRegisterDto : UserForRegisterDto
    {
        public string CorporateName { get; set; }
        public string TaxNumber { get; set; }
    }
}
