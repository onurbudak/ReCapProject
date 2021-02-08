using Business.Abstract;
using DataAccess.Absract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car entity)
        {
            if(entity.Descriptions.Length > 1 && entity.DailyPrice > 0)
            {
                _carDal.Add(entity);
            }
            else
            {
                Console.WriteLine("Lütfen Ekleme Kısıtlarına Uyunuz!!");
            }
           
        }

        public void Update(Car entity)
        {
            _carDal.Update(entity);

        }

        public void Delete(Car entity)
        {
            _carDal.Delete(entity);

        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public Car Get(int id)
        {
            return _carDal.Get(c => c.CarId == id);
        }


        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(p => p.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(p => p.ColorId == colorId);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }
    }
}
