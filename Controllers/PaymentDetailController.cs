using OSHABM_proj.Models;
using OSHABM_proj.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OSHABM_proj.Controllers
{
    public class PaymentDetailController : Controller
    {
        PaymentServeice _payService = new PaymentServeice();
        // GET: PaymentDetail
        public ActionResult Payment(string AuditID)
        {
            try
            {
                Payment _pay = _payService.GetPaymentById(AuditID);
                return View(_pay);
                
            }
            catch (Exception ex)
            {

            }
            return View();
        }
        [HttpPost]
        public ActionResult Payment(Payment _pay)
        {
            try
            {
                
                    int result = _payService.CreatePayment(_pay);
                    if (result > 0)
                    {                       
                        return RedirectToAction("Index", "Welcome");
                    }
                
            }
            catch(Exception ex)
            {

            }
            return View();
        }

        public ActionResult PaymentDetailsAdmin()
        {
            try
            {
                List<Payment> obj= _payService.GetPaymentDetails();
                return View(obj);
            }
            catch(Exception ex) { }
            return View();
        }

        public ActionResult PaymentUserDetail(string EmailID)
        {
            try
            {
                List<Payment> pay = _payService.GetUserPaymentByID(Session["EmailID"].ToString());
                return View(pay);
            }
            catch(Exception ex)
            {

            }
            return View();
        }
        // GET: PaymentDetail/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PaymentDetail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaymentDetail/Create
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

        // GET: PaymentDetail/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PaymentDetail/Edit/5
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

        // GET: PaymentDetail/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PaymentDetail/Delete/5
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
