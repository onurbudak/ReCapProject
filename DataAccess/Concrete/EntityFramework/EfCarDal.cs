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

                //var result = from c in context.Cars
                //             join b in context.Brands
                //             on c.BrandId equals b.Id
                //             join cr in context.Colors
                //             on c.ColorId equals cr.Id
                //             select new CarDetailDto
                //             {
                //                 Id = c.Id,
                //                 CarName = c.CarName,
                //                 BrandName = b.BrandName,
                //                 ColorName = cr.ColorName,
                //                 ModelYear = c.ModelYear,
                //                 DailyPrice = c.DailyPrice,
                //                 Descriptions = c.Descriptions
                //             };

                var result2 = context.Cars
                .Include(b => b.Brand).Include(c => c.Color).Select(c => new CarDetailDto {
                    Id = c.Id,
                    CarName = c.CarName,
                    BrandName = c.Brand.BrandName,
                    ColorName = c.Color.ColorName,
                    ModelYear = c.ModelYear,
                    DailyPrice = c.DailyPrice,
                    Descriptions = c.Descriptions
                });

                return result2.ToList();

            }
        }

        public List<CarDetailDto> GetCarsByBrandId(Expression<Func<Car, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in filter is null ? context.Cars : context.Cars.Where(filter)
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join cr in context.Colors
                             on c.ColorId equals cr.Id
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = cr.ColorName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Descriptions = c.Descriptions
                             };

                return result.ToList();

            }
        }

        public List<CarDetailDto> GetCarsByColorId(Expression<Func<Car, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in filter is null ? context.Cars : context.Cars.Where(filter)
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join cr in context.Colors
                             on c.ColorId equals cr.Id
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = cr.ColorName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Descriptions = c.Descriptions
                             };

                return result.ToList();

            }
        }
    }
}
