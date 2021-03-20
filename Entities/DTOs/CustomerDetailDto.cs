using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CustomerDetailDto:IDto
    {
        public int Id { get; set; }
        public string CustomerFullName { get; set; }
        public string CompanyName { get; set; }
    }
}
