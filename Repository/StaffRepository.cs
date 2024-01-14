using OSHABM_proj.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OSHABM_proj.Repository
{
    public class StaffRepository
    {
        public int CreateStaff(Staff _staff)
        {
            try
            {
                using (SqlHelper dbhelp = new SqlHelper())
                {
                    SqlParameter[] param =
                    {
                        new SqlParameter("@Name",_staff.Name),
                        new SqlParameter("@EmailID",_staff.EmailID),
                        new SqlParameter("@Password",_staff.Password),
                        new SqlParameter("@Mobile",_staff.Mobile)
                        
                    };
                    return dbhelp.ExecuteNonQueryByProc("usp_PostData_tbl_staff", param);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}