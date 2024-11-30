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

        // User Endpoints
        public const string loginEndPoint = $"{baseUrl}/User/Login";
        public const string GetUserByIdEndPoint = $"{baseUrl}/User/";
        public const string RegisterUserEndpoint = $"{baseUrl}/user/Register";
        public const string DeleteUser = $"{baseUrl}/user/DeleteUser";

        // Attendance Endpoints
        public const string CreateAttendanceRecord = $"{baseUrl}/attendance/CreateAttendanceRecord";
        public const string DeleteAttendanceRecord = $"{baseUrl}/attendance/DeleteAttendanceRecord";
        public const string GetAttendanceByDate = $"{baseUrl}/attendance/GetAttendanceByDate";
        public const string GetAttendanceBySessionId = $"{baseUrl}/attendance/GetAttendanceBySessionId";
        public const string UpdateAttendanceRecord = $"{baseUrl}/attendance/UpdateAttendanceRecord";

        // Course Endpoints
        public const string CreateCourse = $"{baseUrl}/course/CreateCourse";
        public const string DeleteCourse = $"{baseUrl}/course/DeleteCourse";
        public const string GetCourseById = $"{baseUrl}/course/GetCourseById";
        public const string GetCourses = $"{baseUrl}/course/GetCourses";
        public const string GetCourseByName = $"{baseUrl}/course/GetCourseByName";
        public const string GetCoursesByTeacherId = $"{baseUrl}/course/GetCoursesByTeacherId";
        public const string UpdateCourse = $"{baseUrl}/course/UpdateCourse";

        // Session Endpoints
        public const string CreateSession = $"{baseUrl}/session/CreateSession";
        public const string DeleteSession = $"{baseUrl}/session/DeleteSession";
        public const string GetAllSessions = $"{baseUrl}/session/GetAllSessions";
        public const string GetSessionByCourseId = $"{baseUrl}/session/GetSessionByCourseId";
        public const string GetSessionById = $"{baseUrl}/session/GetSessionById";
        public const string UpdateSession = $"{baseUrl}/session/UpdateSession";

    }
}
