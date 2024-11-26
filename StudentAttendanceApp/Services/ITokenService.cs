using StudentAttendanceApp.MVVM.Models;
using System;
using System.Linq;

namespace StudentAttendanceApp.Services
{
    public interface ITokenService
    {
        void DeleteToken();
        Task<string?> GetTokenAsync();
        Task<UserModel> GetUserDetailsFromToken();
        Task SaveTokenAsync(string token);
    }
}
