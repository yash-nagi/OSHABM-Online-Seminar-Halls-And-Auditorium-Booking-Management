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
    public class QueryRepository
    {
        Query obj = new Query();
        public int CreateQuery(Query queryData)
        {
            try
            {
                using (SqlHelper dbhelp = new SqlHelper())
                {
                    SqlParameter[] param =
                    {
                        new SqlParameter("@Name", queryData.Name),             
                        new SqlParameter("@EmailID",queryData.EmailID),
                        new SqlParameter("@Phone",queryData.Phone),
                        new SqlParameter("@Event_Date",queryData.Event_Date),
                        new SqlParameter("Event_Type",queryData.Event_Type)
                    };
                    return dbhelp.ExecuteNonQueryByProc("usp_QueryInput_tbl_Query", param);
                }
            }
            catch
            {
                throw;
            }
        }
        public List<Query> GetQueryList()
        {
            List<Query> querytList = new List<Query>();
            try
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    DataTable dt = helper.GetDataTableByproc("usp_ListQuery_tbl_Query");
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            Query queryObject = new Query
                            {                                
                                Name = dt.Rows[i]["Name"].ToString(),
                                EmailID = dt.Rows[i]["EmailID"].ToString(),
                                Phone = Convert.ToInt64(dt.Rows[i]["Phone"].ToString()),
                                Event_Date =(DateTime)dt.Rows[i]["Event_Date"],
                                Event_Type = dt.Rows[i]["Event_Type"].ToString()

                            };
                            querytList.Add(queryObject);
                        }
                    }
                }
            }
            catch
            {
                throw;
            }

            return querytList;
        }
    }
}