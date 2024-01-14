using OSHABM_proj.Models;
using OSHABM_proj.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OSHABM_proj.Services
{
    public class BookingService
    {
        BookingRepository bookingRepo;
        public BookingService()
        {
            bookingRepo = new BookingRepository();
        }
        public AuditoriumDetails GetAuditoriumById(string id)
        {
            try
            {
                return bookingRepo.GetAuditoriumById(id);
            }
            catch
            {
                throw;
            }
        }
        public List<Booking> GetBookingById(string EmailID)
        {
            try
            {
                return bookingRepo.GetBookingById(EmailID);
            }
            catch
            {
                throw;
            }
        }
        public List<Booking> GetBooking() 
        {
            try
            {
                return bookingRepo.GetBooking();
            }
            catch
            {
                throw;
            }
        }
    }
}