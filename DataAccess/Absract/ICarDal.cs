using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Absract
{
    public interface ICarDal: IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetails();
        List<CarDetailDto> GetCarsByBrandId(Expression<Func<Car, bool>> filter = null);
        List<CarDetailDto> GetCarsByColorId(Expression<Func<Car, bool>> filter = null);
    }
}
