using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Absract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User,RentACarContext>, IUserDal
    {
    }
}
