using System;

namespace OSIRIS.Common.Services.Auth
{
    public class AuthSettings
    {
        public string Secret { get; set; }
        public TimeSpan TokenLifetime { get; set; }
    }
}
