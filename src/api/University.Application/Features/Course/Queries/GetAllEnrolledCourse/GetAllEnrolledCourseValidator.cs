using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Application.Features.Course.Queries.GetAllAvailableCourse;

namespace University.Application.Features.Course.Queries.GetAllEnrolledCourse
{
    public class GetAllEnrolledCourseValidator : AbstractValidator<GetAllEnrolledCourseQuery>
    {
        public GetAllEnrolledCourseValidator()
        {
            RuleFor(p => p.UserId)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage("{UserId} should be greater than zero.");

            //RuleFor(p => p.Email)
            //    .Cascade(CascadeMode.Stop)
            //    .NotEmpty().WithMessage("{Email} is required")
            //    .NotNull().WithMessage("{Email} is required")
            //    .MaximumLength(50).WithMessage("{UserName} must not exceed 50 characters.");
        }
    }
}
