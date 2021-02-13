using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Absract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer entity)
        {
            if(entity.CompanyName.Length > 2)
            {
                _customerDal.Add(entity);
                return new SuccessResult(Messages.CustomerAdded);
            }
            return new ErrorResult(Messages.CustomerCompanyNameInvalid);
        }

        public IResult Delete(Customer entity)
        {
            if (entity.CompanyName.Length > 2)
            {
                _customerDal.Delete(entity);
                return new SuccessResult(Messages.CustomerDeleted);
            }
            return new ErrorResult(Messages.CustomerCompanyNameInvalid);
        }

        public IDataResult<Customer> Get(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(r => r.Id == id), Messages.CustomerListed);
        }

        public IDataResult<List<Customer>> GetAll()
        {
           
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(),Messages.CustomerListed);
        }

        public IResult Update(Customer entity)
        {
            if (entity.CompanyName.Length > 2)
            {
                _customerDal.Delete(entity);
                return new SuccessResult(Messages.CustomerUpdated);
            }
            return new ErrorResult(Messages.CustomerCompanyNameInvalid);
        }
    }
}
