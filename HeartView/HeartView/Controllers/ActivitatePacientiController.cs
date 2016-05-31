using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HealthView.BusinessLogic.ModelCore;

namespace HeartView.Controllers
{
    public class ActivitatePacientiController : Controller
    {
        // GET: ActivitatePacienti
        public ActionResult Index()
        {
            return View();
        }

        // GET: ActivitatePacienti/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ActivitatePacienti/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ActivitatePacienti/Create
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

        [HttpGet]
        public async Task<ActionResult> ListareActivitatePacienti(Guid pacientId)
        {
            try
            {
                var fisePacienti = await ActivitatePacientiCore.Instance().List();

                if (fisePacienti == null)
                {
                    return null;
                }

                ViewBag.IDPacient = pacientId;

                return View(fisePacienti);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: ActivitatePacienti/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ActivitatePacienti/Edit/5
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

        // GET: ActivitatePacienti/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ActivitatePacienti/Delete/5
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
