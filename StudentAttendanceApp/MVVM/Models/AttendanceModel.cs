using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceApp.MVVM.Models
{
    public class AttendanceModel
    {
        public Guid AttendanceId { get; set; }
        public Guid SessionId { get; set; }
        public Guid StudentId { get; set; }
        public DateTime SignInAt { get; set; }
        public DateTime SignOutAt { get; set; }
    }
}
