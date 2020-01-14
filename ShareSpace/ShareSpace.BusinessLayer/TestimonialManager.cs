using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareSpace.DataLayerSql.Testimonial;
using ShareSpace.Models.Testimonial;


namespace ShareSpace.BusinessLayer
{
    public class TestimonialManager
    {
        #region Get
        public static List<Testimonial> GetAllTestimonials()
        {
            SqlTestimonialProvider sqlTestimonialProvider = new SqlTestimonialProvider();
            var allTestimonials = sqlTestimonialProvider.GetAllTestimonials();
            return allTestimonials;


        }

        public static Testimonial GetTestimonialById(long testimonialId)
        {
            SqlTestimonialProvider sqlTestimonialProvider = new SqlTestimonialProvider();
            return sqlTestimonialProvider.GetTestimonialById(testimonialId);
        }



        #endregion


        #region Set
        public static long InsertTestimonial(Testimonial testimonial)
        {
            SqlTestimonialProvider sqlTestimonialProvider = new SqlTestimonialProvider();
            var id = sqlTestimonialProvider.InsertTestimonial(testimonial);
            return id;
        }

        public static bool UpdateTestimonial(Testimonial testimonial)
        {
            SqlTestimonialProvider sqlTestimonialProvider = new SqlTestimonialProvider();
            var isUpdate = sqlTestimonialProvider.UpdateTestimonial(testimonial);
            return isUpdate;
        }

        public static bool DeleteTestimonial(long testimonialId)
        {
            SqlTestimonialProvider sqlTestimonialProvider = new SqlTestimonialProvider();
            var isDelete = sqlTestimonialProvider.DeleteTestimonial(testimonialId);
            return isDelete;
        }

        #endregion

    }
}