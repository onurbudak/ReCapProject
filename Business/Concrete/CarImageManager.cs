using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.FileHelpers;
using Core.Utilities.Results;
using DataAccess.Absract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(CarImage carImage)
        {
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IResult SaveFile(IFormFile formFile, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfCarImageLimitExceded(carImage));

            if (result != null)
            {
                return result;
            }

            var imagePath = FileHelper.SaveImage(formFile);
            if (imagePath != null)
            {
                carImage.ImagePath = imagePath;
                _carImageDal.Add(carImage);
                return new SuccessResult();
            }
            return new ErrorResult(Messages.FileExtensionInvalid);

        }
        public IResult DeleteFile(CarImage carImage)
        {
            var isDelete = FileHelper.DeleteImage(carImage.ImagePath);
            if (isDelete)
            {
                _carImageDal.Delete(carImage);
                return new SuccessResult();
            }
            return new ErrorResult(Messages.FilePathInvalid);

        }

        public IResult UpdateFile(IFormFile formFile, CarImage carImage)
        {
            var isDelete = FileHelper.DeleteImage(carImage.ImagePath);
            if (isDelete)
            {
                var imagePath = FileHelper.SaveImage(formFile);
                if (imagePath != null)
                {
                    carImage.ImagePath = imagePath;
                    _carImageDal.Update(carImage);
                    return new SuccessResult();
                }
                return new ErrorResult();
            }
            return new ErrorResult(Messages.FilePathInvalid);
        }

        public IDataResult<List<Stream>> GetFileData(List<IFormFile> formFile, CarImage carImage)
        {
            List<Stream> carImageViewList = new List<Stream>();
            var carImageDatas = _carImageDal.GetAll(c => c.CarId == carImage.CarId);
            if (carImageDatas.Count > 0)
            {
                foreach (var carImageData in carImageDatas)
                {
                    var result = FileHelper.GetFileData(carImageData.ImagePath);
                    if (result.Length > 0)
                    {
                        carImageViewList.Add(result);
                    }
                }
                return new SuccessDataResult<List<Stream>>(carImageViewList);
            }
            return new ErrorDataResult<List<Stream>>(carImageViewList);
        }

        public IDataResult<CarImage> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IResult Update(CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessDataResult<CarImage>();
        }

        private IResult CheckIfCarImageLimitExceded(CarImage carImage)
        {
            var carImagesNumber = _carImageDal.GetAll(c => c.CarId == carImage.CarId).Count;
            if (carImagesNumber > 4)
            {
                return new ErrorResult(Messages.CarImageLimitExceded);
            }
            return new SuccessResult();
        }


    }
}
