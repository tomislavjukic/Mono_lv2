using AutoMapper;
using Project.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Service.Models;
using System.Data.Entity;

namespace Project.Service.DAL
{
    public class VehicleService
    {
        private VehicleContext db = new VehicleContext();

        public static VehicleService instance;

        public VehicleService() { }

        public static VehicleService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new VehicleService();
                }
                return instance;
            }
        }

        public List<VehicleMakeViewModel> GetAllVehicleMakes()
        {

            return Mapper.Map<List<VehicleMakeViewModel>>(db.VehicleMakes.ToList());
        }

        public List<VehicleModelViewModel> GetAllVehicleModels()
        {

            return Mapper.Map<List<VehicleModelViewModel>>(db.VehicleModels.ToList());
        }

        public void CreateVehicleMake (VehicleMakeViewModel vehMakeVM)
        {
            //db.VehicleMakes.Add(vehicleMake);
            db.VehicleMakes.Add(Mapper.Map<VehicleMake>(vehMakeVM));
            db.SaveChanges();
        }

        public void CreateVehicleModel(VehicleModelViewModel vehModelVM)
        {
            //db.VehicleMakes.Add(vehicleMake);
            db.VehicleModels.Add(Mapper.Map<VehicleModel>(vehModelVM));
            db.SaveChanges();
        }

        public VehicleMakeViewModel FindIdVehicleMake(Guid? id)
        {
            VehicleMake vehMake = db.VehicleMakes.Find(id);
            return Mapper.Map<VehicleMakeViewModel>(vehMake);
           // return 0;
        }

        public VehicleModelViewModel FindIdVehicleModel(Guid? id)
        {
            VehicleModel vehModel = db.VehicleModels.Find(id);
            return Mapper.Map<VehicleModelViewModel>(vehModel);
            // return 0;
        }

        public void DeleteVehicleMake(Guid? id)
        {
            //VehicleMake vehicleMake = db.VehicleMakes.Find(id);
            //db.VehicleMakes.Remove(vehicleMake);
            //db.SaveChanges();
            //return RedirectToAction("Index");
            VehicleMake vehMake = db.VehicleMakes.Find(id);
            db.VehicleMakes.Remove(vehMake);
            db.SaveChanges();
        }

        public void DeleteVehicleModel(Guid? id)
        {
            //VehicleMake vehicleMake = db.VehicleMakes.Find(id);
            //db.VehicleMakes.Remove(vehicleMake);
            //db.SaveChanges();
            //return RedirectToAction("Index");
            VehicleModel vehModel = db.VehicleModels.Find(id);
            db.VehicleModels.Remove(vehModel);
            db.SaveChanges();
        }

        public void EditVehicleMake(VehicleMakeViewModel VehicleMakesVM)
        {
            db.Entry(Mapper.Map<VehicleMake>(VehicleMakesVM)).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void EditVehicleModel(VehicleModelViewModel VehicleModelVM)
        {
            db.Entry(Mapper.Map<VehicleModel>(VehicleModelVM)).State = EntityState.Modified;
            db.SaveChanges();
        }


        public IEnumerable<VehicleMakeViewModel>SortMake(string sortOrder, string searchBy, string search)
        {
            switch (sortOrder)
            {
                case "name_desc":
                    return Mapper.Map<IEnumerable<VehicleMakeViewModel>>(db.VehicleMakes.OrderByDescending(s => s.Name).ToList());
                case "Abrv":
                    //return vehicleMakes.OrderBy(s => s.Abrv);
                    return Mapper.Map<IEnumerable<VehicleMakeViewModel>>(db.VehicleMakes.OrderBy(s => s.Abrv).ToList());
                case "abrv_desc":
                    return Mapper.Map<IEnumerable<VehicleMakeViewModel>>(db.VehicleMakes.OrderByDescending(s => s.Abrv).ToList());
                    //vehicleMakes.OrderByDescending(s => s.Abrv);
                default:
                    return Mapper.Map<IEnumerable<VehicleMakeViewModel>>(db.VehicleMakes.OrderBy(s => s.Name).ToList());
                    //vehicleMakes.OrderBy(s => s.Name);
                    //break;
            }
           //return View(students.ToList());
           //return 
        }

        //public IEnumerable<VehicleMakeViewModel> FilterMake(string searchBy, string search)
        //{
        //    if(searchBy == "Abrv")
        //    {
        //        return Mapper.Map<IEnumerable<VehicleMakeViewModel>>(db.VehicleMakes.Where(x => x.Abrv == search || search == null).ToList());
        //    }
        //    else
        //    {
        //        return Mapper.Map<IEnumerable<VehicleMakeViewModel>>(db.VehicleMakes.Where(x => x.Name.StartsWith(search) || search == null).ToList());
        //    }
        //}


        // GET: VehicleMakes
        //public ViewResult Index()
        //    {
        //        return View(db.VehicleMakes.ToList());
        //    }

        //// GET: VehicleMakes/Details/5
        //public ActionResult Details(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    VehicleMake vehicleMake = db.VehicleMakes.Find(id);
        //    if (vehicleMake == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(vehicleMake);
        //}

        //// GET: VehicleMakes/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: VehicleMakes/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Name,Abrv")] VehicleMake vehicleMake)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        vehicleMake.Id = Guid.NewGuid();
        //        db.VehicleMakes.Add(vehicleMake);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(vehicleMake);
        //}

        //// GET: VehicleMakes/Edit/5
        //public ActionResult Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    VehicleMake vehicleMake = db.VehicleMakes.Find(id);
        //    if (vehicleMake == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(vehicleMake);
        //}

        //// POST: VehicleMakes/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Name,Abrv")] VehicleMake vehicleMake)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(vehicleMake).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(vehicleMake);
        //}

        //// GET: VehicleMakes/Delete/5
        //public ActionResult Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    VehicleMake vehicleMake = db.VehicleMakes.Find(id);
        //    if (vehicleMake == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(vehicleMake);
        //}

        //// POST: VehicleMakes/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(Guid id)
        //{
        //    VehicleMake vehicleMake = db.VehicleMakes.Find(id);
        //    db.VehicleMakes.Remove(vehicleMake);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
