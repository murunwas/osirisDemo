using System;
using System.Collections.Generic;
using System.Text;

namespace OSIRIS.Common.Responses.Movies
{
    public class MovieResult
    {
        public int MovieCount { get; set; }
        public int Limit { get; set; }
        public int PageNumber { get; set; }
        public IList<Movie> Movies { get; set; }
    }
}
