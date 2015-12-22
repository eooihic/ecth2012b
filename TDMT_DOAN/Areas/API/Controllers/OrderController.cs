using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using TDMT_DOAN.Areas.API.Filters;
using TDMT_DOAN.Areas.API.Models;

namespace TDMT_DOAN.Areas.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [IdentityBasicAuthentication]
    
    public class OrderController : ApiController
    {
        static readonly IOrderRepository repository = new OrderRepository();

        public HttpResponseMessage CreateResponse<T>(HttpStatusCode statusCode, T data)
        {
            return Request.CreateResponse(statusCode, data);
        }

        public HttpResponseMessage CreateResponse(HttpStatusCode httpStatusCode)
        {
            return Request.CreateResponse(httpStatusCode);
        }

        [HttpGet]
        [Authorize]
        [Route("orders/{consumer_key:guid}")]
        public HttpResponseMessage GetAllOrder(Guid consumer_key)
        {
            return CreateResponse(HttpStatusCode.OK, repository.GetAll(consumer_key));
        }


        [HttpPost]
        [Authorize]
        [Route("orders/start_shipping")]
        public HttpResponseMessage AddOrderShipping([FromBody] OrderShipping sv)
        {
            repository.Add(sv);
            return CreateResponse(HttpStatusCode.OK);
        }

    }
}
