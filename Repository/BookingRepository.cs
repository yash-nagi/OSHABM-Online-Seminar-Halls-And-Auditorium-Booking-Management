using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OSHABM_proj.Models;

namespace OSHABM_proj.Repository
{
    public class BookingRepository
    {
        public AuditoriumDetails GetAuditoriumById(string id)
        {
            AuditoriumDetails auditorium = null;
            try
            {

                using (SqlHelper helper = new SqlHelper())
                {
                    SqlParameter[] param =
                    {
                    new SqlParameter("@AuditID",id)

                    };
                    DataTable dt = helper.GetDataTable("usp_GetAuditoriumData_auditorium_detail", param);

                    if (dt.Rows.Count > 0)
                    {
                        auditorium = new AuditoriumDetails
                        {
                            AuditID = dt.Rows[0]["AuditID"].ToString(),
                            Name = dt.Rows[0]["Name"].ToString(),
                            Location = dt.Rows[0]["Location"].ToString(),
                            Type = dt.Rows[0]["Type"].ToString(),
                            Price = Convert.ToDecimal(dt.Rows[0]["Price"].ToString()),
                            Phone = Convert.ToInt64(dt.Rows[0]["Mobile"].ToString())
                        };
                    }
                }
            }
            catch
            {
                throw;
            }

            return auditorium;
        }
        //  ============= Showing Booking details to user/ Client====================
        //public Booking GetBookingById(string EmailID)
        //{
            
        //    Booking booking = null;
        //    try
        //    {

        //        using (SqlHelper helper = new SqlHelper())
        //        {
        //            SqlParameter[] param =
        //            {
        //            new SqlParameter("@EmailID",EmailID)

        //            };
        //            DataTable dt = helper.GetDataTable("usp_GetBookingDetail_booking_detail", param);

        //            if (dt.Rows.Count > 0)
        //            {
        //                booking = new Booking
        //                {
        //                    EmailID = dt.Rows[0]["EmailID"].ToString(),
        //                    BookingId = dt.Rows[0]["Booking_ID"].ToString(),
        //                    UserId = dt.Rows[0]["UserID"].ToString(),
        //                    AuditId = dt.Rows[0]["AuditID"].ToString(),
        //                    Date_of_Booking = (DateTime)dt.Rows[0]["Date_of_Booking"],
        //                    Time_of_Booking = TimeSpan.Parse(dt.Rows[0]["Time_of_Booking"].ToString()),
        //                    PayId = dt.Rows[0]["PayID"].ToString()                            
        //                };
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }

        //    return booking;
        //}
        public List<Booking> GetBookingById(string EmailID)
        {
            List<Booking> bookinglist = new List<Booking>();
            try
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    SqlParameter[] param = 
                    {
                        new SqlParameter("@EmailID",EmailID)
                    };
                    DataTable dt = helper.GetDataTable("usp_GetBookingDetail_booking_detail", param);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            Booking bookingObject = new Booking
                            {
                                EmailID = dt.Rows[i]["EmailID"].ToString(),
                                BookingId = dt.Rows[i]["Booking_ID"].ToString(),
                                UserId = dt.Rows[i]["UserID"].ToString(),
                                AuditId = dt.Rows[i]["AuditID"].ToString(),
                                Date_of_Booking = (DateTime)dt.Rows[i]["Date_of_Booking"],
                                Time_of_Booking = TimeSpan.Parse(dt.Rows[i]["Time_of_Booking"].ToString()),
                                PayId = dt.Rows[i]["PayID"].ToString()
                            };
                            bookinglist.Add(bookingObject);
                        }
                    }
                }
            }
            catch
            {
                throw;
            }

            return bookinglist;
        }

        public List<Booking> GetBooking()
        {
            List<Booking> bookingList = new List<Booking>();
            try
            {
                using (SqlHelper helper = new SqlHelper())
                {
                   
                    DataTable dt = helper.GetDataTableByproc("usp_GetAllBookingDetails_booking_detail");
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            Booking bookingObject = new Booking
                            {
                                EmailID = dt.Rows[i]["EmailID"].ToString(),
                                AuditId = dt.Rows[i]["AuditID"].ToString(),
                                UserId = dt.Rows[i]["UserID"].ToString(),
                                BookingId = dt.Rows[i]["Booking_ID"].ToString(),
                                PayId = dt.Rows[i]["PayID"].ToString(),
                                Date_of_Booking = (DateTime)dt.Rows[i]["Date_of_Booking"],
                                Time_of_Booking = TimeSpan.Parse(dt.Rows[i]["Time_of_Booking"].ToString()),
                            };
                            bookingList.Add(bookingObject);
                        }
                    }
                }
            }
            catch
            {
                throw;
            }

            return bookingList;
        }
    }
}