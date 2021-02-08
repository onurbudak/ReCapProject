using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        void Add(Color entity);
        void Update(Color entity);
        void Delete(Color entity);
        List<Color> GetAll();
        Color Get(int id);
    }
}
