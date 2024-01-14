using OSHABM_proj.Models;
using OSHABM_proj.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OSHABM_proj.Controllers
{
    public class UserDetailController : Controller
    {
        UserService userService = new UserService();
        // GET: UserDetail
        
        public ActionResult User(string EmailID)
        {
            try
            {
                User user = userService.GetUserDetailsById(Session["EmailID"].ToString());
                return View(user);
            }
            catch(Exception ex)
            {

            }
            return View();
        }
        public ActionResult UserData()
        {
            try
            {
                List<User> users = userService.GetUserData();
                return View(users);

            }
            catch(Exception ex) { }
            return View();
        }
        // GET: UserDetail/Details/5
        public ActionResult Details(string EmailID)
        {
            User user = userService.GetUserDetailsAdminById(EmailID);
            return View(user);
        }

        // GET: UserDetail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserDetail/Create
        [HttpPost]
        public ActionResult Create( User userData)
        {
            try
            {

                // TODO: Add insert logic here
                int result = userService.CreateUser(userData);
                if (result > 0)
                {
                    return RedirectToAction("Login", "Welcome");
                }
            }
            catch
            {
                return View();
            }
            return View();

        }

        // GET: UserDetail/Edit/5
        public ActionResult Edit(string EmailID)
        {
            User user = userService.GetUserDetailsById(Session["EmailID"].ToString());
            return View(user);
            
        }

        // POST: UserDetail/Edit/5
        [HttpPost]
        public ActionResult Edit(string EmailID, User _userData)
        {
            try
            {
                
                // TODO: Add update logic here
                int result = userService.UpdateUser(EmailID, _userData);
                if(result > 0)
                {
                    return RedirectToAction("Index", "Welcome");
                }                
            }
            catch
            {
                return View();
            }
            return View();
        }

        // GET: UserDetail/Delete/5
        //[HttpPost]
        public ActionResult Delete(string EmailID)
        {

            try
            {
                // TODO: Add insert logic here
                userService.DeleteUserDetails(EmailID);
               
                    return RedirectToAction("UserData", "UserDetail");
            }
            catch
            {
                return View();
            }

            return View();
        }

        // POST: UserDetail/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        
        
    }
}
