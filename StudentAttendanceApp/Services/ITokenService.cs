﻿using System;
using System.Linq;

namespace StudentAttendanceApp.Services
{
    public interface ITokenService
    {
        void DeleteToken();
        Task<string?> GetTokenAsync();
        Task SaveTokenAsync(string token);
    }
}