using Microsoft.Win32;
using OSHABM_proj;
using OSHABM_proj.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.EnterpriseServices.Internal;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Services.Protocols;


namespace OSHABM_proj.Repository
{
    public class UserRepository
    {
        User obj = new User();
        public int CreateUser(User userData)
        {
            string filepath = null;
            try
            {                
                using (SqlHelper dbhelp = new SqlHelper())
                {
                    string path = "..\\Uploads\\";
                    string filename = Path.GetFileName(userData.Imagepath.FileName);
                    filepath = Path.Combine(path, filename);
                    userData.Imagepath.SaveAs(System.Web.HttpContext.Current.Server.MapPath(filepath));
                    
                    SqlParameter[] param =
                    {
                        new SqlParameter("@UserID",userData.UserID),
                        new SqlParameter("@Name",userData.Name),
                        new SqlParameter("@Password",userData.Password),                       
                        new SqlParameter("@Address",userData.Address),
                        new SqlParameter("@EmailID",userData.EmailID),
                        new SqlParameter("@Mobile",userData.Mobile),
                        new SqlParameter("@Photo",filepath)
                    };
                    return dbhelp.ExecuteNonQueryByProc("usp_DataInput_user_details", param);
                }
            }
            catch
            {
                throw;
            }
        }
        

        public User GetUserDetailsById(string EmailID)
        {           
            User _user = null;
            try
            {
                using (SqlHelper dbhelp = new SqlHelper())
                {
                    SqlParameter[] param =
                    {
                    new SqlParameter("@EmailID",EmailID)

                     };
                    DataTable dt = dbhelp.GetDataTable("usp_GetUserDetail_user_details", param);

                    if (dt.Rows.Count > 0)
                    {
                        _user = new User
                        {
                            UserID = dt.Rows[0]["UserID"].ToString(),
                            Password = dt.Rows[0]["Password"].ToString(),
                            Name = dt.Rows[0]["Name"].ToString(),
                            Address = (dt.Rows[0]["Address"].ToString()),
                            Mobile = dt.Rows[0]["Mobile"].ToString(),
                            EmailID = dt.Rows[0]["EmailID"].ToString(),
                            Photo = dt.Rows[0]["Photo"].ToString(),
                        };
                    }
                }
            }
            catch
            {
                throw;
            }
            return _user;
        }
        public int UpdateUser(string EmailID, User _userData)
        {
            try
            {                
                // filepath = null;
                using (SqlHelper helper = new SqlHelper())
                {
                    //string path = "~\\Uploads\\";
                    //string filename = Path.GetFileName(_userData.Imagepath.FileName);
                    //filepath = Path.Combine(path, filename);
                    //_userData.Imagepath.SaveAs(System.Web.HttpContext.Current.Server.MapPath(filepath));

                    SqlParameter[] param =
                    {
                    new SqlParameter("@UserID",_userData.UserID),
                    new SqlParameter("@Password",_userData.Password),
                    new SqlParameter("@Name",_userData.Name),
                    new SqlParameter("@Address",_userData.Address),
                    new SqlParameter("@Mobile",_userData.Mobile),
                    new SqlParameter("@EmailID",_userData.EmailID)
                    //new SqlParameter("@Photo",filepath)
                    };
                    return helper.ExecuteNonQueryByProc("usp_UpdateData_user_details", param);
                }
            }
            catch
            {
                throw;
            }
        }
        public List<User> GetUserData()
        {
            List<User> userList = new List<User>();
            try
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    DataTable dt = helper.GetDataTableByproc("usp_ListUserData_user_details");
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            User userObject = new User
                            {
                                UserID = dt.Rows[i]["UserID"].ToString(),
                                 Name= dt.Rows[i]["Name"].ToString(),
                                 
                                Address = dt.Rows[i]["Address"].ToString(),
                                Mobile = dt.Rows[i]["Mobile"].ToString(),
                                EmailID =dt.Rows[i]["EmailID"].ToString(),
                                Photo = dt.Rows[i]["Photo"].ToString(),
                            };
                            userList.Add(userObject);
                        }
                    }
                }
            }
            catch
            {
                throw;
            }

            return userList;
        }
        public int DeleteUserDetails(string EmailID)
        {           
            User user = null; 
            try
            {
                using (SqlHelper dbhelp = new SqlHelper())
                {
                    SqlParameter[] param =
                    {
                    new SqlParameter("@EmailID",EmailID)
                    };
                    return dbhelp.ExecuteNonQueryByProc("usp_DeleteUserData_user_details", param);                    
                }
            }
            catch
            {
                throw;
            }
           
        }
        public User GetUserDetailsAdminById(string EmailID)
        {
            User _user = null;
            try
            {
                using (SqlHelper dbhelp = new SqlHelper())
                {
                    SqlParameter[] param =
                    {
                    new SqlParameter("@EmailID",EmailID)

                     };
                    DataTable dt = dbhelp.GetDataTable("usp_GetUserDetail_user_details", param);

                    if (dt.Rows.Count > 0)
                    {
                        _user = new User
                        {
                            UserID = dt.Rows[0]["UserID"].ToString(),

                            Name = dt.Rows[0]["Name"].ToString(),
                            Address = (dt.Rows[0]["Address"].ToString()),
                            Mobile = dt.Rows[0]["Mobile"].ToString(),
                            EmailID = dt.Rows[0]["EmailID"].ToString(),
                            Photo = dt.Rows[0]["Photo"].ToString(),
                        };
                    }
                }
            }
            catch
            {
                throw;
            }
            return _user;
        }
    }    
}
