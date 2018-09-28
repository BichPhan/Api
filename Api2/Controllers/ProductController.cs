using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataModel;

namespace Api2.Controllers
{
    [RoutePrefix("v1/Products/Product")]
    public class ProductController : ApiController
    {
        DataAccess dt = new DataAccess();

        // GET api/<controller>
        // [GET("allok")]
        [Route("all")]
        public HttpResponseMessage Get()
        {
            var products = dt.getProduct();
            if (products.Any())
                return Request.CreateResponse(HttpStatusCode.OK, products);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Products not found");
        }

        // GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<controller>
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}