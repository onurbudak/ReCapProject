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
            //GetCarDetailsTest();

            //InMemoryMethod();

            //EfCarDalMethod();

            //CarCrudMethods();

            //ColorCrudMethods();

            //BrandCrudMethods();

            //UserCrudMethods();

            //CustomerCrudMehods();

            RentalCrudMethods();
        }

        private static void RentalCrudMethods()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetAll();
            foreach (var rental in result.Data)
            {
                Console.WriteLine("{0} {1} {2} {3} {4}", rental.Id, rental.CarId, rental.CustomerId, rental.RentDate, rental.ReturnDate);
            }

            Console.WriteLine( rentalManager.Add(new Rental { CarId = 4, CustomerId = 2, RentDate = DateTime.Now, ReturnDate = null }).Message);

            var result2 = rentalManager.GetAll();
            foreach (var rental in result2.Data)
            {
                Console.WriteLine("{0} {1} {2} {3} {4}", rental.Id, rental.CarId, rental.CustomerId, rental.RentDate, rental.ReturnDate);
            }
        }

        private static void CustomerCrudMehods()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.GetAll();
            foreach (var customer in result.Data)
            {
                Console.WriteLine("{0} {1} {2}", customer.Id, customer.UserId, customer.CompanyName);
            }
        }

        private static void UserCrudMethods()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.GetAll();
            foreach (var user in result.Data)
            {
                Console.WriteLine("{0} {1} {2} {3} {4}", user.Id, user.Firstname, user.LastName, user.Email, user.Password);
            }
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
                Console.WriteLine("{0} {1}", brand.Id, brand.BrandName);
            }
            Console.WriteLine("-------------------------------------------------------------------------");
            var brandEntity = brandManager.Get(4);
            Console.WriteLine("{0} {1}", brandEntity.Data.Id, brandEntity.Data.BrandName);
            Console.WriteLine("-------------------------------------------------------------------------");
            brandManager.Add(new Brand { BrandName = "Opel" });
            foreach (var brand in result.Data)
            {
                Console.WriteLine("{0} {1}", brand.Id, brand.BrandName);
            }
            Console.WriteLine("-------------------------------------------------------------------------");
            brandManager.Update(new Brand { Id = 4, BrandName = "Skoda" });
            foreach (var brand in result.Data)
            {
                Console.WriteLine("{0} {1}", brand.Id, brand.BrandName);
            }
            Console.WriteLine("-------------------------------------------------------------------------");
            brandManager.Delete(new Brand { Id = 4, BrandName = "Audi" });
            foreach (var brand in result.Data)
            {
                Console.WriteLine("{0} {1}", brand.Id, brand.BrandName);
            }
        }

        private static void ColorCrudMethods()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetAll();
            foreach (var color in result.Data)
            {
                Console.WriteLine("{0} {1}", color.Id, color.ColorName);
            }
            Console.WriteLine("-------------------------------------------------------------------------");
            var colorEntity = colorManager.Get(2);
            Console.WriteLine("{0} {1}", colorEntity.Data.Id, colorEntity.Data.ColorName);
            Console.WriteLine("-------------------------------------------------------------------------");
            colorManager.Add(new Color { ColorName = "Turuncu" });
            foreach (var color in result.Data)
            {
                Console.WriteLine("{0} {1}", color.Id, color.ColorName);
            }
            Console.WriteLine("-------------------------------------------------------------------------");
            colorManager.Update(new Color { Id = 1003, ColorName = "Mor" });
            foreach (var color in result.Data)
            {
                Console.WriteLine("{0} {1}", color.Id, color.ColorName);
            }
            Console.WriteLine("-------------------------------------------------------------------------");
            colorManager.Delete(new Color { Id = 1002, ColorName = "Mor" });
            foreach (var color in result.Data)
            {
                Console.WriteLine("{0} {1}", color.Id, color.ColorName);
            }
        }

        private static void CarCrudMethods()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            foreach (var car in result.Data)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5} {6}", car.Id, car.BrandId, car.ColorId, car.CarName, car.ModelYear, car.DailyPrice, car.Descriptions);
            }
            Console.WriteLine("-------------------------------------------------------------------------");
            var carEntity = carManager.Get(3);
            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6}", carEntity.Data.Id, carEntity.Data.BrandId, carEntity.Data.ColorId, carEntity.Data.CarName, carEntity.Data.ModelYear, carEntity.Data.DailyPrice, carEntity.Data.Descriptions);
            Console.WriteLine("-------------------------------------------------------------------------");
            carManager.Add(new Car { BrandId = 1, ColorId = 2, CarName="Duster", DailyPrice = 238, ModelYear = "2018", Descriptions = "Benzinli" });
            foreach (var car in result.Data)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5} {6}", car.Id, car.BrandId, car.ColorId, car.CarName, car.ModelYear, car.DailyPrice, car.Descriptions);
            }
            Console.WriteLine("-------------------------------------------------------------------------");
            carManager.Update(new Car { Id = 5, BrandId = 3, ColorId = 3, CarName = "Mazda6", DailyPrice = 578, ModelYear = "2009", Descriptions = "Dizel" });
            foreach (var car in result.Data)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5} {6}", car.Id, car.BrandId, car.ColorId, car.CarName, car.ModelYear, car.DailyPrice, car.Descriptions);
            }
            Console.WriteLine("-------------------------------------------------------------------------");
            carManager.Delete(new Car { Id = 6, BrandId = 1, ColorId = 2, CarName = "Mazda6", DailyPrice = 238, ModelYear = "2018", Descriptions = "Benzinli" });
            foreach (var car in result.Data)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5} {6}", car.Id, car.BrandId, car.ColorId, car.CarName, car.ModelYear, car.DailyPrice, car.Descriptions);
            }
        }

        private static void EfCarDalMethod()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            //carManager.Add(new Car { BrandId = 1, ColorId = 2, ModelYear = "2018", DailyPrice = 145, Descriptions = "Dizel" });
            var result = carManager.GetAll();
            foreach (var car in result.Data)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5}", car.Id, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Descriptions);
            }
        }

        private static void InMemoryMethod()
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            var result = carManager.GetAll();
            foreach (var car in result.Data)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5}", car.Id, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Descriptions);
            }
        }
    }
}
