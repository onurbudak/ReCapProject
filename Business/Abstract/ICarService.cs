using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetCarsByBrandId(int brandId);
        List<Car> GetCarsByColorId(int colorId);
        void Add(Car entity);
        void Update(Car entity);
        void Delete(Car entity);
        List<Car> GetAll();
        Car Get(int id);
    }
}
