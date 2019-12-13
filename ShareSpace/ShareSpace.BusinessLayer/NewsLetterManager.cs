using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareSpace.DataLayerSql.NewsLetter;
using ShareSpace.Models.NewsLetter;


namespace ShareSpace.BusinessLayer
{
    public class NewsLetterManager
    {
        #region Get
        public static List<NewsLetter> GetAllNewsLetters()
        {
            SqlNewsLetterProvider sqlNewsLetterProvider = new SqlNewsLetterProvider();
            var allNewsLetters = sqlNewsLetterProvider.GetAllNewsLetters();
            return allNewsLetters;


        }

        public static NewsLetter GetNewsLetterById(long newsletterId)
        {
            SqlNewsLetterProvider sqlNewsLetterProvider = new SqlNewsLetterProvider();
            return sqlNewsLetterProvider.GetNewsletterById(newsletterId);
        }



        #endregion


        #region Set
        public static long InsertNewsLetter(NewsLetter newsletter)
        {
            SqlNewsLetterProvider sqlNewsLetterProvider = new SqlNewsLetterProvider();
            var id = sqlNewsLetterProvider.InsertNewsLetter(newsletter);
            return id;
        }

        public static bool UpdateNewsLetter(NewsLetter newsletter)
        {
            SqlNewsLetterProvider sqlNewsLetterProvider = new SqlNewsLetterProvider();
            var isUpdate = sqlNewsLetterProvider.UpdateNewsLetter(newsletter);
            return isUpdate;
        }

        public static bool DeleteNewsLetter(long newsletterId)
        {
            SqlNewsLetterProvider sqlNewsLetterProvider = new SqlNewsLetterProvider();
            var isDelete = sqlNewsLetterProvider.DeleteNewsLetter(newsletterId);
            return isDelete;
        }

        #endregion

    }
}