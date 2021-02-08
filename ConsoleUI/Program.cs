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

            //CarCrudMethods();

            //ColorCrudMethods();

            BrandCrudMethods();

        }

        private static void BrandCrudMethods()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine("{0} {1}", brand.BrandId, brand.BrandName);
            }
            Console.WriteLine("-------------------------------------------------------------------------");
            var brandEntity = brandManager.Get(2);
            Console.WriteLine("{0} {1}", brandEntity.BrandId, brandEntity.BrandName);
            Console.WriteLine("-------------------------------------------------------------------------");
            brandManager.Add(new Brand { BrandName = "Skoda" });
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine("{0} {1}", brand.BrandId, brand.BrandName);
            }
            Console.WriteLine("-------------------------------------------------------------------------");
            brandManager.Update(new Brand { BrandId = 2, BrandName = "Seat" });
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine("{0} {1}", brand.BrandId, brand.BrandName);
            }
            Console.WriteLine("-------------------------------------------------------------------------");
            brandManager.Delete(new Brand { BrandId = 1003, BrandName = "Audi" });
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine("{0} {1}", brand.BrandId, brand.BrandName);
            }
        }

        private static void ColorCrudMethods()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("{0} {1}", color.ColorId, color.ColorName);
            }
            Console.WriteLine("-------------------------------------------------------------------------");
            var colorEntity = colorManager.Get(2);
            Console.WriteLine("{0} {1}", colorEntity.ColorId, colorEntity.ColorName);
            Console.WriteLine("-------------------------------------------------------------------------");
            colorManager.Add(new Color { ColorName = "Turuncu" });
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("{0} {1}", color.ColorId, color.ColorName);
            }
            Console.WriteLine("-------------------------------------------------------------------------");
            colorManager.Update(new Color { ColorId = 1003, ColorName = "Mor" });
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("{0} {1}", color.ColorId, color.ColorName);
            }
            Console.WriteLine("-------------------------------------------------------------------------");
            colorManager.Delete(new Color { ColorId = 1002, ColorName = "Mor" });
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("{0} {1}", color.ColorId, color.ColorName);
            }
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
