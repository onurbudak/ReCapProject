using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User entity);
        IResult Update(User entity);
        IResult Delete(User entity);
        IDataResult<List<User>> GetAll();
        IDataResult<User> Get(int id);
    }
}
