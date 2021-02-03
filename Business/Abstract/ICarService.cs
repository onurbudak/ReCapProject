using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService<TEntity> where TEntity: class, IEntity, new()
    {
       
    }
}
