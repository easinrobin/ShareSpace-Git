using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShareSpace.BusinessLayer;
using ShareSpace.Models.Admin;
using ShareSpace.Models.Gallery;
using ShareSpace.Models.Property;
using ShareSpace.Models.Service;
using ShareSpace.Models.Vendor;

namespace AdminPanel.Controllers
{
    public class PropertyController : Controller
    {
        // GET: Property
        public ActionResult Index()
        {
            var model = PropertyManager.GetAdminPropertyList();
            return View(model);
        }


        public ActionResult Create()
        {
            AdminVWModel adminVWModel = new AdminVWModel();
            _loadVendors();
            _loadServices(adminVWModel);

            return View(adminVWModel);
        }

        //Update
        public ActionResult UpdateProperty(int propertyId)
        {
            _loadVendors();
            AdminVWModel adminVwModel = new AdminVWModel();
            adminVwModel.Property = PropertyManager.GetPropertyById(propertyId);
            adminVwModel.PropertyAddress = AddressManager.GetAddressByPropertyId(propertyId);
            return View("~/Views/Property/UpdateProperty.cshtml", adminVwModel);
        }

        public ActionResult GalleryList(long propertyId)
        {
            ViewBag.PropertyId = propertyId;
            AdminVWModel adminVwModel = new AdminVWModel();
            adminVwModel.Gallery = GalleryManager.GetGalleryByPropertyId(propertyId);

            return View(adminVwModel);
        }

