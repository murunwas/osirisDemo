using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OSIRIS.Api.Cache;
using OSIRIS.Common.Responses.Movies;
using OSIRIS.Repository.GetMovieById;
using OSIRIS.Repository.GetMovies;
using OSIRIS.Repository.Model;
using System.Threading.Tasks;

namespace OSIRIS.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MovieController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MovieController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get latest movies
        /// </summary>
        /// <returns>List of movies</returns>
        /// <response code="200">Returns Movies results</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">If error occured</response>   
        [HttpGet]
        [Cached(600)]
        public async Task<ActionResult<MovieResponse>> Get(int limit, int page, string searchTerm)
        {
                GetMovieQuery query = new GetMovieQuery {
                    Limit = limit,
                    Page=page,
                    SearchTerm=searchTerm
                };
                var resp = await _mediator.Send(query);
                return Ok(resp);
           
        }

        /// <summary>
        /// Get a single movie.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Movie response</returns>
        /// <response code="200">Returns Single Movie results</response>
        /// <response code="500">If error occured</response>  
        [HttpGet("{id:int}")]
        [Cached(600)]
        public async Task<ActionResult<SingleMovieResponse>> Get(int id)
        {
            GetMovieByIdQuery query = new GetMovieByIdQuery(id);
            var resp = await _mediator.Send(query);
            return Ok(resp);

        }
    }
}