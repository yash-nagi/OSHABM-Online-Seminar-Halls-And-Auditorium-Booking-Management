using OSHABM_proj.Models;
using OSHABM_proj.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OSHABM_proj.Controllers
{
    public class StaffDetailController : Controller
    {
        StaffService service = new StaffService();
        // GET: StaffDetail
        public ActionResult Staff()
        {
            return View();
        }

        // GET: StaffDetail/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StaffDetail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StaffDetail/Create
        [HttpPost]
        public ActionResult Create(Staff _staff)
        {
            try
            {
                // TODO: Add insert logic here
                int result = service.CreateStaff(_staff);
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
        public ActionResult AdminPage()
        {
            return View();
        }
        // GET: StaffDetail/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StaffDetail/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: StaffDetail/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StaffDetail/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
