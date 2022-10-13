using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTAuthentication
{
    public class JWTToken
    {
        public static string? secret_key = Environment.GetEnvironmentVariable("SECRET_KEY");
    }
}