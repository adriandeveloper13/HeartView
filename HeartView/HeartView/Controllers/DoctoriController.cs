using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HealthView.BusinessLogic.ModelCore;

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
        public static async  Task<ActionResult> Listare()
        {
            var doctoriList = await  DoctoriCore.Instance().GetListAsync();

            return View();
        }
        // GET: Doctori/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Doctori/Create
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
