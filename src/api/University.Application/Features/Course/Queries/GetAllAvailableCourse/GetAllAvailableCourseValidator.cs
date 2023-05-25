using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Application.Features.Course.Queries.GetAllAvailableCourse
{
    public class GetAllAvailableCourseValidator : AbstractValidator<GetAllAvailableCourseQuery>
    {
        public GetAllAvailableCourseValidator()
        {

        }
    }
}
