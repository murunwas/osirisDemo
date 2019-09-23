using MediatR;
using OSIRIS.Common.Responses.Movies;
using OSIRIS.Repository.Common;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OSIRIS.Repository.GetMovieById
{
    public class GetMovieByIdQuery : IRequest<SingleMovieResponse>
    {
        public int Id { get; set; }

        public GetMovieByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetMovieByIdQueryHandler : BaseHandler, IRequestHandler<GetMovieByIdQuery, SingleMovieResponse>
    {
        public async Task<SingleMovieResponse> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
        {
           // var me = "djfjdjf";
            //var test = int.Parse(me);

                var response =await  _movieApi.GetMovie(request.Id);
                return await Task.FromResult(response);
            
       
           
        }
    }
}
