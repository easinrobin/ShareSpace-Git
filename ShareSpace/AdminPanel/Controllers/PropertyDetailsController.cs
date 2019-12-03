using System.Web;
using System.Web.Mvc;
using ShareSpace.BusinessLayer;
using ShareSpace.Models.Admin;

namespace AdminPanel.Controllers
{
    public class PropertyDetailsController : Controller
    {
        // GET: PropertyDetails/Create
        public ActionResult Create()
        {
            AdminVWModel adminVWModel = new AdminVWModel();
            //ViewBag.PropertyTypeList = EnumService.GetPropertyTypeList();
            //adminVWModel.Facilities = FacilityManager.GetAllDetails();
            //var types = FacilityManager.GetAllServiceType();
            //adminVWModel.ServiceTypes = types.Where(x => x.TypeFor == "Property" || x.TypeFor == "All").OrderBy(x => x.TypeOrder).ToList();
            //List<Country> dataList = CountryManager.GetAll();
            //ViewBag.CountryList = new SelectList(dataList, "CountryCode", "Name");
            //var policies = BHListItem.PolicyNames();
            //ViewBag.PolicyList = new SelectList(policies, "Value", "Value");
            return View(adminVWModel);
        }

        // POST: PropertyDetails/Create
        [HttpPost]
        public ActionResult Create(AdminVWModel adminVWModel, HttpPostedFileBase images)
        {
            try
            {
                //string createdBy = "Admin";
                //string updatedBy = "Admin";
                //DateTime createdOn = DateTime.Now;
                //DateTime updatedOn = DateTime.Now;
                //adminVWModel.Property.CreatedBy = createdBy;
                //adminVWModel.Property.CreatedOn = createdOn;
                //adminVWModel.Property.UpdatedBy = updatedBy;
                //adminVWModel.Property.UpdatedOn = updatedOn;
                //var propertyId = PropertyManager.Add(adminVWModel.Property);
                //if (propertyId > 0)
                //{
                //    var addressId = AddressManager.Add(adminVWModel.Address);
                //    if (addressId > 0)
                //    {
                //        var branchId = _saveBranch(addressId, propertyId, adminVWModel);

                //        _saveFeatures(propertyId, branchId, adminVWModel.Facilities);
                //    }
                //    _saveGallery(propertyId, adminVWModel);
                //    adminVWModel.Policy.PropertyId = propertyId;
                //    var policyId = PolicyManager.Add(adminVWModel.Policy);
                //}

                //// TODO: Add insert logic here

                return View();
            }
            catch
            {
                //ViewBag.PropertyTypeList = EnumService.GetPropertyTypeList();
                //adminVWModel.Facilities = FacilityManager.GetAllDetails();
                //adminVWModel.ServiceTypes = FacilityManager.GetAllServiceType();
                //List<Country> dataList = CountryManager.GetAll();
                //ViewBag.CountryList = new SelectList(dataList, "CountryCode", "Name");
                //var data = BHListItem.PolicyNames();
                //ViewBag.Policies = new SelectList(data, "Value", "Value");
                return View(adminVWModel);
            }
        }

        //private long _saveBranch(long addressId, long propertyId, AdminVWModel adminVWModel)
        //{
        //    var branch = new Branch
        //    {
        //        AddressId = addressId,
        //        PropertyId = propertyId,
        //        TotalRoom = adminVWModel.Property.TotalRoom,
        //        CreatedBy = adminVWModel.Property.CreatedBy,
        //        CreatedOn = adminVWModel.Property.CreatedOn,
        //        UpdatedBy = adminVWModel.Property.UpdatedBy,
        //        UpdatedOn = adminVWModel.Property.UpdatedOn
        //    };
        //    long branchId = BranchManager.Add(branch);
        //    return branchId;
        //}

        //private void _saveFeatures(long propertyId, long branchId, List<FacilityDetails> facilities)
        //{
        //    foreach (var f in facilities)
        //    {
        //        if (f.IsSelected)
        //        {
        //            var feature = new Feature
        //            {
        //                BranchId = branchId,
        //                Description = "",
        //                FacilityId = f.Id,
        //                Name = f.Name,
        //                PropertyId = propertyId,
        //                RoomId = 0,
        //                Type = Utility.Hotels.Enum.FeatureType.Property.ToString(),
        //                Icon = f.Icon,
        //                CreatedBy = "Admin",
        //                UpdatedBy = "Admin",
        //                CreatedOn = DateTime.Now,
        //                UpdatedOn = DateTime.Now
        //            };
        //            var id = FeatureManager.Add(feature);
        //        }

