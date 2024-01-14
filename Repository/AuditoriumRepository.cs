using OSHABM_proj.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OSHABM_proj.Repository
{
    public class AuditoriumRepository
    {
        AuditoriumDetails obj = new AuditoriumDetails();
        public int CreateAuditorium(AuditoriumDetails _auditDetail)
        {            
            try
            {
                using (SqlHelper dbhelp = new SqlHelper())
                {
                    SqlParameter[] param =
                    {
                        new SqlParameter("@AuditID",_auditDetail.AuditID),
                        new SqlParameter("@Name",_auditDetail.Name),
                        new SqlParameter("@Location",_auditDetail.Location),
                        new SqlParameter("@Type",_auditDetail.Type),
                        new SqlParameter("@Price",_auditDetail.Price),
                        new SqlParameter("@Mobile",_auditDetail.Phone)                        
                    };
                    return dbhelp.ExecuteNonQueryByProc("usp_DataInput_auditorium_detail", param);
                }
            }
            catch
            {
                throw;
            }
        }

        public List<AuditoriumDetails> GetAuditorium()
        {
            List<AuditoriumDetails> auditoriumList = new List<AuditoriumDetails>();
            try
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    DataTable dt = helper.GetDataTableByproc("usp_GetData_auditorium_detail");
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            AuditoriumDetails auditObject = new AuditoriumDetails
                            {
                                Id = (int)Convert.ToInt32(dt.Rows[i]["ID"].ToString()),
                                AuditID = dt.Rows[i]["AuditID"].ToString(),
                                Name = dt.Rows[i]["Name"].ToString(),
                                Location = dt.Rows[i]["Location"].ToString(),
                                Type = dt.Rows[i]["Type"].ToString(),
                                Price = Convert.ToDecimal(dt.Rows[i]["Price"].ToString()),
                                Phone = Convert.ToInt64(dt.Rows[i]["Mobile"].ToString()),
                            };
                            auditoriumList.Add(auditObject);
                        }
                    }
                }
            }
            catch
            {
                throw;
            }

            return auditoriumList;
        }

        public AuditoriumDetails GetAuditoriumById(string AuditID)
        {
            AuditoriumDetails obj = null;

            try
            {

                using (SqlHelper helper = new SqlHelper())
                {
                    SqlParameter[] param =
                    {
                    new SqlParameter("@AuditID",AuditID)

                     };
                    DataTable dt = helper.GetDataTable("usp_GetAuditoriumData_auditorium_detail", param);

                    if (dt.Rows.Count > 0)
                    {
                        obj = new AuditoriumDetails
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

            return obj;
        }
        public int UpdateAuditorium(string id, AuditoriumDetails auditoriumData)
        {
            try
            {

                using (SqlHelper helper = new SqlHelper())
                {
                    SqlParameter[] param =
                    {
                    new SqlParameter("@AuditID",auditoriumData.AuditID),
                        new SqlParameter("@Name",auditoriumData.Name),
                        new SqlParameter("@Location",auditoriumData.Location),
                        new SqlParameter("@Type",auditoriumData.Type),
                        new SqlParameter("@Price",auditoriumData.Price),
                        new SqlParameter("@Mobile",auditoriumData.Phone)

                     };
                    return helper.ExecuteNonQueryByProc("usp_UpdateAuditoriumData_auditorium_detail", param);
                }
            }
            catch
            {
                throw;
            }
        }
        public void DeleteAuditoriumById(string AuditID)
        {
            //AuditoriumDetails obj = null;
            try
            {
                using (SqlHelper dbhelp = new SqlHelper())
                {
                    SqlParameter[] param =
                    {
                    new SqlParameter("@AuditID",AuditID)
                    };
                    dbhelp.ExecuteNonQueryByProc("usp_DeleteData_auditorium_detail", param);
                }
            }
            catch
            {
                throw;
            }           
        }
    }
}