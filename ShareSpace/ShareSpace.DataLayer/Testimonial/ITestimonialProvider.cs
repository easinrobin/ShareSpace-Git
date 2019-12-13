using System.Collections.Generic;
using ShareSpace.Models.Testimonial;

namespace ShareSpace.DataLayer.Testimonial
{
    public interface ITestimonialProvider
    {
        List<Models.Testimonial.Testimonial> GetAllTestimonials();
        long InsertTestimonial(Models.Testimonial.Testimonial testimonial);
        bool UpdateTestimonial(Models.Testimonial.Testimonial testimonial);
        Models.Testimonial.Testimonial GetTestimonialById(long testimonialId);
        bool DeleteTestimonial(long testimonialId);
        
    }
}
