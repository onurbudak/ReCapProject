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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            var result = _rentalDal.GetAll(r => r.CarId == rental.CarId && r.ReturnDate != null);
            if (result.Count > 0)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);

            }
            else
            {
                return new ErrorResult(Messages.RentalNameInvalid);
            }

        }

        public IResult Delete(Rental rental)
        {
            if (rental.CarId > 2)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalDeleted);
            }
            return new ErrorResult(Messages.RentalNameInvalid);
        }

        public IDataResult<Rental> Get(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id), Messages.RentalListed);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);
        }

        public IResult Update(Rental rental)
        {
            if (rental.CarId > 2)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalUpdated);
            }
            return new ErrorResult(Messages.RentalNameInvalid);
        }
    }
}
