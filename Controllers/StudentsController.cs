using HandsOnWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity.Migrations;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

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

        public HttpResponseMessage Put(int id, [FromBody] Student student)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Make sure you have all the model values correct!!");
            }

            db.Entry(student).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, $"Student with the {id} doesn't exist!!");
                }

            }

            return Request.CreateResponse(HttpStatusCode.OK, student);

        }

        public bool StudentExists(int id)
        {

            return db.Students.Count(s => s.Id == id) > 0;
        }


        public HttpResponseMessage Post([FromBody] Student student)
        {

            

            if(!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Fill all the fields of the student");
            }

            try
            {

                db.Students.Add(student);
                db.SaveChanges();
            }
            catch ( Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

            return Request.CreateResponse(HttpStatusCode.Created, student);
        }

    }
}
