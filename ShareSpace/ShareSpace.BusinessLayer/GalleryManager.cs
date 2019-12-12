using System.Collections.Generic;
using ShareSpace.DataLayerSql.Gallery;
using ShareSpace.Models.Gallery;

namespace ShareSpace.BusinessLayer
{
    public class GalleryManager
    {
        #region Get
        public static List<Gallery> GetAllGallerys()
        {
            SqlGalleryProvider sqlGalleryProvider = new SqlGalleryProvider();
            var allGallerys = sqlGalleryProvider.GetAllGallerys();
            return allGallerys;
        }

        public static Gallery GetGalleryById(long galleryId)
        {
            SqlGalleryProvider sqlGalleryProvider = new SqlGalleryProvider();
            return sqlGalleryProvider.GetGalleryById(galleryId);
        }

        public static Gallery GetGalleryByPropertyId(long propertyId)
        {
            SqlGalleryProvider sqlGalleryProvider = new SqlGalleryProvider();
            return sqlGalleryProvider.GetGalleryByPropertyId(propertyId);
        }
        #endregion


        #region Set
        public static long InsertGallery(Gallery gallery)
        {
            SqlGalleryProvider sqlGalleryProvider = new SqlGalleryProvider();
            var id = sqlGalleryProvider.InsertGallery(gallery);
            return id;
        }

        public static bool UpdateGallery(Gallery gallery)
        {
            SqlGalleryProvider sqlGalleryProvider = new SqlGalleryProvider();
            var isUpdate = sqlGalleryProvider.UpdateGallery(gallery);
            return isUpdate;
        }

        public static bool DeleteGallery(long galleryId)
        {
            SqlGalleryProvider sqlGalleryProvider = new SqlGalleryProvider();
            var isDelete = sqlGalleryProvider.DeleteGallery(galleryId);
            return isDelete;
        }

        #endregion
    }
}
