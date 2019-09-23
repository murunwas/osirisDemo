using System;
using System.Collections.Generic;
using System.Text;

namespace OSIRIS.Common.Responses.Movies
{
    public class MovieResponse
    {
        public string Status { get; set; }
        public string StatusMessage { get; set; }
        public MovieResult Data { get; set; }
    }
}
