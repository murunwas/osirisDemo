using MediatR;
using OSIRIS.Common.Responses.Movies;
using OSIRIS.Repository.Common;
using OSIRIS.Repository.interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OSIRIS.Repository.GetMovies
{
    public class GetMovieQuery:IRequest<MovieResponse>
    {
        public int Limit { get; set; }
        public int Page { get; set; }
        public string SearchTerm { get; set; }
    }

    public class GetMovieQueryHandler : BaseHandler, IRequestHandler<GetMovieQuery, MovieResponse>
    {
        public async Task<MovieResponse> Handle(GetMovieQuery request, CancellationToken cancellationToken)
        {
           
            try
            {
                var  movies = await _movieApi.GetMovies(new MyQueryParams {
                     Limit = request.Limit,
                     Page= request.Page,
                     SearchTerm= request.SearchTerm
                 });
                return await Task.FromResult(movies);
            }
            catch (Exception)
            {
                throw;
            }
           
        }
    }
}
