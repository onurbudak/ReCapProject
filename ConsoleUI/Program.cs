using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //InMemoryMethod();

            EfCarDalMethod();

        }

        private static void EfCarDalMethod()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            //carManager.Add(new Car { BrandId = 1, ColorId = 2, ModelYear = "2018", DailyPrice = 145, Descriptions = "Dizel" });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5}", car.CarId, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Descriptions);
            }
        }

        private static void InMemoryMethod()
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5}", car.CarId, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Descriptions);
            }
        }
    }
}
