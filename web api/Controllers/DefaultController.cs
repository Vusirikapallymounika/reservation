using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication5.Irep;
using WebApplication5.Models;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace WebApplication5.Controllers
{
    public class DefaultController : ApiController
    {

        public readonly EmployI Regrep;
        private DefaultController() { }
        public DefaultController(EmployI regrep)
        {
            this.Regrep = regrep;
        }

        //internal reginterface regrep => localiregrep;
        [Route("api/Default/info")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var ret = Regrep.GetAllstudents();
            if (ret.Count == 0)
            {
                return NotFound();
            }
            return Ok(ret);
        }

        [Route("api/Default/del/{stu_name}")]
        [HttpDelete]
        public IHttpActionResult Delete(string stu_name)
        {
            var data = Regrep.Delete(stu_name);

            if (data != null)
            {
                return Ok(data);
            }
            return NotFound();
        }



        [Route("api/Default/ins")]
        [HttpPost]
        public IHttpActionResult Insert(Student name)
        {
            var B = Regrep.Insert(name);
            if (B == "updated")
            {
                return Ok(B);
            }
            return NotFound();
        }
        [Route("api/Default/upd")]
        [HttpPost]
        public IHttpActionResult Update(Student c)
        {
            var up = Regrep.Update(c);
            if (up == "Updated")
            {
                return Ok(up);
            }
            return NotFound();
        }


        [Route("api/Default/bulkdelete")]

        [HttpPost]
        public HttpResponseMessage Bulkdelete(List<student> y)
        {
            var abc = Regrep.BulkDelete(y);
            return Request.CreateResponse(HttpStatusCode.OK, abc);
        }


        [Route("api/Default/bulkinsert")]
        [HttpPost]
        public HttpResponseMessage BulkInsert(List<Student> x)
        {
            var m = Regrep.BulkInsert(x);
            return Request.CreateResponse(HttpStatusCode.OK, m);
        }
        [Route("api/Default/Getid/{id}")]
        [HttpGet]
        public IHttpActionResult Getid(int id)
        {
            var em = Regrep.Getid(id);
            if (em == null)
            {
                return NotFound();

            }



            return Ok(em);
        }






    }
}





