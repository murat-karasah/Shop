﻿namespace Shop.API.Infrastructure.Tools
{
    public class JwtTokenResponse
    {
        public string Token { get; set; }

        public JwtTokenResponse(string token)
        {
            Token = token;
        }
    }
}
