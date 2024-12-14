using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceApp.MVVM.Models
{
    public class UserDtoForClaims
    {
        public Guid UserId { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
    }
}
