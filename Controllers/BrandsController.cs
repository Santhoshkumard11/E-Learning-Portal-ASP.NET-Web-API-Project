using HandsOnWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HandsOnWebAPI.Controllers
{
    public class BrandsController : ApiController
    {

        public static List<Brand> brandsList = new List<Brand>() {

        new Brand() {BrandId ="B001" , Name="Haro"},
        new Brand() {BrandId ="B002" , Name="Electra"},
        new Brand() {BrandId ="B003" , Name="Heller"}

        };


        //GET: api/Brands
        public  List<Brand> Get()
        {
            return brandsList;
        }

        // GET: api/Brands/5
        public HttpResponseMessage Get(string BrandId)
        {

            return Request.CreateErrorResponse(HttpStatusCode.OK, (brandsList.Find(b => b.BrandId == BrandId)).Name);

        }

        // POST: api/Brands
        public HttpResponseMessage Post([FromUri] Brand brand)
        {

            brandsList.Add(brand);

            return Request.CreateErrorResponse(HttpStatusCode.OK, brand.Name);

        }

        // PUT: api/Brands/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Brands/5
        public void Delete(int id)
        {
        }
    }
}
