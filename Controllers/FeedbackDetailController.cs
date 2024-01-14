using OSHABM_proj.Models;
using OSHABM_proj.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OSHABM_proj.Controllers
{
    public class FeedbackDetailController : Controller
    {
        FeedbackService obj  = new FeedbackService();
        // GET: FeedbackDetail
        public ActionResult Feedback()
        {
            try
            {
                List<Feedback> feedbacks = obj.GetFeedback();
                return View(feedbacks);
            }
            catch(Exception ex)
            {

            }
            return View();
        }

        // GET: FeedbackDetail/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FeedbackDetail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FeedbackDetail/Create
        [HttpPost]
        public ActionResult Create(Feedback _feedbackData)
        {
            try
            {
                // TODO: Add insert logic here
                int result = obj.CreateFeedback( _feedbackData );
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

        // GET: FeedbackDetail/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FeedbackDetail/Edit/5
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

        // GET: FeedbackDetail/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FeedbackDetail/Delete/5
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
