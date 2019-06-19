using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebExamination.Models;

namespace WebExamination.Controllers
{
    [Authorize]
    public class PatientController : Controller
    {
        private PatientContext db = new PatientContext();

        // GET: Patient
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.Patients.ToList());
        }

        // GET: Patient/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToRoute("Error");
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return RedirectToRoute("Error");
            }
            return View(patient);
        }

        // GET: Patient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patient/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Patient patient)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Patients.Add(patient);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    return RedirectToRoute("Error");
                } 
            }
            return View(patient);
        }

        // GET: Patient/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToRoute("Error");
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return RedirectToRoute("Error");
            }
            if (User.Identity.Name != patient.Dentist)
            {
                return RedirectToAction("Index", "Patient");
            }
            return View(patient);
        }

        // POST: Patient/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Patient patient)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(patient).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    return RedirectToRoute("Error");
                }
            }
            return View(patient);
        }

        // GET: Patient/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToRoute("Error");
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return RedirectToRoute("Error");
            }
            if (User.Identity.Name!=patient.Dentist)
            {
                return RedirectToAction("Index", "Patient");
            }
            return View(patient);
        }

        // POST: Patient/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Patient patient = db.Patients.Find(id);
            if (User.Identity.Name != patient.Dentist)
            {
                return RedirectToAction("Index", "Patient");
            }
            try
            {
                db.Patients.Remove(patient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View(patient);
            }
        }

        public ActionResult Error()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
