using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {

        IResult Add(CarImage carImage);
        IResult Update(CarImage carImage);
        IResult Delete(CarImage carImage);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> Get(int id);

        IResult SaveFile(IFormFile formFile, CarImage carImage);
        IResult DeleteFile(CarImage carImage);
        IResult UpdateFile(IFormFile formFile, CarImage carImage);
        IDataResult<List<byte[]>> GetFileData(CarImage carImage);
    }
}