        //    }
        //}

        //private void _saveGallery(long propertyId, AdminVWModel adminVWModel)
        //{
        //    if (adminVWModel != null)
        //    {
        //        foreach (var file in adminVWModel.Files)
        //        {
        //            string pathUrl = "";

        //            if (file.ContentLength > 0)
        //            {
        //                string savepath, savefile;
        //                var filename = Path.GetFileName(Guid.NewGuid() + file.FileName);
        //                savepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Upload/Images/Properties");
        //                if (!Directory.Exists(savepath))
        //                    Directory.CreateDirectory(savepath);
        //                savefile = Path.Combine(savepath, filename);
        //                file.SaveAs(savefile);
        //                pathUrl = "/Upload/Images/Properties/" + filename;
        //            }
        //            var gallery = new Gallery
        //            {
        //                Path = pathUrl,
        //                Alt = adminVWModel.Property.Name,
        //                Type = Utility.Hotels.Enum.GalleryType.Property.ToString(),
        //                XId = propertyId,
        //                Title = adminVWModel.Property.Name,
        //                GalleryName = Utility.Hotels.Enum.GalleryName.Property_Views.ToString(),
        //                CreatedBy = "Admin",
        //                UpdatedBy = "Admin",
        //                CreatedOn = DateTime.Now,
        //                UpdatedOn = DateTime.Now
        //            };
        //            var id = GalleryManager.Add(gallery);
        //        }
        //    }
        //}

        //// GET: PropertyDetails/Edit/5
        //public ActionResult Edit(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Property property = PropertyManager.GetbyId(Convert.ToInt64(id));
        //    ViewBag.PropertyTypeList = EnumService.GetPropertyTypeList();
        //    if (property == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(property);
        //}

        //// POST: PropertyDetails/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Name,Website,TotalRoom,Type,AnOverview")] Property property)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        bool isUpdate = PropertyManager.Update(property);
        //        return RedirectToAction("Index");
        //    }
        //    return View(property);
        //}

        //// GET: PropertyDetails/EditAddress/5
        //public ActionResult EditAddress(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    var address = AddressManager.GetbyId(Convert.ToInt64(id));
        //    List<Country> dataList = CountryManager.GetAll();
        //    ViewBag.CountryList = new SelectList(dataList, "CountryCode", "Name");
        //    if (address == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(address);
        //}

        //// POST: PropertyDetails/EditAddress/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult EditAddress([Bind(Include = "Id,Attention,Address1,Address2,Zip,City,State,Phone,Fax,Mobile,Email,SpecialInstruction,AddressType,BuiltIn,CountryCode,WorldStateId,WorldCityId")] Address address)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        bool isUpdate = AddressManager.Update(address);
        //        return RedirectToAction("Index");
        //    }
        //    return View(address);
        //}

        //// GET: PropertyDetails/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: PropertyDetails/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //#region Gallery
        ////PropertyDetails/GalleryList/5
        //public ActionResult GalleryList(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ViewBag.PropertyId = id.ToString();
        //    var model = GalleryManager.GetAllByXTypeAndXId(Utility.Hotels.Enum.GalleryType.Property.ToString(), Convert.ToInt64(id));
        //    if (model == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(model);
        //}

        //// GET: Gallery/Create
        //public ActionResult CreateGallery(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    var galleryNames = BHListItem.GetGalleryNames();
        //    ViewBag.GalleryNameList = new SelectList(galleryNames, "Value", "Value");
        //    AdminVWModel adminVWModel = new AdminVWModel();
        //    var gallery = new Gallery
        //    {
        //        XId = id,
        //        Type = Utility.Hotels.Enum.GalleryType.Property.ToString()
        //    };
        //    adminVWModel.Gallery = gallery;
        //    return View(adminVWModel);
        //}

