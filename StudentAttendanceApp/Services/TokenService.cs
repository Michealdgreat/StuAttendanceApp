using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceApp.Services
{
    public class TokenService : ITokenService
    {
        private const string TokenKey = "jwt_token";

        public async Task SaveTokenAsync(string token)
        {
            await SecureStorage.Default.SetAsync(TokenKey, token);
        }

        public async Task<string?> GetTokenAsync()
        {
            return await SecureStorage.Default.GetAsync(TokenKey);
        }

        public void DeleteToken()
        {
            SecureStorage.Default.Remove(TokenKey);
        }
    }
}
