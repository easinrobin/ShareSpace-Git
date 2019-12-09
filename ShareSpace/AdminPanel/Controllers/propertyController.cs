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

namespace AdminPanel.Controllers
{
    public class PropertyController : Controller
    {
        // GET: Property
        public ActionResult Index()
        {
            var model = PropertyManager.GetAllProperties();
            return View(model);
        }

        public ActionResult Create()
        {
            AdminVWModel adminVWModel = new AdminVWModel();
            _loadVendors();
            
            return View(adminVWModel);
        }

        [HttpPost]
        public ActionResult Create(AdminVWModel adminVWModel, HttpPostedFileBase images)
        {
            string createdBy = "Admin";
            string updatedBy = "Admin";
            DateTime createdOn = DateTime.Now;
            DateTime updatedOn = DateTime.Now;
            adminVWModel.Property.CreatedBy = createdBy;
            adminVWModel.Property.CreatedDate = createdOn;
            adminVWModel.Property.UpdateBy = updatedBy;
            adminVWModel.Property.UpdateDate = updatedOn;


            var propertyId = PropertyManager.InsertProperty(adminVWModel.Property);


            if (propertyId > 0)
            {
                adminVWModel.PropertyAddress.PropertyId = propertyId;
                _Address(adminVWModel);
                var PropertyAddressId = AddressManager.InsertAddress(adminVWModel.PropertyAddress);
                
                if (PropertyAddressId > 0)
                {
                    adminVWModel.PropertyService.PropertyId = propertyId;

                    var propertyServiceId = PropertyServiceManager.InsertPropertyService(adminVWModel.PropertyService);
                }
                //_saveFeatures (propertyId,  adminVWModel);
                //_saveGallery (propertyId, adminVWModel);
                //    adminVWModel.Policy.PropertyId = propertyId;
                //    var policyId = PolicyManager.Add(adminVWModel.Policy);
            }
            return RedirectToAction("Index");
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
                        savepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Upload/Images/Properties");
                        if (!Directory.Exists(savepath))
                            Directory.CreateDirectory(savepath);
                        savefile = Path.Combine(savepath, filename);
                        file.SaveAs(savefile);
                        pathUrl = "/Upload/Images/Properties/" + filename;
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
                    var id = GalleryManager.InsertGallery(gallery);
                }
            }
        }

        //public ActionResult _Property([Bind(Include = "PropertyId,PropertyName,ShareType,PropertyType,MaximumPerson,ShortDescription,Description,Price")] Property property)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var id = PropertyManager.InsertProperty(property);
        //        return RedirectToAction("_Address");
        //    }
        //    return View("~/Views/Property/Partial/_Property.cshtml");
        //}

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



        public ActionResult UpdateProperty(int propertyId)
        {
            PropertyManager.GetPropertyById(propertyId);
            return View("~/Views/Property/Create.cshtml");
        }


        //Delete
        public ActionResult DeleteProperty(long propertyId)
        {
            PropertyManager.DeleteProperty(propertyId);
            return RedirectToAction("Index");
        }

        public ActionResult FeatureList(int propertyId)
        {
            PropertyManager.GetPropertyById(propertyId);
            return View("~/Views/Property/Partial/_ServiceList.cshtml");
        }


        public ActionResult GalleryList(int propertyId)
        {
            PropertyManager.GetPropertyById(propertyId);
            return View("~/Views/Property/Partial/_Gallery.cshtml");
        }

        private void _loadVendors()
        {
            List<Vendor> dataList = VendorManager.GetAllVendors();
            ViewBag.VendorList = new SelectList(dataList, "VendorId", "FirstName");
        }
    }
}