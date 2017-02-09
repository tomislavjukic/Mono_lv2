using PagedList;
using Project.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList.Mvc;

namespace Project.Service.DAL
{
    public interface IVehicleService
    {
        List<VehicleMakeViewModel> GetAllVehicleMakes();
        List<VehicleModelViewModel> GetAllVehicleModels();
        void CreateVehicleMake(VehicleMakeViewModel vehMakeVM);
        void CreateVehicleModel(VehicleModelViewModel vehModelVM);
        VehicleMakeViewModel FindIdVehicleMake(Guid? id);
        VehicleModelViewModel FindIdVehicleModel(Guid? id);
        void DeleteVehicleMake(Guid? id);
        void DeleteVehicleModel(Guid? id);
        void EditVehicleMake(VehicleMakeViewModel VehicleMakesVM);
        void EditVehicleModel(VehicleModelViewModel VehicleModelVM);
        IPagedList<VehicleMakeViewModel> SortPageFilterMake(string searchBy, string search, int? page, string sortBy);
        IPagedList<VehicleModelViewModel> SortPageFilterModel(string searchBy, string search, int? page, string sortBy);
    }
}
