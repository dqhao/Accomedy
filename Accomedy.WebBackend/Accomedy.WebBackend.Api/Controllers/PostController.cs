using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Accomedy.WebBackend.Business;
using Accomedy.WebBackend.Entities;
using Accomedy.WebBackend.Model;

namespace Accomedy.WebBackend.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/posts")]
    public class PostController : BaseApi
    {

        public IPostManager _postMgr
        {
            get
            {
                return postMgr;
            }
        }


        public PostController(IPostManager postManager) : base()
        {
            postMgr = postManager;
        }

        [HttpGet]
        [Route("get-detail")]
        public IHttpActionResult GetPostByID(string postID)
        {
            try
            {
                var result = _postMgr.GetDetailById(postID);
                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("search-result")]
        public IHttpActionResult Post2Search([FromBody] SearchModel criteria)
        {
            IHttpActionResult resp;
            if (criteria == null)
            {
                resp = BadRequest();
            }
            else
            {
                var results = _postMgr.Search(criteria);
                if (results == null)
                {
                    var ex = new NullReferenceException("incorrect_result");
                    throw ex;
                }
                else
                {
                    resp = Ok(results);
                }

            }

            return resp;
        }


        private IPostManager postMgr;
    }
}
