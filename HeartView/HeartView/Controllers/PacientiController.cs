using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using System.Web.Mvc;
using HealthView.BusinessLogic.ModelCore;
using HealthView.Models;

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
        public ActionResult Create(Guid aspNetUserId)
        {
            ViewBag.AspNetUserId = aspNetUserId;
            ViewBag.IDDoctor = aspNetUserId;
            return View();
        }

        // POST: Pacienti/Create
        [HttpPost]
        public async Task<ActionResult> Create( Pacienti pacientModel)
        {
            try
            {
                var aspNetUserId = Guid.Parse(pacientModel.AspNetUserId);
                var doctor = await DoctoriCore.Instance().GetByAspNetUserId(aspNetUserId);
                pacientModel.IDDoctor = doctor.First().Id;
                pacientModel.Status = "1";
                var pacient = await PacientiCore.Instance().CreateAsync(pacientModel);

                return Json(pacient);
            }
            catch(Exception ex)
            {
                return Json(null);
            }
        }

        public async Task<ActionResult> Listare(Guid doctorId)
        {
            try
            {
                var pacienti = await PacientiCore.Instance().GetAllByDoctorId(doctorId);

                if (pacienti == null)
                {
                    return null;
                }

                ViewBag.IDDoctor = doctorId;
                return View(pacienti);
            }
            catch (Exception ex)
            {
                    
                throw;
            }
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
