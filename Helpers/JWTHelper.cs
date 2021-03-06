
using System;
using System.Text;
using JWT.Algorithms;
using JWT.Builder;
using NOWA.Models;

namespace NOWA.Helpers
{
    public class JWTHelper
    {
        public static string CreateToken(User user, string configuration)
        {
            var key = Encoding.ASCII.GetBytes(configuration);
            
            var token = new JwtBuilder()
            .WithAlgorithm(new HMACSHA512Algorithm())
            .WithSecret(key)
            .AddClaim("exp", DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeMilliseconds())
            .AddClaim("userId", user.Id)
            .Encode();

            return token;
        }
    }
}