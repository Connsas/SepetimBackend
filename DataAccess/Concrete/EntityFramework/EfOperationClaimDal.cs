﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOperationClaimDal: EfEntityRepositoryBase<OperationClaim, SepetimContext>, IOperationClaimDal
    {
    }
}
