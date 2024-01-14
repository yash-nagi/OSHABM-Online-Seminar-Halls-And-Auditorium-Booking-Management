using OSHABM_proj.Models;
using OSHABM_proj.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OSHABM_proj.Services
{
    public class PaymentServeice
    {
        PaymentRepository _payRepo = new PaymentRepository();
        public Payment GetPaymentById(string AuditID)
        {
            try
            {
                return _payRepo.GetPaymentById(AuditID);
            }
            catch
            {
                throw;
            }
        }
        
        public int CreatePayment(Payment _paymentDetail)
        {
            try
            {
                return _payRepo.CreatePayment(_paymentDetail);
            }
            catch
            {
                throw;
            }
        }
        public List<Payment> GetPaymentDetails()
        {
            try
            {
                return _payRepo.GetPaymentDetails();
            }
            catch
            {
                throw;
            }
        }
        public List<Payment> GetUserPaymentByID(string EmailID)
        {
            try
            {
                return _payRepo.GetUserPaymentById(EmailID);
            }
            catch
            {
                throw;
            }
        }
    }
}