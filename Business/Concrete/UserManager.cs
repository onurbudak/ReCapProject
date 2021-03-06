using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Absract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User entity)
        {
            if (entity.FirstName.Length > 2)
            {
                _userDal.Add(entity);
                return new SuccessResult(Messages.UserAdded);
            }
            return new ErrorResult(Messages.UserNameInvalid);
        }

        public IResult Delete(User entity)
        {
            if (entity.FirstName.Length > 2)
            {
                _userDal.Delete(entity);
                return new SuccessResult(Messages.UserDeleted);
            }
            return new ErrorResult(Messages.UserNameInvalid);
        }

        public IDataResult<User> Get(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(r => r.Id == id), Messages.UserListed);
        }

        public IDataResult<List<User>> GetAll()
        {
   
            return new SuccessDataResult<List<User>>(_userDal.GetAll(),Messages.UserListed);

        }

        public IResult Update(User entity)
        {
            if (entity.FirstName.Length > 2)
            {
                _userDal.Update(entity);
                return new SuccessResult(Messages.UserUpdated);
            }
            return new ErrorResult(Messages.UserNameInvalid);
        }
    }
}
