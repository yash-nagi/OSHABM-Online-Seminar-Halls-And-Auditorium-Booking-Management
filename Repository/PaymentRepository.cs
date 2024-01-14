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
    public class PaymentRepository
    {
        public Payment GetPaymentById(string AuditID)
        {
            Payment _pay = null;
            try
            {

                using (SqlHelper helper = new SqlHelper())
                {
                    SqlParameter[] param =
                    {
                    new SqlParameter("@AuditID",AuditID)

                     };
                    DataTable dt = helper.GetDataTable("usp_GetDataToPayment_auditorium_detail", param);

                    if (dt.Rows.Count > 0)
                    {
                        _pay = new Payment
                        {
                            AuditID = dt.Rows[0]["AuditID"].ToString(),
                            Name = dt.Rows[0]["Name"].ToString(),
                            Type = dt.Rows[0]["Type"].ToString(),
                            Amount = (int)Convert.ToInt16(dt.Rows[0]["Price"].ToString())                            
                        };
                    }
                }
            }
            catch
            {
                throw;
            }
            return _pay;
        }

        //Payment obj = new Payment();
        public int CreatePayment(Payment obj)
        {
            try
            {
                using (SqlHelper dbhelp = new SqlHelper())
                {
                    SqlParameter[] param =
                    {
                        new SqlParameter("@AuditID",obj.AuditID),
                        new SqlParameter("@Name",obj.Name),                        
                        new SqlParameter("@Type",obj.Type),
                        new SqlParameter("@Amount",obj.Amount),
                        new SqlParameter("@UserID",obj.UserID),
                        new SqlParameter("@EmailID",obj.EmailID),
                        new SqlParameter("@Payment_Type",obj.Payment_Type),
                        new SqlParameter("@Date_of_Booking",DateTime.Now.ToString()),
                        new SqlParameter("@Time_of_Booking",DateTime.Now.ToString())
                    };
                    return dbhelp.ExecuteNonQueryByProc("usp_DataInput_tbl_Payment_Details", param);
                }
            }
            catch
            {
                throw;
            }
        }
        public List<Payment> GetPaymentDetails()
        {
            List<Payment> paymentList = new List<Payment>();
            try
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    DataTable dt = helper.GetDataTableByproc("usp_ListPaymenetDdetails_tbl_Payment_Details");
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            Payment paymentObject = new Payment
                            {
                                PayID= (int)Convert.ToInt32(dt.Rows[i]["PayID"].ToString()),
                                 AuditID= dt.Rows[i]["AuditID"].ToString(),
                                 Name= dt.Rows[i]["Name"].ToString(),
                                 Type= dt.Rows[i]["Type"].ToString(),
                                 Amount= (int)Convert.ToInt64(dt.Rows[i]["Amount"].ToString()),
                                 Payment_Type= dt.Rows[i]["Payment_Type"].ToString(),
                                 UserID = dt.Rows[i]["UserID"].ToString(),
                                Date_of_Booking = (DateTime)dt.Rows[i]["Date_of_Booking"],
                                Time_of_Booking = TimeSpan.Parse(dt.Rows[i]["Time_of_Booking"].ToString()),
                                EmailID = dt.Rows[i]["EmailID"].ToString(),

                            };
                            paymentList.Add(paymentObject);
                        }
                    }
                }
            }
            catch
            {
                throw;
            }

            return paymentList;
        }
        public List<Payment> GetUserPaymentById(string EmailID)
        {
            List<Payment> paymentList = new List<Payment>();
            try
            {

                using (SqlHelper helper = new SqlHelper())
                {
                    SqlParameter[] param =
                    {
                        new SqlParameter("@EmailID",EmailID)
                    };
                    DataTable dt = helper.GetDataTable("usp_GetPaymentDetail_tbl_Payment_Details", param);

                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            Payment paymentObject = new Payment
                            {
                                PayID = (int)Convert.ToInt32(dt.Rows[i]["PayID"].ToString()),
                                AuditID = dt.Rows[i]["AuditID"].ToString(),
                                Name = dt.Rows[i]["Name"].ToString(),
                                Type = dt.Rows[i]["Type"].ToString(),
                                Amount = (int)Convert.ToInt64(dt.Rows[i]["Amount"].ToString()),
                                Payment_Type = dt.Rows[i]["Payment_Type"].ToString(),
                                UserID = dt.Rows[i]["UserID"].ToString(),
                                Date_of_Booking = (DateTime)dt.Rows[i]["Date_of_Booking"],
                                Time_of_Booking = TimeSpan.Parse(dt.Rows[i]["Time_of_Booking"].ToString()),
                                EmailID = dt.Rows[i]["EmailID"].ToString(),

                            };
                            paymentList.Add(paymentObject);
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
            return paymentList;
        }
    }
}