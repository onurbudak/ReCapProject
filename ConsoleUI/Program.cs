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
           
            GetCarDetailsTest();

            //InMemoryMethod();

            //EfCarDalMethod();

            //CarCrudMethods();

            //ColorCrudMethods();

            //BrandCrudMethods();


        }

        private static void GetCarDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if(result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("{0} {1} {2} {3}", car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
          
        }

        private static void BrandCrudMethods()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetAll();
            foreach (var brand in result.Data)
            {
                Console.WriteLine("{0} {1}", brand.BrandId, brand.BrandName);
            }
            Console.WriteLine("-------------------------------------------------------------------------");
            var brandEntity = brandManager.Get(4);
            Console.WriteLine("{0} {1}", brandEntity.Data.BrandId, brandEntity.Data.BrandName);
            Console.WriteLine("-------------------------------------------------------------------------");
            brandManager.Add(new Brand { BrandName = "Opel" });
            foreach (var brand in result.Data)
            {
                Console.WriteLine("{0} {1}", brand.BrandId, brand.BrandName);
            }
            Console.WriteLine("-------------------------------------------------------------------------");
            brandManager.Update(new Brand { BrandId = 4, BrandName = "Skoda" });
            foreach (var brand in result.Data)
            {
                Console.WriteLine("{0} {1}", brand.BrandId, brand.BrandName);
            }
            Console.WriteLine("-------------------------------------------------------------------------");
            brandManager.Delete(new Brand { BrandId = 4, BrandName = "Audi" });
            foreach (var brand in result.Data)
            {
                Console.WriteLine("{0} {1}", brand.BrandId, brand.BrandName);
            }
        }

        private static void ColorCrudMethods()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetAll();
            foreach (var color in result.Data)
            {
                Console.WriteLine("{0} {1}", color.ColorId, color.ColorName);
            }
            Console.WriteLine("-------------------------------------------------------------------------");
            var colorEntity = colorManager.Get(2);
            Console.WriteLine("{0} {1}", colorEntity.Data.ColorId, colorEntity.Data.ColorName);
            Console.WriteLine("-------------------------------------------------------------------------");
            colorManager.Add(new Color { ColorName = "Turuncu" });
            foreach (var color in result.Data)
            {
                Console.WriteLine("{0} {1}", color.ColorId, color.ColorName);
            }
            Console.WriteLine("-------------------------------------------------------------------------");
            colorManager.Update(new Color { ColorId = 1003, ColorName = "Mor" });
            foreach (var color in result.Data)
            {
                Console.WriteLine("{0} {1}", color.ColorId, color.ColorName);
            }
            Console.WriteLine("-------------------------------------------------------------------------");
            colorManager.Delete(new Color { ColorId = 1002, ColorName = "Mor" });
            foreach (var color in result.Data)
            {
                Console.WriteLine("{0} {1}", color.ColorId, color.ColorName);
            }
        }

        private static void CarCrudMethods()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            foreach (var car in result.Data)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5} {6}", car.CarId, car.BrandId, car.ColorId, car.Name, car.ModelYear, car.DailyPrice, car.Descriptions);
            }
            Console.WriteLine("-------------------------------------------------------------------------");
            var carEntity = carManager.Get(3);
            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6}", carEntity.Data.CarId, carEntity.Data.BrandId, carEntity.Data.ColorId, carEntity.Data.Name, carEntity.Data.ModelYear, carEntity.Data.DailyPrice, carEntity.Data.Descriptions);
            Console.WriteLine("-------------------------------------------------------------------------");
            carManager.Add(new Car { BrandId = 1, ColorId = 2, Name="Duster", DailyPrice = 238, ModelYear = "2018", Descriptions = "Benzinli" });
            foreach (var car in result.Data)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5} {6}", car.CarId, car.BrandId, car.ColorId, car.Name, car.ModelYear, car.DailyPrice, car.Descriptions);
            }
            Console.WriteLine("-------------------------------------------------------------------------");
            carManager.Update(new Car { CarId = 5, BrandId = 3, ColorId = 3, Name = "Mazda6", DailyPrice = 578, ModelYear = "2009", Descriptions = "Dizel" });
            foreach (var car in result.Data)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5} {6}", car.CarId, car.BrandId, car.ColorId, car.Name, car.ModelYear, car.DailyPrice, car.Descriptions);
            }
            Console.WriteLine("-------------------------------------------------------------------------");
            carManager.Delete(new Car { CarId = 6, BrandId = 1, ColorId = 2, Name = "Mazda6", DailyPrice = 238, ModelYear = "2018", Descriptions = "Benzinli" });
            foreach (var car in result.Data)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5} {6}", car.CarId, car.BrandId, car.ColorId, car.Name, car.ModelYear, car.DailyPrice, car.Descriptions);
            }
        }

        private static void EfCarDalMethod()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            //carManager.Add(new Car { BrandId = 1, ColorId = 2, ModelYear = "2018", DailyPrice = 145, Descriptions = "Dizel" });
            var result = carManager.GetAll();
            foreach (var car in result.Data)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5}", car.CarId, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Descriptions);
            }
        }

        private static void InMemoryMethod()
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            var result = carManager.GetAll();
            foreach (var car in result.Data)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5}", car.CarId, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Descriptions);
            }
        }
    }
}
