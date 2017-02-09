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
    public class VehicleModelsController : Controller
    {
        VehicleService vehicleService;

        public VehicleModelsController()
        {
            vehicleService = VehicleService.Instance;
        }

        // GET: VehicleModels
        //public ActionResult Index()
        //{
        //    //var vehicleModels = db.VehicleModels.Include(v => v.VehicleMake);
        //    //var vehickeModels = vehicleService.GetAllVehicleModels();
        //    //return View(vehicleModels.ToList());
        //    return View(vehicleService.GetAllVehicleModels());
        //}

        public ActionResult Index(string searchBy, string search, int? page, string sortBy)
        {
            ViewBag.MakersNameSortParm = String.IsNullOrEmpty(sortBy) ? "makers_desc" : "";
            ViewBag.AbrvSortParm = sortBy == "Abrv" ? "abrv_desc" : "Abrv";
            ViewBag.NameSortParm = sortBy == "Name" ? "name_desc" : "Name";


            return View(vehicleService.SortPageFilterModel(searchBy, search, page, sortBy));
        }

        // GET: VehicleModels/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //VehicleModel vehicleModel = db.VehicleModels.Find(id);
            VehicleModelViewModel vehicleModel = vehicleService.FindIdVehicleModel(id);
            if (vehicleModel == null)
            {
                return HttpNotFound();
            }
            return View(vehicleModel);
        }

        // GET: VehicleModels/Create
        public ActionResult Create()
        {
            ViewBag.VehicleMakeId = new SelectList(vehicleService.GetAllVehicleMakes(), "Id", "Name");
            return View();
        }

        // POST: VehicleModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VehicleModelId,VehicleMakeId,Name,Abrv")] VehicleModelViewModel vehicleModelVM)
        {
            if (ModelState.IsValid)
            {
                vehicleModelVM.VehicleModelId = Guid.NewGuid();
                //db.VehicleModels.Add(vehicleModel);
                vehicleService.CreateVehicleModel(vehicleModelVM);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.VehicleMakeId = new SelectList(db.VehicleMakes, "Id", "Name", vehicleModel.VehicleMakeId);
            ViewBag.VehicleMakeId = new SelectList(vehicleService.GetAllVehicleMakes(), "Id", "Name", vehicleModelVM.VehicleMakeId);
            return View(vehicleModelVM);
        }

        // GET: VehicleModels/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //VehicleModel vehicleModel = db.VehicleModels.Find(id);
            VehicleModelViewModel vehicleModel = vehicleService.FindIdVehicleModel(id);
            if (vehicleModel == null)
            {
                return HttpNotFound();
            }
            //ViewBag.VehicleMakeId = new SelectList(db.VehicleMakes, "Id", "Name", vehicleModel.VehicleMakeId);
            ViewBag.VehicleMakeId = new SelectList(vehicleService.GetAllVehicleMakes(), "Id", "Name", vehicleModel.VehicleMakeId);
            return View(vehicleModel);
        }

        // POST: VehicleModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VehicleModelId,VehicleMakeId,Name,Abrv")] VehicleModelViewModel vehicleModel)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(vehicleModel).State = EntityState.Modified;
                //db.SaveChanges();
                vehicleService.EditVehicleModel(vehicleModel);
                return RedirectToAction("Index");
            }
            //ViewBag.VehicleMakeId = new SelectList(db.VehicleMakes, "Id", "Name", vehicleModel.VehicleMakeId);
            ViewBag.VehicleMakeId = new SelectList(vehicleService.GetAllVehicleMakes(), "Id", "Name", vehicleModel.VehicleMakeId);
            return View(vehicleModel);
        }

        // GET: VehicleModels/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleModelViewModel vehicleModel = vehicleService.FindIdVehicleModel(id);
            if (vehicleModel == null)
            {
                return HttpNotFound();
            }
            return View(vehicleModel);
        }

        // POST: VehicleModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            //VehicleModel vehicleModel = db.VehicleModels.Find(id);
            //db.VehicleModels.Remove(vehicleModel);
            //db.SaveChanges();
            //return RedirectToAction("Index");

            VehicleModelViewModel vehicleModel = vehicleService.FindIdVehicleModel(id);
            vehicleService.DeleteVehicleModel(id);
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
