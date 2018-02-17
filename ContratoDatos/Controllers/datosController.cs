using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ContratoDatos.Models;
using ContratoDatos.Proxies;

namespace ContratoDatos.Controllers
{
    public class datosController : Controller
    {
        private ContratoDatosContext db = new ContratoDatosContext();

        // GET: datos
        public ActionResult Index()
        {
            try
            {
                using (sodaproxi client = new sodaproxi())
                    return View(new List<datos>(client.ObtenerParaderos()));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return HttpNotFound();
            }
        }

        // GET: datos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            datos datos = db.datos.Find(id);
            if (datos == null)
            {
                return HttpNotFound();
            }
            return View(datos);
        }

        // GET: datos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: datos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ParadaId,ParadaNombre,Descrip,Parada_Lon,Parada_Lat,Parada_Cod,Boarding")] datos datos)
        {
            if (ModelState.IsValid)
            {
                db.datos.Add(datos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(datos);
        }

        // GET: datos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            datos datos = db.datos.Find(id);
            if (datos == null)
            {
                return HttpNotFound();
            }
            return View(datos);
        }

        // POST: datos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ParadaId,ParadaNombre,Descrip,Parada_Lon,Parada_Lat,Parada_Cod,Boarding")] datos datos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(datos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(datos);
        }

        // GET: datos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            datos datos = db.datos.Find(id);
            if (datos == null)
            {
                return HttpNotFound();
            }
            return View(datos);
        }

        // POST: datos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            datos datos = db.datos.Find(id);
            db.datos.Remove(datos);
            db.SaveChanges();
            return RedirectToAction("Index");
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
