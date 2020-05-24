using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WMLista.Models;

namespace WMLista.Controllers
{
    public class ProizvodiController : Controller
    {
        // GET: Proizvodi
        public ActionResult Index()
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.Proizvodis.ToList());
            }
            
        }

        // GET: Proizvodi/Details/5
        public ActionResult Details(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.Proizvodis.Where(x=>x.Id == id).FirstOrDefault());

            }
        }

        // GET: Proizvodi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proizvodi/Create
        [HttpPost]
        public ActionResult Create(Proizvodi proizvodi)
        {
            try
            {
                using (DbModels dbModel = new DbModels())
                {
                    dbModel.Proizvodis.Add(proizvodi);
                    dbModel.SaveChanges();
                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Proizvodi/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.Proizvodis.Where(x => x.Id == id).FirstOrDefault());

            }
            
        }

        // POST: Proizvodi/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Proizvodi proizvodi)
        {
            try
            {
                using (DbModels dbModels = new DbModels())
                {
                    dbModels.Entry(proizvodi).State = EntityState.Modified;
                    dbModels.SaveChanges();
                }
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Proizvodi/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.Proizvodis.Where(x => x.Id == id).FirstOrDefault());

            }
        }

        // POST: Proizvodi/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (DbModels dbModels = new DbModels())
                {
                    Proizvodi proizvodi = dbModels.Proizvodis.Where(x => x.Id == id).FirstOrDefault();
                    dbModels.Proizvodis.Remove(proizvodi);
                    dbModels.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
