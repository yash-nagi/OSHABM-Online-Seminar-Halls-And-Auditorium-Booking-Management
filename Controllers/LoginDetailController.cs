using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OSHABM_proj.Controllers
{
    public class LoginDetailController : Controller
    {
        // GET: LoginDetail
        public ActionResult UserLogin()
        {
            return View();
        }

        // GET: LoginDetail/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LoginDetail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginDetail/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginDetail/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoginDetail/Edit/5
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

        // GET: LoginDetail/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoginDetail/Delete/5
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
