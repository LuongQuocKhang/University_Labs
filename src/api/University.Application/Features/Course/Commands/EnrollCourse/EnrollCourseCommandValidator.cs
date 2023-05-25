using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Application.Features.Course.Queries.GetAllAvailableCourse;

namespace University.Application.Features.Course.Commands.EnrollCourse
{

    public class EnrollCourseCommandValidator : AbstractValidator<EnrollCourseCommand>
    {
        public EnrollCourseCommandValidator()
        {
            RuleFor(x => x.CourseId)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .LessThanOrEqualTo(0).WithMessage("Course Id must be greater then zero!");

            RuleFor(x => x.UserName)
                .NotNull()
                .NotEmpty().WithMessage("User Name can not be empty")
                .MinimumLength(10).WithMessage("Invalud User Email");
        }
    }
}
