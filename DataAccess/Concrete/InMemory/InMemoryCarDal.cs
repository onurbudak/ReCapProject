using DataAccess.Absract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {

        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car{ CarId=1, BrandId=1, ColorId=1,Name="Elantra", DailyPrice=150, ModelYear="2015", Descriptions="Dizel"},
                new Car{ CarId=2, BrandId=1, ColorId=2,Name="Elantra", DailyPrice=250, ModelYear="2012", Descriptions="Dizel"},
                new Car{ CarId=3, BrandId=2, ColorId=3, Name="Elantra",DailyPrice=350, ModelYear="2016", Descriptions="Benzinli"},
                new Car{ CarId=4, BrandId=2, ColorId=2, Name="Elantra",DailyPrice=80, ModelYear="2018", Descriptions="Benzinli"},
                new Car{ CarId=5, BrandId=3, ColorId=1,Name="Elantra", DailyPrice=120, ModelYear="2019", Descriptions="Benzinli"},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            var carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public void Update(Car car)
        {
            var carToUpdate = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Descriptions = car.Descriptions;
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int id)
        {
            return _cars.Find(c => c.CarId == id); 
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}
