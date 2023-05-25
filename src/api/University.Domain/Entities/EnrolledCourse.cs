using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Common;

namespace University.Domain.Entities
{
    public class EnrolledCourse : EntityBase
    {
        public int CourseId { get; set; }
        public string UserName { get; set; }
    }
}
