using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Absract;
using Entities.Concrete;
using Entities.DTOs;
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

            var resultDatas = _rentalDal.GetRentACarDetail(r => r.CarId == rental.CarId);

            var result = resultDatas.Find(r => r.ReturnDate == null);

            if (result == null)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            }

            return new ErrorResult(Messages.RentalNameInvalid);

        }

        public IResult Delete(Rental rental)
        {
            if (rental.CarId > -1)
            {
                _rentalDal.Delete(rental);
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

        public IDataResult<List<RentalDetailDto>> GetRentACarDetail(int id)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentACarDetail(), Messages.RentalListed);
        }

        public IResult Update(Rental rental)
        {
            if (rental.CarId > -1)
            {
                _rentalDal.Update(rental);
                return new SuccessResult(Messages.RentalUpdated);
            }
            return new ErrorResult(Messages.RentalNameInvalid);
        }
    }
}
