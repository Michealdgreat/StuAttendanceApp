using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceApp.MVVM.Models
{

    public class PostResponseMessage
    {
        public string? Message { get; set; }
        public string? Title { get; set; }
        public int? Status { get; set; }
    }
}
