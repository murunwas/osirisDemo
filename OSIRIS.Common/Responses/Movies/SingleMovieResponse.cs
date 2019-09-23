using System;
using System.Collections.Generic;
using System.Text;

namespace OSIRIS.Common.Responses.Movies
{
    public class SingleMovieResponse
    {
        public string Status { get; set; }
        public string StatusMessage { get; set; }
        public SingleMovie Data { get; set; }
    }
}
