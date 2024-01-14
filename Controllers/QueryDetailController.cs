using OSHABM_proj.Models;
using OSHABM_proj.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace OSHABM_proj.Controllers
{
    public class QueryDetailController : Controller
    {
        QueryService queryService = new QueryService();
        // GET: QueryDetail
        public ActionResult Query()
        {
            try
            {
                List<Query> obj = queryService.GetQueryList();
                return View(obj);
            }
            catch(Exception ex) { }
            return View();
        }

        // GET: QueryDetail/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: QueryDetail/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: QueryDetail/Create
        [HttpPost]
        public ActionResult Create(Query queryData)
        {
            try
            {
                // TODO: Add insert logic here
                int result = queryService.CreateQuery(queryData);
                if(result>0)
                {
                    ViewBag.Message = String.Format("Your Request has been Accepted, process will be soon");
                    return RedirectToAction("Index", "Welcome");
                }                
            }
            catch
            {
                return View();
            }
            return View();
        }

        // GET: QueryDetail/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: QueryDetail/Edit/5
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

        // GET: QueryDetail/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: QueryDetail/Delete/5
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
