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

            //EfCarDalMethod();

            CarCrudMethods();
        }

        private static void CarCrudMethods()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5}", car.CarId, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Descriptions);
            }
            Console.WriteLine("-------------------------------------------------------------------------");
            var carEntity = carManager.Get(1004);
            Console.WriteLine("{0} {1} {2} {3} {4} {5}", carEntity.CarId, carEntity.BrandId, carEntity.ColorId, carEntity.ModelYear, carEntity.DailyPrice, carEntity.Descriptions);
            Console.WriteLine("-------------------------------------------------------------------------");
            carManager.Add(new Car { BrandId = 1, ColorId = 2, DailyPrice = 238, ModelYear = "2018", Descriptions = "Benzinli" });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5}", car.CarId, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Descriptions);
            }
            Console.WriteLine("-------------------------------------------------------------------------");
            carManager.Update(new Car { CarId = 1004, BrandId = 3, ColorId = 3, DailyPrice = 578, ModelYear = "2009", Descriptions = "Dizel" });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5}", car.CarId, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Descriptions);
            }
            Console.WriteLine("-------------------------------------------------------------------------");
            carManager.Delete(new Car { CarId = 1002, BrandId = 1, ColorId = 2, DailyPrice = 238, ModelYear = "2018", Descriptions = "Benzinli" });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5}", car.CarId, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Descriptions);
            }
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
