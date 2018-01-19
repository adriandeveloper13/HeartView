using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HealthView.BusinessLogic.ModelCore;
using HealthView.Models;

namespace HeartView.Controllers
{
    public class RecomandariController : Controller
    {
        // GET: Recomandari
        public ActionResult Index()
        {
            return View();
        }

        // GET: Recomandari/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Recomandari/Create
        [HttpGet]
        public ActionResult CreateRecomandare(Guid pacientId)
        {
            ViewBag.IDPacient = pacientId;
           
            return View();
        }

        // POST: Recomandari/Create
        [HttpPost]
        public async Task<ActionResult> CreateRecomandare(Recomandari recomandareModel)
        {
            try
            {
                var recomandare = await RecomandariCore.Instance().CreateAsync(recomandareModel).ConfigureAwait(false);

                return Json(recomandare);
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }

        // GET: Recomandari/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }


        [HttpGet]
        public async Task<ActionResult> ListareRecomandariPacienti(Guid pacientId, Guid doctorId)
        {
            try
            {
                var recomandariPacient = await RecomandariCore.Instance().List();


                ViewBag.IDPacient = pacientId;
                ViewBag.IDDoctor = doctorId;

                return View(recomandariPacient);
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpGet]
        public virtual async Task<ActionResult> UpdateRecomandare(Guid idRecomandare, Guid pacientId, Guid doctorId)
        {
            var model = await RecomandariCore.Instance().GetAsync(pacientId).ConfigureAwait(false);


            ViewBag.IDRecomandare = idRecomandare;
            ViewBag.IDPacient = pacientId;
            ViewBag.IDDoctor = doctorId;
            return View(model);
        }

        [HttpPost]
        public virtual async Task<ActionResult> UpdateRecomandare(Recomandari model)
        {
            var updatedRecomandare = await RecomandariCore.Instance().UpdateAsync(model).ConfigureAwait(false);

            return Json(updatedRecomandare);
        }

        // POST: Recomandari/Edit/5
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

        // GET: Recomandari/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Recomandari/Delete/5
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
