using OSHABM_proj.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace OSHABM_proj.Repository
{
    public class FeedbackRepository
    {
        Feedback obj = new Feedback();
        public int CreateFeedback(Feedback feedbackData)
        {            
            try
            {
                using (SqlHelper dbhelp = new SqlHelper())
                {
                    SqlParameter[] param =
                    {
                        new SqlParameter("@UserID",feedbackData.UserID),
                        new SqlParameter("@EmailID",feedbackData.EmailID),
                        new SqlParameter("@Purpose",feedbackData.Purpose),
                        new SqlParameter("@Date_of_Submission",DateTime.Now.ToString()),
                        new SqlParameter("@Time_of_Submission",DateTime.Now.ToString())
                    };
                    return dbhelp.ExecuteNonQueryByProc("usp_DataInput_tbl_Feedback", param);   
                }
            }
            catch
            {
                throw;
            }
        }
        public List<Feedback> GetFeedback()
        {
            List<Feedback> feedbackList = new List<Feedback>();
            try
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    DataTable dt = helper.GetDataTableByproc("usp_ListfeedbackRequest_tbl_Feedback");
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            Feedback feedbackObject = new Feedback
                            {
                                 UserID= dt.Rows[i]["UserID"].ToString(),
                                EmailID = dt.Rows[i]["EmailID"].ToString(),
                                Purpose = dt.Rows[i]["Purpose"].ToString(),
                                Date_of_Submission = (DateTime)dt.Rows[i]["Date_of_Submission"],
                                Time_of_Submission = TimeSpan.Parse(dt.Rows[i]["Time_of_Submission"].ToString()),
                            };
                            feedbackList.Add(feedbackObject);
                        }
                    }
                }
            }
            catch
            {
                throw;
            }

            return feedbackList;
        }
    }
}