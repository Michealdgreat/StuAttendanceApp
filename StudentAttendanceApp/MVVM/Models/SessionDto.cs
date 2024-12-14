using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceApp.MVVM.Models
{
    public class SessionDto
    {
        public Guid SessionId { get; set; }
        public string? SessionName { get; set; }
        public DateTime SessionDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public TimeSpan TotalDuration { get; set; }
        public Guid CourseId { get; set; }
        public string? CourseName { get; set; }
        public Guid TeacherId { get; set; }
        public string? TeacherFirstName { get; set; }
        public string? TeacherLastName { get; set; }
        public string? TeacherEmail { get; set; }

    }
}
