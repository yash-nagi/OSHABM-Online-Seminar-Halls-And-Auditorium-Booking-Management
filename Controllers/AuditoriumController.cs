using OSHABM_proj.Models;
using OSHABM_proj.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OSHABM_proj.Controllers
{
    public class AuditoriumController : Controller
    {
        AuditoriumService auditservice = new AuditoriumService();
       
        // GET: Auditorium
        public ActionResult Auditorium()
        {
            try
            {
                List<AuditoriumDetails> auditList = auditservice.GetAuditorium();
                return View(auditList);
            }
            catch(Exception ex)
            {

            }   
            return View();
        }
        //For Staff/Admin

        public ActionResult EditAuditoruium()
        {
            try
            {
                List<AuditoriumDetails> auditList = auditservice.GetAuditorium();
                return View(auditList);
            }
            catch (Exception ex)
            {

            }
            return View();
        }
        // GET: Auditorium/Details/5
        public ActionResult Details(string AuditID)
        {
            try
            {
                AuditoriumDetails _auditData = auditservice.GetAuditoriumById(AuditID);
                return View(_auditData);
            }
            catch(Exception ex)
            {

            }
            
            return View();
        }

        // GET: Auditorium/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: Auditorium/Create
        [HttpPost]
        public ActionResult Create(AuditoriumDetails _auditDetail)
        {
            try
            {
                // TODO: Add insert logic here
                int result = auditservice.CreateAuditorium(_auditDetail);
                if(result>0)
                {
                    return RedirectToAction("Create");

                }
            }
            catch
            {
                return View();
            }
            return View();
        }

        // GET: Auditorium/Edit/5
        public ActionResult Edit(string AuditID)
        {
            try
            {
                AuditoriumDetails _auditData = auditservice.GetAuditoriumById(AuditID);
                return View(_auditData);
            }
            catch(Exception ex)
            {

            }
            return View();
        }

        // POST: Auditorium/Edit/5
        [HttpPost]
        public ActionResult Edit(string AuditID, AuditoriumDetails auditoriumData)
        {
            try
            {                
                // TODO: Add update logic here                
                    int result = auditservice.UpdateAuditorium(AuditID, auditoriumData);
                    if (result > 0)
                    {
                        return RedirectToAction("EditAuditoruium");
                    }                             
            }
            catch
            {
                return View();
            }
            return View();
        }

        // GET: Auditorium/Delete/5
        //[HttpPost]
        public ActionResult Delete(string AuditID)
        {
            try
            {
                auditservice.DeleteAuditoriumById(AuditID);                
                return RedirectToAction("EditAuditoruium");                               
            }
            catch(Exception ex)
            {

            }
            return View();
        }

        //// POST: Auditorium/Delete/5
        ////[HttpPost]
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
