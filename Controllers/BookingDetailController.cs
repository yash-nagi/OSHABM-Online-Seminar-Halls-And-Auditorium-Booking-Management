using OSHABM_proj.Models;
using OSHABM_proj.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using static System.Collections.Specialized.BitVector32;

namespace OSHABM_proj.Controllers
{
    public class BookingDetailController : Controller
    {
        BookingService _bookingService = new BookingService();
        // GET: BookingDetail
        public ActionResult Booking(string EmailID)
        {
            try
            {
                List<Booking> bookinglist = _bookingService.GetBookingById(EmailID);
                return View(bookinglist);                
            }
            catch(Exception ex)
            {

            }
            return View();
        }

        public ActionResult Bookingdata()
        {
            try
            {
                List<Booking> bookinglist = _bookingService.GetBooking();
                return View(bookinglist);
            }
            catch(Exception ex)
            {

            }
            return View();
        }
        //GET:
       

        //[HttpPost]
        //public ActionResult LoginToBooking(Login obj)
        //{
        //    try
        //    {
        //        using (SqlHelper helper = new SqlHelper())
        //        {
        //            SqlParameter[] param =
        //            {
        //                new SqlParameter("@EmailID",obj.EmailID)                        
        //            };
        //            SqlDataReader dr = helper.ExecuteReaderByProc("usp_ValidateUserForBooking_tbl_login", param);
        //            dr.Read();
        //            if (dr.HasRows)
        //            {
        //                if (dr["Role"].ToString().Equals("1"))
        //                {                            
        //                    return RedirectToAction("Booking", "BookingDetail");
        //                }
        //                else if (dr["Role"].ToString().Equals("0"))
        //                {
        //                    return RedirectToAction("Booking", "BookingDetail");
        //                }
        //                else
        //                {
        //                    return RedirectToAction("Login", "Welcome");
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return View();
        //}
     

        // GET: BookingDetail/Details/5
        public ActionResult Details(string id)
        {
            try
            {
                AuditoriumDetails Booking = _bookingService.GetAuditoriumById(id);
                return View(Booking);
                //Session["AuditID"] = Booking.AuditID.ToString();
            }
            catch(Exception ex)
            {

            }
            return View();
        }

        // GET: BookingDetail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookingDetail/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BookingDetail/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BookingDetail/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BookingDetail/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BookingDetail/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
