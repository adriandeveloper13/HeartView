using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using System.Web.Mvc;
using HealthView.BusinessLogic.ModelCore;
using HealthView.Models;
using LoggingService;

namespace HeartView.Controllers
{
    public class PacientiController : Controller
    {
        // GET: Pacienti
        public ActionResult Index()
        {
            return View();
        }

        // GET: Pacienti/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        //public virtual async Task<ActionResult> Listare()
        //{
        //    var pacientiList = await PacientiCore.Instance().List();
        //    if (pacientiList == null)
        //    {
        //        return null;
        //    }
        //    return View(pacientiList);
        //}
        // GET: Pacienti/Create
        public ActionResult Create(Guid aspNetUserId, Guid doctorId)
        {
            ViewBag.AspNetUserId = aspNetUserId;
            ViewBag.IDDoctor = doctorId;
            return View();
        }

        // POST: Pacienti/Create
        [HttpPost]
        public async Task<ActionResult> Create(Pacienti pacientModel)
        {
            try
            {
                pacientModel.Status = "1";
                var pacient = await PacientiCore.Instance().CreateAsync(pacientModel).ConfigureAwait(false);

                return Json(pacient);
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Listare(Guid doctorId)
        {

            var pacienti = await PacientiCore.Instance().GetAllByDoctorId(doctorId).ConfigureAwait(false);

            if (pacienti != null && pacienti.Count != 0)
            {
                ViewBag.IDPacient = pacienti.FirstOrDefault().Id;
            }

            ViewBag.IDDoctor = doctorId;
          
            return View(pacienti);
        }


        [HttpGet]
        public virtual async Task<ActionResult> UpdatePacient(Guid pacientId, Guid doctorId, Guid aspNetUserId)
        {
            var model = await PacientiCore.Instance().GetAsync(pacientId).ConfigureAwait(false);


            ViewBag.IDPacient = pacientId;
            ViewBag.IDDoctor = doctorId;
            ViewBag.AspNetUserId = aspNetUserId;
            return View(model);
        }

        [HttpPost]
        public virtual async Task<ActionResult> UpdatePacient(Pacienti model)
        {
            var updatedPacient = await PacientiCore.Instance().UpdateAsync(model).ConfigureAwait(false);

            return Json(updatedPacient);
        }

        // GET: Pacienti/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pacienti/Edit/5
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

        // GET: Pacienti/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pacienti/Delete/5
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