        //// POST: Gallery/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult CreateGallery(AdminVWModel adminVWModel, HttpPostedFileBase images)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (adminVWModel != null)
        //        {
        //            foreach (var file in adminVWModel.Files)
        //            {
        //                string pathUrl = "";

        //                if (file.ContentLength > 0)
        //                {
        //                    string savepath, savefile;
        //                    var filename = Path.GetFileName(Guid.NewGuid() + file.FileName);
        //                    savepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Upload/Images/Properties");
        //                    if (!Directory.Exists(savepath))
        //                        Directory.CreateDirectory(savepath);
        //                    savefile = Path.Combine(savepath, filename);
        //                    file.SaveAs(savefile);
        //                    pathUrl = "/Upload/Images/Properties/" + filename;
        //                }
        //                var gallery = new Gallery
        //                {
        //                    Path = pathUrl,
        //                    Alt = adminVWModel.Gallery.Alt,
        //                    Type = Utility.Hotels.Enum.GalleryType.Property.ToString(),
        //                    XId = adminVWModel.Gallery.XId,
        //                    Title = adminVWModel.Gallery.Title,
        //                    GalleryName = adminVWModel.Gallery.GalleryName,
        //                    CreatedBy = "Admin",
        //                    UpdatedBy = "Admin",
        //                    CreatedOn = DateTime.Now,
        //                    UpdatedOn = DateTime.Now,
        //                    IsThumbnail = adminVWModel.Gallery.IsThumbnail
        //                };
        //                var id = GalleryManager.Add(gallery);
        //            }
        //        }
        //        return RedirectToAction("GalleryList/" + adminVWModel.Gallery.XId);
        //    }

        //    return View(adminVWModel);
        //}

        //[HttpPost, ActionName("DeleteGallery")]
        ////[ValidateAntiForgeryToken]
        //public ActionResult DeleteGallery(FormCollection fcNotUsed, long id)
        //{
        //    var data = GalleryManager.GetbyId(id);
        //    bool isDelete = GalleryManager.Delete(id);
        //    return RedirectToAction("GalleryList/" + data.XId);
        //}
        //#endregion

        //#region Features
        //public ActionResult FeatureList(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ViewBag.PropertyId = id.ToString();
        //    var model = FeatureManager.GetOfferDetailsByPropertyId(Convert.ToInt64(id));
        //    if (model == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(model);
        //}
        //// GET: Gallery/Create
        //public ActionResult CreateFeature(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ViewBag.PropertyId = id.ToString();
        //    AdminVWModel adminVWModel = new AdminVWModel();
        //    adminVWModel.Branch = BranchManager.GetAllByPropertyId(Convert.ToInt64(id)).Take(1).SingleOrDefault();
        //    var types = FacilityManager.GetAllServiceType();
        //    adminVWModel.ServiceTypes =  types.Where(x => x.TypeFor == "Property" || x.TypeFor == "All").OrderBy(x => x.TypeOrder).ToList();
        //    adminVWModel.Facilities = FacilityManager.GetAllDetailByType("Property");
        //    var features = FeatureManager.GetFeatureDetailsByPropertyIds(id.ToString()); //FeatureManager.GetbyPropertyId(Convert.ToInt64(id));
        //    adminVWModel.Facilities.ToList()
        //                    .ForEach(x =>
        //                    {
        //                        if (features.Any(y => y.Name == x.Name))
        //                        {
        //                            x.IsSelected = true;
        //                        }
        //                    });
        //    return View(adminVWModel);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult CreateFeature(AdminVWModel adminVWModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (adminVWModel != null)
        //        {
        //            _saveFeatures(Convert.ToInt64(adminVWModel.Branch.PropertyId), adminVWModel.Branch.Id, adminVWModel.Facilities);
        //        }
        //        return RedirectToAction("FeatureList/" + adminVWModel.Branch.PropertyId);
        //    }

        //    return View(adminVWModel);
        //}

        //[HttpPost, ActionName("DeleteFeature")]
        //public ActionResult DeleteFeature(FormCollection fcNotUsed, long id)
        //{
        //    var data = FeatureManager.GetbyId(id);
        //    bool isDelete = FeatureManager.Delete(id);
        //    return RedirectToAction("FeatureList/" + data.PropertyId);
        //}
        //#endregion

