using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace WebApplication5.Irep
{
    public interface ReserveI
    {
        string Insert(ReserveModel b);
       // string Update(ReserveModel b);
        string Delete(int Sno);
       //string testI(sp_GetAllDetails_Result a);

        List<ReserveModel> GetDetails();
        //List<sp_GetAllDetails_Result> sp_getalldetails();

    }
    class reserve : ReserveI
    {
        mouniEntities2 SA = new mouniEntities2();
        string ReserveI.Insert(ReserveModel b)
        {
            var ab = SA.Reservations.Where(x => x.Sno == b.Sno).FirstOrDefault();
            if (ab == null)
            {
                SA.Reservations.Add(new Reservation
                {
                    Sno = b.Sno,
                    Hotel = b.Hotel,
                    Arrival = b.Arrival,
                    Departure = b.Departure,
                    Type = b.Type,
                    Guests = b.Guests,
                    Price = b.Price
                });

                SA.SaveChanges();
                SA.Dispose();
                return "inserted";

            }
            else
            {
                ab.Sno = b.Sno;
                ab.Hotel = b.Hotel;
                ab.Arrival = b.Arrival;
                ab.Departure = b.Departure;
                ab.Type = b.Type;
                ab.Guests = b.Guests;
                ab.Price = b.Price;
            }

            SA.SaveChanges();
            SA.Dispose();
            return "updated";
;
        }
            
         
        List<ReserveModel> ReserveI.GetDetails()
        {
            List<ReserveModel> list = null;
            list = SA.Reservations.Select(c => new ReserveModel()
            {
                Sno = c.Sno,
                Hotel = c.Hotel,
                Arrival = c.Arrival,
                Departure = c.Departure,

                Type = c.Type,
                Guests = c.Guests,
                Price = c.Price
            }).ToList<ReserveModel>();
            return list;


        }
        //string ReserveI.Update(ReserveModel b)
        //{
        //    var ab = SA.Reservations.Where(x => x.Sno == b.Sno).FirstOrDefault();
        //    if (ab != null)
        //    {
        //        ab.Sno = b.Sno;
        //        ab.Hotel = b.Hotel;
        //        ab.Arrival = b.Arrival;
        //        ab.Departure = b.Departure;
        //        ab.Type = b.Type;
        //        ab.Guests = b.Guests;
        //        ab.Price = b.Price;



        //    }

        //    SA.SaveChanges();
        //    SA.Dispose();
        //    return "Updated";

        //}
        string ReserveI.Delete(int Sno)
        {
          
            
                var ab = SA.Reservations.Where(x => x.Sno == Sno).FirstOrDefault();
                if (ab != null)
                {
                    SA.Reservations.Remove(ab);
                }
                SA.SaveChanges();
                return "Deleted";
            }

        //public List<sp_GetAllDetails_Result> sp_getalldetails()
        //{
        //    var a = SA.sp_GetAllDetails().ToList<sp_GetAllDetails_Result>();
        //   return a;
        //}
        //string testI(sp_GetAllDetails_Result a);

        //string ReserveI.testI(sp_GetAllDetails_Result a)
        //{
        //   var b =SA.sp_GetAllDetails.Where()
        //}
    }


}





