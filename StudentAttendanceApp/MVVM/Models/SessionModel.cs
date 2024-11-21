using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceApp.MVVM.Models
{
    public class SessionModel
    {
        public Guid SessionId { get; set; }
        public Guid CourseId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartAt { get; set; }
        public TimeSpan EndAt { get; set; }
        public string? Name { get; set; }
    }
}
