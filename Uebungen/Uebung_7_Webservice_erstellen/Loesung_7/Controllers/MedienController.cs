using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Webservice_erstellen_REST.Controllers
{
    public class MedienController : ApiController  {

        // Daten
        private static List<string> testData = new List<string> (new String[] {"Herr der Ringe","Titanic","Venum", "Little Foot"});

        public HttpResponseMessage GetMedien()
        {
            return Request.CreateResponse(HttpStatusCode.OK, testData);
        }

        //[HttpGet]
        //[Route("api/Medien/Video/{id}")]
        public HttpResponseMessage Get(string id)
        {
            int pid;
            Int32.TryParse(id, out pid);

            if (testData.Count > pid)
            {
                return Request.CreateResponse(HttpStatusCode.OK, testData[pid]);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        [HttpGet]
        [Route("api/Medien/Name/{name}")]
        public HttpResponseMessage GetMedienByName(string name)
        {
            if (!testData.Contains(name))
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, name);
        }

        public HttpResponseMessage Delete(int id)
        {
            int pid;
            Int32.TryParse(id, out pid);

            if (testData.Count > pid)
            {
                testData.RemoveAt(id);
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        public HttpResponseMessage Create(string title)
        {
            testData.Add(title);
            return Request.CreateResponse(HttpStatusCode.Created);
        }
    }
}
