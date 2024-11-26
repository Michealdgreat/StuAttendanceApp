using Microsoft.Maui.Graphics.Text;
using StudentAttendanceApp.MVVM.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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

        //public async Task CheckToken()
        //{
        //    var storedToken = await GetTokenAsync();
        //    if (!string.IsNullOrWhiteSpace(storedToken))
        //    {
        //        var userDetails = DecodeJwtToken(storedToken);

        //        //var currentDetails = await FetchUserDetailsFromApi(userDetails.UserId);

        //        //if (userDetails.RoleName != currentDetails.RoleName || userDetails.UserId != currentDetails.UserId)
        //        //{
        //        //    _secureStorageService.DeleteToken();
        //        //    // TODO: Load login page
        //        //}
        //    }
        //}

        public async Task<UserModel> GetUserDetailsFromToken()
        {
            var storedToken = await GetTokenAsync();
            if (!string.IsNullOrWhiteSpace(storedToken))
            {
                var userDetails = DecodeJwtToken(storedToken);

                return userDetails;
            }
            else
            {
                return default!;
            }
        }


        public static UserModel DecodeJwtToken(string jwtToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(jwtToken) as JwtSecurityToken;

            var email = jsonToken!.Claims.FirstOrDefault(claim => claim.Type == "email")?.Value;
            var roleName = jsonToken.Claims.FirstOrDefault(claim => claim.Type == "role")?.Value;

            var userId = jsonToken.Claims.FirstOrDefault(claim => claim.Type == "nameid")?.Value;

            Guid newUserId = Guid.Parse(userId!);

            return new UserModel
            {
                Email = email,
                Role = roleName,
                UserId = newUserId
            };
        }
    }
}