        //#region Policy
        //public ActionResult PolicyList(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ViewBag.PropertyId = id.ToString();
        //    var model = PolicyManager.GetAllByPropertyId(Convert.ToInt64(id));
        //    if (model == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(model);
        //}
        //// GET: Gallery/Create
        //public ActionResult CreatePolicy(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ViewBag.PropertyId = id.ToString();
        //    var data = BHListItem.PolicyNames();
        //    ViewBag.Policies = new SelectList(data, "Value", "Value");
        //    AdminVWModel adminVWModel = new AdminVWModel();
        //    adminVWModel.Property = PropertyManager.GetbyId(Convert.ToInt64(id));
        //    return View(adminVWModel);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult CreatePolicy(AdminVWModel adminVWModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (adminVWModel != null)
        //        {
        //            adminVWModel.Policy.PropertyId = adminVWModel.Property.Id;
        //            var id = PolicyManager.Add(adminVWModel.Policy);
        //        }
        //        return RedirectToAction("PolicyList/" + adminVWModel.Property.Id);
        //    }

        //    return View(adminVWModel);
        //}
        //public ActionResult EditPolicy(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    AdminVWModel adminVWModel = new AdminVWModel();
        //    adminVWModel.Policy = PolicyManager.GetbyId(Convert.ToInt64(id));
        //    var data = BHListItem.PolicyNames();
        //    ViewBag.Policies = new SelectList(data, "Value", "Value");
        //    return View(adminVWModel);
        //}

        //// POST: PropertyDetails/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult EditPolicy(AdminVWModel adminVWModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        bool isUpdate = PolicyManager.Update(adminVWModel.Policy);
        //        return RedirectToAction("PolicyList/" + adminVWModel.Policy.PropertyId);
        //    }
        //    var data = BHListItem.PolicyNames();
        //    ViewBag.Policies = new SelectList(data, "Value", "Value");
        //    return View(adminVWModel);
        //}


        //[HttpPost, ActionName("DeletePolicy")]
        //public ActionResult DeletePolicy(FormCollection fcNotUsed, long id)
        //{
        //    var data = PolicyManager.GetbyId(id);
        //    bool isDelete = PolicyManager.Delete(id);
        //    return RedirectToAction("PolicyList/" + data.PropertyId);
        //}
        //#endregion

        //#region Review
        //public ActionResult ReviewList(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ViewBag.PropertyId = id.ToString();
        //    var model = ReviewManager.GetByPropertyId(Convert.ToInt64(id));
        //    if (model == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(model);
        //}
        //// GET: Review/Create
        //public ActionResult CreateReview(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ViewBag.PropertyId = id.ToString();
        //    AdminVWModel adminVWModel = new AdminVWModel();
        //    adminVWModel.Property = PropertyManager.GetbyId(Convert.ToInt64(id));
        //    return View(adminVWModel);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult CreateReview(AdminVWModel adminVWModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (adminVWModel != null)
        //        {
        //            adminVWModel.Review.PropertyId = adminVWModel.Property.Id;
        //            adminVWModel.Review.BranchId = 0;
        //            adminVWModel.Review.RoomId = 0;
        //            var id = ReviewManager.Add(adminVWModel.Review);
        //        }
        //        return RedirectToAction("ReviewList/" + adminVWModel.Property.Id);
        //    }

        //    return View(adminVWModel);
        //}
        //public ActionResult EditReview(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    AdminVWModel adminVWModel = new AdminVWModel();
        //    adminVWModel.Review = ReviewManager.GetbyId(Convert.ToInt64(id));

        //    return View(adminVWModel);
        //}

        //// POST: PropertyDetails/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult EditReview(AdminVWModel adminVWModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        bool isUpdate = ReviewManager.Update(adminVWModel.Review);
        //        return RedirectToAction("ReviewList/" + adminVWModel.Review.PropertyId);
        //    }
        //    return View(adminVWModel);
        //}


        //[HttpPost, ActionName("DeleteReview")]
        //public ActionResult DeleteReview(FormCollection fcNotUsed, long id)
        //{
        //    var data = ReviewManager.GetbyId(id);
        //    bool isDelete = ReviewManager.Delete(id);
        //    return RedirectToAction("ReviewList/" + data.PropertyId);
        //}
        //#endregion

    }
}
