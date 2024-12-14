using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceApp.Services
{
    public static class EndPoints
    {
        private const string baseUrl = "https://www.tapin.linkpc.net/api";
        private const string baseUrl2 = "https://www.tapin.linkpc.net";

        // User Endpoints
        public const string loginEndPoint = $"{baseUrl}/user/Login";
        public const string loginHubEndPoint = $"{baseUrl2}/loginHub";
        public const string GetUserByIdEndPoint = $"{baseUrl}/user/";
        public const string GetUserByTagIdEndPoint = $"{baseUrl}/user/GetByTagId?tagId=";
        public const string RegisterUserEndpoint = $"{baseUrl}/user/Register";
        public const string DeleteUser = $"{baseUrl}/user/DeleteUser";

        // Attendance Endpoints
        public const string CreateAttendanceRecord = $"{baseUrl}/attendance/CreateAttendanceRecord";
        public const string DeleteAttendanceRecord = $"{baseUrl}/attendance/DeleteAttendanceRecord";
        public const string GetAttendanceBySessionAndStudentId = $"{baseUrl}/attendance/GetAttendanceBySessionAndStudentId?sessionId={{0}}&studentId={{1}}";
        public const string GetAttendanceBySessionId = $"{baseUrl}/attendance/GetAttendanceBySessionId?sessionId=";
        public const string UpdateAttendanceRecord = $"{baseUrl}/attendance/UpdateAttendanceRecord";

        // Course Endpoints
        public const string CreateCourse = $"{baseUrl}/course/CreateCourse";
        public const string DeleteCourse = $"{baseUrl}/course/DeleteCourse";
        public const string GetCourseById = $"{baseUrl}/course/GetCourseById?courseId=";
        public const string GetCourseByName = $"{baseUrl}/course/GetCourseByName?courseName=";
        public const string GetCoursesByTeacherId = $"{baseUrl}/course/GetCoursesByTeacherId?teacherId=";
        public const string UpdateCourse = $"{baseUrl}/course/UpdateCourse";

        // Session Endpoints
        public const string CreateSession = $"{baseUrl}/session/CreateSession";
        public const string DeleteSession = $"{baseUrl}/session/DeleteSession";
        public const string GetAllSessions = $"{baseUrl}/session/GetAllSessions";
        public const string GetSessionByCourseId = $"{baseUrl}/session/GetSessionByCourseId?courseId=";
        public const string GetSessionById = $"{baseUrl}/session/GetSessionById?sessionId=";
        public const string UpdateSession = $"{baseUrl}/session/UpdateSession";
    }
}
