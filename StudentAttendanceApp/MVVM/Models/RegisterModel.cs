using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceApp.MVVM.Models
{
    public class RegisterModel
    {
        public Guid UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? TagId { get; set; }
        public int UserRole { get; set; }
        public string? AvatarUrl { get; set; }
        public string? Department { get; set; }
        public string? StudentGroup { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
