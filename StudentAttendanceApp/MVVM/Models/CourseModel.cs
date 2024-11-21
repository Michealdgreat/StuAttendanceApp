using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceApp.MVVM.Models
{
    public class CourseModel
    {
        public Guid CourseId { get; set; }
        public string? CourseName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
