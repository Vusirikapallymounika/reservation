using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApplication5.Irep;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    [EnableCors(origins:"*",headers:"*",methods:"*")]
    public class ReservationController : ApiController
    {
        private readonly ReserveI Res;
        public ReservationController(ReserveI res)
        {
            this.Res = res;
        }
        [Route("api/Reservation/insert")]
        [HttpPost]
        public IHttpActionResult Insert(ReserveModel b)
        {
            var status = Res.Insert(b);
            if (status == "inserted") 
            {
                return Ok(status);
            }
            else if (status== "updated") 
            {

                return Ok(status);
            }
            return NotFound();
        }
        [Route("api/Reservation/get")]
        [HttpGet]
        public IHttpActionResult GetDetails()
        {
            var ret = Res.GetDetails();
            if (ret.Count == 0)
            {
                return NotFound();
            }
            return Ok(ret);
        }
        //[Route("api/Reservation/update")]
        //[HttpPost]
        //public IHttpActionResult Update(ReserveModel b)
        //{
        //    var up = Res.Update(b);
        //    if (up == "Updated") 
        //    {
        //        return Ok(up);
        //    }
        //    return NotFound();
        //}
        [Route("api/Reservation/Delete/{Sno}")]
        [HttpDelete]
        public IHttpActionResult Delete(int Sno)
        {
            var ab = Res.Delete(Sno);
            if (ab != null)
            {

                return Ok(ab);
            }
            return NotFound();
        }
        //[Route("api/Reservation/test")]
        //[HttpGet]
        //public IHttpActionResult test()
        //{
        //    var ret = Res.sp_getalldetails();
        //    return Ok(ret);
        //}



    }
}
