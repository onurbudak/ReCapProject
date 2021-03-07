using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetCarsByBrandId(int brandId);
        IDataResult<List<Car>> GetCarsByColorId(int colorId);
        IResult Add(Car entity);
        IResult Update(Car entity);
        IResult Delete(Car entity);
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> Get(int id);
        IDataResult<List<CarDetailDto>> GetCarDetails();

        IResult AddTransactionalTest(Car car);

    }
}
