using DataAccess.Absract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {

        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car{ Id=1, BrandId=1, ColorId=1, DailyPrice=150, ModelYear=2015, Description="Dizel"},
                new Car{ Id=2, BrandId=1, ColorId=2, DailyPrice=250, ModelYear=2012, Description="Dizel"},
                new Car{ Id=3, BrandId=2, ColorId=3, DailyPrice=350, ModelYear=2016, Description="Benzinli"},
                new Car{ Id=4, BrandId=2, ColorId=2, DailyPrice=80, ModelYear=2018, Description="Benzinli"},
                new Car{ Id=5, BrandId=3, ColorId=1, DailyPrice=120, ModelYear=2019, Description="Benzinli"},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            var carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public void Update(Car car)
        {
            var carToUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int id)
        {
            return _cars.Find(c => c.Id == id); 
        }
    }
}
