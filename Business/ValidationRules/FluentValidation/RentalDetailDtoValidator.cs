﻿using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalDetailDtoValidator : AbstractValidator<RentalDetailDto>
    {
        public RentalDetailDtoValidator()
        {

        }
    }
}
