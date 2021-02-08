using Core.DataAccess.EntityFramework;
using DataAccess.Absract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join cr in context.Colors
                             on c.ColorId equals cr.ColorId
                             select new CarDetailDto
                             {
                                CarName = c.Descriptions,
                                BrandName = b.BrandName,
                                ColorName = cr.ColorName,
                                DailyPrice = c.DailyPrice
                             };

                return result.ToList();

            }
        }
    }
}
