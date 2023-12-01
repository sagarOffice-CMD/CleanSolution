using Application.DTO;
using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validator
{
    public class StudentValidator :AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(s => s.Name).Length(0, 10).NotNull();
            RuleFor(s => s.Email).EmailAddress();
            
           
        }

    }
}