        [HttpPost]
        public ActionResult Create(AdminVWModel adminVWModel, HttpPostedFileBase images)
        {
            _Property(adminVWModel, images);
            var propertyId = PropertyManager.InsertProperty(adminVWModel.Property);

            if (propertyId > 0)
            {
                adminVWModel.PropertyAddress.PropertyId = propertyId;
                _Address(adminVWModel);
                var propertyAddressId = AddressManager.InsertAddress(adminVWModel.PropertyAddress);

                _ServiceList(propertyId, adminVWModel, adminVWModel.ServiceList?.FindAll((x => x.IsSelected)));

                _Gallery(propertyId, adminVWModel);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult UpdateProperty(AdminVWModel adminVwModel, HttpPostedFileBase images)
        {
            const string createdBy = "Admin";
            const string updatedBy = "Admin";
            var createdOn = DateTime.Now;
            var updatedOn = DateTime.Now;
            adminVwModel.Property.CreatedBy = createdBy;
            adminVwModel.Property.CreatedDate = createdOn;
            adminVwModel.Property.UpdateBy = updatedBy;
            adminVwModel.Property.UpdateDate = updatedOn;


            foreach (var file in adminVwModel.Files.Take(1))
            {
                string pathUrl = "";

                if (file.ContentLength > 0)
                {
                    string savepath, savefile;
                    var filename = Path.GetFileName(Guid.NewGuid() + file.FileName);
                    savepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img/Offices/");
                    if (!Directory.Exists(savepath))
                        Directory.CreateDirectory(savepath);
                    savefile = Path.Combine(savepath, filename);
                    file.SaveAs(savefile);
                    pathUrl = "/img/Offices/" + filename;
                    adminVwModel.Property.FeatureImage = pathUrl;
                }
            }


            bool isUpdateProperty = PropertyManager.UpdateProperty(adminVwModel.Property);
            bool isUpdatePropertyAddress = AddressManager.UpdateAddress(adminVwModel.PropertyAddress);

            return RedirectToAction("Index");
        }

        public void _Property(AdminVWModel adminVWModel, HttpPostedFileBase images)
        {
            string createdBy = "Admin";
            string updatedBy = "Admin";
            DateTime createdOn = DateTime.Now;
            DateTime updatedOn = DateTime.Now;
            adminVWModel.Property.CreatedBy = createdBy;
            adminVWModel.Property.CreatedDate = createdOn;
            adminVWModel.Property.UpdateBy = updatedBy;
            adminVWModel.Property.UpdateDate = updatedOn;

            foreach (var file in adminVWModel.Files.Take(1))
            {
                string pathUrl = "";

                if (file.ContentLength > 0)
                {
                    string savepath, savefile;
                    var filename = Path.GetFileName(Guid.NewGuid() + file.FileName);
                    savepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img/Offices/");
                    if (!Directory.Exists(savepath))
                        Directory.CreateDirectory(savepath);
                    savefile = Path.Combine(savepath, filename);
                    file.SaveAs(savefile);
                    pathUrl = "/img/Offices/" + filename;
                    adminVWModel.Property.FeatureImage = pathUrl;
                }
            }

        }

        public void _Address(AdminVWModel adminVWModel)
        {
            string createdBy = "Admin";
            string updatedBy = "Admin";
            DateTime createdOn = DateTime.Now;
            DateTime updatedOn = DateTime.Now;
            adminVWModel.PropertyAddress.CreatedBy = createdBy;
            adminVWModel.PropertyAddress.CreatedDate = createdOn;
            adminVWModel.PropertyAddress.UpdateBy = updatedBy;
            adminVWModel.PropertyAddress.UpdateDate = updatedOn;

        }

        public void _ServiceList(long propertyId, AdminVWModel adminVwModel, List<Services> serviceList)
        {
            //_loadServices(adminVwModel);

            foreach (var service in serviceList)
            {
                var services = new PropertyService
                {
                    PropertyId = propertyId,
                    ServiceId = service.ServiceId,
                    ServiceName = service.ServiceName,
                    IsHidden = 0
                };

                var serviceId = PropertyServiceManager.InsertPropertyService(services);
            }
        }

        private void _Gallery(long propertyId, AdminVWModel adminVWModel)
        {
            if (adminVWModel != null)
            {
                string imageUrl = "";
                string imageUrl1 = "";
                string imageUrl2 = "";
                string imageUrl3 = "";
                string imageUrl4 = "";
                string imageUrl5 = "";
                string imageUrl6 = "";

                foreach (var file in adminVWModel.Files)
                {
                    string pathUrl = "";

                    if (file.ContentLength > 0)
                    {
                        string savepath, savefile;
                        var filename = Path.GetFileName(Guid.NewGuid() + file.FileName);
                        savepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img/Offices/");
                        if (!Directory.Exists(savepath))
                            Directory.CreateDirectory(savepath);
                        savefile = Path.Combine(savepath, filename);
                        file.SaveAs(savefile);
                        pathUrl = "/img/Offices/" + filename;

                        if (string.IsNullOrEmpty(imageUrl))
                            imageUrl = pathUrl;
                        else if (string.IsNullOrEmpty(imageUrl1))
                            imageUrl1 = pathUrl;
                        else if (string.IsNullOrEmpty(imageUrl2))
                            imageUrl2 = pathUrl;
                        else if (string.IsNullOrEmpty(imageUrl3))
                            imageUrl3 = pathUrl;
                        else if (string.IsNullOrEmpty(imageUrl3))
                            imageUrl4 = pathUrl;
                        else if (string.IsNullOrEmpty(imageUrl3))
                            imageUrl5 = pathUrl;
                        else if (string.IsNullOrEmpty(imageUrl3))
                            imageUrl6 = pathUrl;
                    }
                }

                var gallery = new Gallery
                {
                    ImageUrl = imageUrl,
                    Image1 = imageUrl1,
                    Image2 = imageUrl2,
                    Image3 = imageUrl3,
                    Image4 = imageUrl4,
                    Image5 = imageUrl5,
                    Image6 = imageUrl6,
                    ImageType = "Feature Image",
                    PropertyId = propertyId,
                    CreatedBy = "Admin",
                    UpdateBy = "Admin",
                    CreatedDate = DateTime.Now,
                    UpdateDate = DateTime.Now
                };
                var galleryId = GalleryManager.InsertGallery(gallery);
            }
        }


        //Delete
        public ActionResult DeleteProperty(long propertyId)
        {
            PropertyManager.DeleteProperty(propertyId);
            return RedirectToAction("Index");
        }

        public ActionResult HideProperty(long propertyId)
        {
            PropertyManager.HideProperty(propertyId);
            return RedirectToAction("Index");
        }



        private void _loadVendors()
        {
            List<Vendor> dataList = VendorManager.GetAllVendors();
            ViewBag.VendorList = new SelectList(dataList, "VendorId", "FirstName");
        }

        private List<Services> _loadServices(AdminVWModel adminVWModel)
        {
            List<Services> serviceList = ServiceManager.GetAllServices();
            return adminVWModel.ServiceList = serviceList;
        }
    }
}