using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace API_erstellen.Controllers
{
    public class EmployeeController : ApiController
    {
        private static List<string> testData = new List<string>(new String[] { "Mitarbeiter1", "Andreas", "Hans", "Eddy" });

        // GET: api/Employee
        [ResponseType(typeof(List<string>))]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, testData);
        }

        // GET: api/Employee/name
        [HttpGet]
        [Route("api/Employee/{name}")]
        public HttpResponseMessage Get(string name)
        {
            if (!testData.Contains(name))
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, name);
        }

        // POST: api/Employee
        public HttpResponseMessage Post(string value)
        {
            testData.Add(value);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        // DELETE: api/Employee/5
        public HttpResponseMessage Delete(int id)
        {
            testData.RemoveAt(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
