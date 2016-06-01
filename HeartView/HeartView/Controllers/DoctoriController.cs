using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using CustomMembership;
using HealthView.BusinessLogic.ModelCore;
using HealthView.Models;

namespace HeartView.Controllers
{
    public class DoctoriController : Controller
    {
        // GET: Doctori
        public ActionResult Index()
        {
            return View();
        }

        // GET: Doctori/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        [ActionName("Listare")]
        public virtual async Task<ActionResult> Listare()
        {
            var doctoriList = await DoctoriCore.Instance().List();

            if (doctoriList == null)
            {
                return null;
            }
            return View(doctoriList);
        }
        // GET: Doctori/Create
        public virtual ActionResult Create(Guid aspNetUserId)
        {
            ViewBag.AspNetUserId = aspNetUserId;//care defapt este si id-ul doctorului
            return View();
        }

        // POST: Doctori/Create
        [HttpPost]
        public virtual async Task<ActionResult> Create(Doctori doctorModel )
        {
            try
            {
                //var prepareDoctorModel = new Doctori
                //{
                //    NumeDoctor = doctorModel.NumeDoctor,
                //    PrenumeDoctor = doctorModel.PrenumeDoctor,
                //    Functie = doctorModel.Functie,
                //    Spital = doctorModel.Spital,
                //    Status = doctorModel.Status,
                //    AspNetUserId = doctorModel.AspNetUserId
                //};

                var doctor = await DoctoriCore.Instance().CreateAsync(doctorModel);

                return Json(doctor);
            }
            catch(Exception ex)
            {
                return Json(null);
            }

        }

        // GET: Doctori/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Doctori/Edit/5
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

        // GET: Doctori/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Doctori/Delete/5
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
