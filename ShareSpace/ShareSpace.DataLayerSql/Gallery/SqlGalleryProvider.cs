using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareSpace.DataLayerSql.Common;
using ShareSpace.Models.Service;
using ShareSpace.Utility;

namespace ShareSpace.DataLayerSql.Gallery
{
    public class SqlGalleryProvider
    {
        #region Gallery
        public long InsertGallery(Models.Gallery.Gallery gallery)
        {
            long id = 0;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.INSERTGALLERYS, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter returnValue = new SqlParameter("@" + "GalleryId", SqlDbType.Int);
                returnValue.Direction = ParameterDirection.Output;
                command.Parameters.Add(returnValue);
                foreach (var gallerys in gallery.GetType().GetProperties())
                {
                    if (gallerys.Name != "GalleryId")
                    {
                        string name = gallerys.Name;
                        var value = gallerys.GetValue(gallery, null);

                        command.Parameters.Add(new SqlParameter("@" + name, value == null ? DBNull.Value : value));
                    }
                }
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    id = (int)command.Parameters["@GalleryId"].Value;
                }
                catch (Exception ex)
                {
                    throw new Exception("Execption Adding Data. " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return id;
        }

        public bool UpdateGallery(Models.Gallery.Gallery gallery)
        {
            bool isUpdate = true;

            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.UPDATEGALLERYS, connection);
                command.CommandType = CommandType.StoredProcedure;

                foreach (var gallerys in gallery.GetType().GetProperties())
                {
                    string name = gallerys.Name;
                    var value = gallerys.GetValue(gallery, null);
                    command.Parameters.Add(new SqlParameter("@" + name, value == null ? DBNull.Value : value));
                }

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    isUpdate = false;
                    throw new Exception("Exception Updating Data." + e.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return isUpdate;
        }

        public List<Models.Gallery.Gallery> GetAllGallerys()
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GETALLGALLERYS, connection);
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    List<Models.Gallery.Gallery> galleryList = new List<Models.Gallery.Gallery>();
                    galleryList = UtilityManager.DataReaderMapToList<Models.Gallery.Gallery>(dataReader);
                    return galleryList;
                }
                catch (Exception e)
                {
                    throw new Exception("Exception retrieving reviews. " + e.Message);
                }

                finally
                {
                    connection.Close();
                }
            }
        }

        public Models.Gallery.Gallery GetGalleryById(long galleryId)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GETGALLERYSBYID, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@GalleryId", galleryId));

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Models.Gallery.Gallery gallery = new Models.Gallery.Gallery();
                    gallery = UtilityManager.DataReaderMap<Models.Gallery.Gallery>(reader);
                    return gallery;
                }
                catch (Exception e)
                {
                    throw new Exception("Exception retrieving reviews. " + e.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public List<Models.Gallery.Gallery> GetGalleryByPropertyId(long propertyId)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.Get_Gallery_By_PropertyId, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@PropertyId", propertyId));

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    List<Models.Gallery.Gallery> galleryList = new List<Models.Gallery.Gallery>();
                    galleryList = UtilityManager.DataReaderMapToList<Models.Gallery.Gallery>(reader);
                    return galleryList;
                }
                catch (Exception e)
                {
                    throw new Exception("Exception retrieving reviews. " + e.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }



        public bool DeleteGallery(long galleryId)
        {
            bool isDelete = true;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.DELETEGALLERYS, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@GalleryID", galleryId));

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    isDelete = false;
                    throw new Exception("Exception Updating Data." + e.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return isDelete;
        }

        #endregion

    }
}
