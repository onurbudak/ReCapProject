using Business.Abstract;
using DataAccess.Absract;
using Entities.Concrete;
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

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(p => p.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(p => p.ColorId == colorId);
        }

    }
}
