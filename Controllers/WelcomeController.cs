using OSHABM_proj.Models;
using OSHABM_proj.Repository;
using OSHABM_proj.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace OSHABM_proj.Controllers
{
    public class WelcomeController : Controller
    {
        

        // GET: Welcome
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserLogin obj) 
        {
            
            try
            {
               //serRepository ur = new UserRepository();
                // obj = new UserLogin();
                using (SqlHelper helper = new SqlHelper())
                {                   
                    SqlParameter[] param =
                    {
                        new SqlParameter("@EmailID",obj.EmailID),
                        new SqlParameter("@Password",obj.Password)                        
                    };
                    SqlDataReader dr = helper.ExecuteReaderByProc("usp_ValidateUser_tbl_login", param);
                    dr.Read();
                    if(dr.HasRows)
                    {
                        if (dr["Role"].ToString().Equals("1"))
                        {
                            Session["EmailID"] = obj.EmailID.ToString();
                            return RedirectToAction("User", "UserDetail");
                        }
                        else if (dr["Role"].ToString().Equals("0"))
                        {
                            Session["EmailID"] = obj.EmailID.ToString();
                            return RedirectToAction("AdminPage", "StaffDetail");
                        }
                        else
                        {
                            return RedirectToAction("Login", "Welcome");
                        }
                    }                    
                }               
            }
            catch(Exception ex)
            {

            }
            return View();
        }
        public ActionResult Login() 
        {
            return View();
        }
    }
} 