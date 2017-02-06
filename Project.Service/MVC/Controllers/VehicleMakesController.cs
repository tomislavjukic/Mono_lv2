using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project.Service.DAL;
using Project.Service.Models;
using Project.Service.ViewModels;

namespace MVC.Controllers
{
    public class VehicleMakesController : Controller
    {
        VehicleService vehicleService = new VehicleService();

        // GET: VehicleMakes
        public ActionResult Index()
        {
            return View(vehicleService.GetAllVehicleMakes());
        }

        // GET: VehicleMakes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //VehicleMake vehicleMake = db.VehicleMakes.Find(id);
            VehicleMakeViewModel vehicleMakeVM = vehicleService.FindIdVehicleMake(id);
            if (vehicleMakeVM == null)
            {
                return HttpNotFound();
            }
            return View(vehicleMakeVM);
        }

        // GET: VehicleMakes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleMakes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Abrv")] VehicleMakeViewModel vehicleMakeVM)
        {
            vehicleMakeVM.Id = Guid.NewGuid();
            if (ModelState.IsValid)
            {
                //vehicleMake.Id = Guid.NewGuid();
                //db.VehicleMakes.Add(vehicleMake);
                //db.SaveChanges();
                //return RedirectToAction("Index");
                vehicleService.CreateVehicleMake(vehicleMakeVM);
                return RedirectToAction("Index");
            }

            return View(vehicleMakeVM);
        }

        // GET: VehicleMakes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleMakeViewModel vehicleMakeVM = vehicleService.FindIdVehicleMake(id);
            if (vehicleMakeVM == null)
            {
                return HttpNotFound();
            }
            return View(vehicleMakeVM);
        }

        // POST: VehicleMakes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Abrv")] VehicleMakeViewModel vehicleMakeVM)
        {
            if (ModelState.IsValid)
            {
                vehicleService.EditVehicleMake(vehicleMakeVM);
                // vehicleService.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicleMakeVM);
        }

        // GET: VehicleMakes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleMakeViewModel vehicleMake = vehicleService.FindIdVehicleMake(id);
            if (vehicleMake == null)
            {
                return HttpNotFound();
            }
            return View(vehicleMake);
        }

        // POST: VehicleMakes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            VehicleMakeViewModel vehicleMake = vehicleService.FindIdVehicleMake(id);
            vehicleService.DeleteVehicleMake(id);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
