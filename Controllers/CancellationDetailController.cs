using OSHABM_proj.Models;
using OSHABM_proj.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OSHABM_proj.Controllers
{
    public class CancellationDetailController : Controller
    {
        CancellationService obj = new CancellationService();
        // GET: CancellationDetail
        public ActionResult Cancellation()
        {
            try
            {
                List<Cancellation> cancellations = obj.GetCancellation();
                return View(cancellations);

            }
            catch(Exception ex)
            {

            }
            return View();
        }

        // GET: CancellationDetail/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CancellationDetail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CancellationDetail/Create
        [HttpPost]
        public ActionResult Create(Cancellation _cancellation)
        {
            try
            {
                // TODO: Add insert logic here
                
                
                
                int result = obj.CancelRequest(_cancellation);
                if(result>0)
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

        // GET: CancellationDetail/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CancellationDetail/Edit/5
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

        // GET: CancellationDetail/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CancellationDetail/Delete/5
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
