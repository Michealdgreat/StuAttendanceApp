using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceApp.Services
{
    public static class EndPoints
    {
        private const string baseUrl = "https://zr2r4n7r-7105.euw.devtunnels.ms/api";
        public const string loginEndPoint = $"{baseUrl}/User/Login";
        public const string GetUserByIdEndPoint = $"{baseUrl}/User/";


    }
}
