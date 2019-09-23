using OSIRIS.Common.Responses.Movies;
using OSIRIS.Repository.Model;
using Refit;
using System.Threading.Tasks;

namespace OSIRIS.Repository.interfaces
{
    public class MyQueryParams
    {
        [AliasAs("limit")]
        public int Limit { get; set; }

        [AliasAs("page")]
        public int Page { get; set; }

        [AliasAs("query_term")]
        public string SearchTerm { get; set; }
    }
    public interface IMovieApi
    {
        [Get("/list_movies.json")]
        Task<MovieResponse> GetMovies(MyQueryParams @params);

        [Get("/movie_details.json")]
        Task<SingleMovieResponse> GetMovie([AliasAs("movie_id")] int id);
    }
}
