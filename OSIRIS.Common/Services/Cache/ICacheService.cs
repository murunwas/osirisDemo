﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OSIRIS.Common.Services.Cache
{
    public interface ICacheService
    {
        Task CacheResponseAsync(string cacheKey, object response, TimeSpan timeTimeLive);

        Task<string> GetCachedResponseAsync(string cacheKey);
    }
}
