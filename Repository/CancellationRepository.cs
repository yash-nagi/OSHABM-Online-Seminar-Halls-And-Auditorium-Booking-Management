using OSHABM_proj.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OSHABM_proj.Repository
{
    public class CancellationRepository
    {
        public int CancelRequest(Cancellation obj)
        {
            try
            {
                using (SqlHelper dbhelp = new SqlHelper())
                {
                    SqlParameter[] param =
                    {
                        new SqlParameter("@UserId",obj.UserId),                        
                        new SqlParameter("@Purpose",obj.Purpose),
                        new SqlParameter("@Date_of_Cancel",DateTime.Now.ToString()),
                        new SqlParameter("@Time_of_Cancel",DateTime.Now.ToString())
                    };   
                    return dbhelp.ExecuteNonQueryByProc("usp_tbl_Cancellation_detail", param);
                }
            }
            catch
            {
                throw;
            }
        }
        
        public List<Cancellation> GetCancellation()
        {
            List<Cancellation> cancellationList = new List<Cancellation>();
            try
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    
                    DataTable dt = helper.GetDataTableByproc("usp_ListCancellationRequest_Cancellation_detail");
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            Cancellation cancelObject = new Cancellation
                            {
                                Cancellation_No = (int)Convert.ToInt32(dt.Rows[i]["Cancellation_No"].ToString()),
                                UserId = dt.Rows[i]["UserID"].ToString(),
                                Purpose = dt.Rows[i]["Purpose"].ToString(),
                                Date_of_Cancel = (DateTime)dt.Rows[i]["Date_of_Cancel"],                            
                                Time_of_Cancel = TimeSpan.Parse(dt.Rows[i]["Time_of_Cancel"].ToString())
                            };
                            cancellationList.Add(cancelObject);
                        }
                    }
                }
            }
            catch
            {
                throw;
            }

            return cancellationList;
        }       
    }
}