using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceApp.Services
{
    public static class EndPoints
    {
        private const string baseUrl = "https://";
        public const string loginEndPoint = $"{baseUrl}/StudentattendanceApi/User/Login";
        public const string GetUserByIdEndPoint = $"{baseUrl}/StudentattendanceApi/User/Id/";


    }
}
