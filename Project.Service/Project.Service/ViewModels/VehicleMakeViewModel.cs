using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Service.Models;
using PagedList;
using PagedList.Mvc;

namespace Project.Service.ViewModels
{
    public class VehicleMakeViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }

        //public PagedList.IPagedList<VehicleMakeViewModel> VehicleMake { get; set; }
        public virtual ICollection<VehicleModel> VehicleModels { get; set; }
    }
}
