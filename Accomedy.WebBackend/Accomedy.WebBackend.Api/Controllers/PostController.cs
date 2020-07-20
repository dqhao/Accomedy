
using System.Web.Http;
using Accomedy.WebBackend.Data;
using Accomedy.WebBackend.Model;

namespace Accomedy.WebBackend.Api.Controllers
{
    public class PostController : ApiController
    {
        #region Properties
        public IPostRepository _postRepo;
        #endregion

        #region Contructors
        public PostController(IPostRepository postRepository)
        {
            _postRepo = postRepository;
        }
        #endregion

        #region Self APIs
        public IHttpActionResult Post2Search(SearchModel criteria)
        {
            return null;
        }
        #endregion

    }
}