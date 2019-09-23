using OSIRIS.Repository.interfaces;
using Refit;

namespace OSIRIS.Repository.Common
{
    public abstract class BaseHandler
    {
        protected readonly IMovieApi _movieApi;
        public BaseHandler()
        {
            _movieApi = RestService.For<IMovieApi>("https://yts.lt/api/v2");
        }
    }
}
