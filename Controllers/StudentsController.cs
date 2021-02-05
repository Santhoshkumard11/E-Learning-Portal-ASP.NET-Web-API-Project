using HandsOnWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HandsOnWebAPI.Controllers
{
    public class StudentsController : ApiController
    {
        private readonly HandsOnWebAPIContext db = new HandsOnWebAPIContext();
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, db.Students.ToList());
        }

        public HttpResponseMessage Get(int id)
        {

            var result = db.Students.FirstOrDefault(s => s.Id == id);

            if (result != null)
            {
             return Request.CreateResponse(HttpStatusCode.OK, result);

            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, $"student with Id {id} not found!!");
            }

        }



    }
}
