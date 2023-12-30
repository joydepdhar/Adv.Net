using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;

namespace PostComment.Controllers
{
    public class PostController : ApiController
    {
        [HttpGet]
        [Route("api/Posts")]
        public HttpResponseMessage Posts()
        {
            try
            {
                var data = PostService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,new { Message= ex.Message});
            }
        }
        [HttpPost]
        [Route("api/Addusers")]
        public HttpResponseMessage AddUser(UserDTO u)
        {
            try
            {
                var data = UserService.AddUser(u);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, new {Message = "Invalid Data"});
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpPost]
        [Route("api/UpdateUser")]
        public HttpResponseMessage update(UserDTO u)
        {
            try
            {
                var data = UserService.UpdateUser(u);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Invalid Data" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }


    }
}
