using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using ShareSpace.BusinessLayer;
using ShareSpace.Models.Admin;
using ShareSpace.Models.Gallery;
using ShareSpace.Models.Property;
using ShareSpace.Models.Service;
using ShareSpace.Models.Vendor;

namespace AdminPanel.Areas.VendorPanel.Controllers
{
    public class VendorHomeController : Controller
    {
        // GET: VendorPanel/VendorHome
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Properties()
        {
            long vendorId = 0;
            vendorId = (long)Session["VendorId"];
            var model = VendorManager.GetVendorsPropertyById(vendorId);
            return View(model);
        }

        public ActionResult Create()
        {
            AdminVWModel adminVWModel = new AdminVWModel();
            _loadServices(adminVWModel);

            return View(adminVWModel);
        }

        public ActionResult UpdateProperty(int propertyId)
        {
            _loadVendors();
            AdminVWModel adminVwModel = new AdminVWModel();
            adminVwModel.Property = PropertyManager.GetPropertyById(propertyId);
            adminVwModel.PropertyAddress = AddressManager.GetAddressByPropertyId(propertyId);
            return View("~/Areas/VendorPanel/Views/VendorHome/UpdateProperty.cshtml", adminVwModel);
        }

        public ActionResult GalleryList(long propertyId)
        {
            ViewBag.PropertyId = propertyId;
            AdminVWModel adminVwModel = new AdminVWModel();
            adminVwModel.GalleryList = GalleryManager.GetGalleryByPropertyId(propertyId);

            return View(adminVwModel.GalleryList);
        }

        public ActionResult CreateGallery(long propertyId)
        {
            AdminVWModel adminVwModel = new AdminVWModel();
            Gallery gallery = new Gallery()
            {
                PropertyId = propertyId
            };
            adminVwModel.Gallery = gallery;
            return View(adminVwModel);
        }

        public ActionResult ServiceList(int propertyId)
        {
            ViewBag.PropertyId = propertyId;
            AdminVWModel adminVwModel = new AdminVWModel();
            adminVwModel.PropertyServiceVwModel = PropertyServiceManager.GetServicesByPropertyId(propertyId);
            return View(adminVwModel);
        }

        public ActionResult CreateServices(long propertyId)
        {
            AdminVWModel adminVwModel = new AdminVWModel();
            _loadServices(adminVwModel);
            PropertyService propertyService = new PropertyService()
            {
                PropertyId = propertyId
            };
            adminVwModel.PropertyService = propertyService;
            return View(adminVwModel);
        }

        public ActionResult Profile()
        {
            AdminVWModel av = new AdminVWModel();
            long vendorId = Session["VendorId"] != null ? Convert.ToInt64(Session["VendorId"]) : 0;
            av.Vendors = VendorManager.GetVendorById(vendorId);
            //VendorManager.GetVendorById(vendorId);
            return View("~/Areas/VendorPanel/Views/VendorHome/Profile.cshtml", av);
        }

        [HttpPost]
        public ActionResult Profile(AdminVWModel av, HttpPostedFileBase image)
        {
            _UploadImage(av, image);
            av.Vendors.CreatedBy = av.Vendors.FirstName;
            av.Vendors.UpdateBy = av.Vendors.FirstName;
            av.Vendors.IsInActive = false;
            av.Vendors.CreatedDate = DateTime.Today;
            av.Vendors.UpdateDate = DateTime.Today;
            Int64 vendorId = Session["VendorId"] != null ? Convert.ToInt64(Session["VendorId"]) : 0;
            av.Vendors.VendorId = vendorId;
            bool isUpdate = VendorManager.UpdateVendor(av.Vendors);
            return View("Index");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(AdminVWModel adminVWModel, HttpPostedFileBase images)
        {
            //Session["VendorId"] = adminVWModel.Property.VendorId;
            adminVWModel.Property.VendorId = (long)Session["VendorId"];
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
            return RedirectToAction("Properties");
        }

        [HttpPost]
        [ValidateInput(false)]
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

            return RedirectToAction("Properties");
        }

        [HttpPost]
        public ActionResult CreateGallery(AdminVWModel adminVwModel, HttpPostedFileBase images)
        {
            if (adminVwModel != null)
            {

                foreach (var file in adminVwModel.Files)
                {
                    if (Request.Url != null)
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
                        }

                        var gallery = new Gallery
                        {
                            ImageUrl = pathUrl,
                            ImageType = "Feature Image",
                            PropertyId = adminVwModel.Gallery.PropertyId,
                            CreatedBy = "Admin",
                            UpdateBy = "Admin",
                            CreatedDate = DateTime.Now,
                            UpdateDate = DateTime.Now
                        };
                        var galleryId = GalleryManager.InsertGallery(gallery);
                    }
                }
            }
            return RedirectToAction("GalleryList", new
            {
                PropertyId = adminVwModel.Gallery.PropertyId
            });
        }

        [HttpPost]
        public ActionResult CreateServices(AdminVWModel adminVwModel)
        {
            _ServiceList(adminVwModel.PropertyService.PropertyId, adminVwModel, adminVwModel.ServiceList?.FindAll((x => x.IsSelected)));
            return RedirectToAction("Properties");
        }
        //load
        private void _loadVendors()
        {
            List<ShareSpace.Models.Vendor.Vendor> dataList = VendorManager.GetAllVendors();
            ViewBag.VendorList = new SelectList(dataList, "VendorId", "FirstName");
        }

        private List<Services> _loadServices(AdminVWModel adminVWModel)
        {
            List<Services> serviceList = ServiceManager.GetAllServices();
            return adminVWModel.ServiceList = serviceList;
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
                    IsHidden = false
                };

                var serviceId = PropertyServiceManager.InsertPropertyService(services);
            }
        }

        private void _Gallery(long propertyId, AdminVWModel adminVWModel)
        {
            if (adminVWModel != null)
            {
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
                    }

                    var gallery = new Gallery
                    {
                        ImageUrl = pathUrl,
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
        }

        public ActionResult HideProperty(long propertyId)
        {
            PropertyManager.HideProperty(propertyId);
            return RedirectToAction("Properties");
        }

        public ActionResult DeleteGalleryItem(long galleryId, AdminVWModel adminVwModel)
        {
            GalleryManager.DeleteGallery(galleryId);
            return RedirectToAction("Properties");
        }

        public ActionResult DeletePropertyServiceItem(long propertyServiceId)
        {
            PropertyServiceManager.DeletePropertyServiceById(propertyServiceId);
            return RedirectToAction("Properties");
        }

        private void _UploadImage(AdminVWModel av, HttpPostedFileBase images)
        {
            foreach (var file in av.Files.Take(1))
            {
                string pathUrl = "";

                if (file != null)
                {
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
                        av.Vendors.VendorPhoto = pathUrl;
                    }
                }
                else
                {
                    pathUrl = av.Vendors.VendorPhoto;
                }
            }
        }
    }
}