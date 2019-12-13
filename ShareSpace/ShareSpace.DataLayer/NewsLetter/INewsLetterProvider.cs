using System.Collections.Generic;
using ShareSpace.Models.NewsLetter;

namespace ShareSpace.DataLayer.NewsLetter
{
    public interface INewsLetterProvider
    {
        List<Models.NewsLetter.NewsLetter> GetAllNewsLetters();
        long InsertNewsLetter(Models.NewsLetter.NewsLetter newsletter);
        bool UpdateNewsLetter(Models.NewsLetter.NewsLetter newsletter);
        Models.NewsLetter.NewsLetter GetNewsLetterById(long newsletterId);
        bool DeleteNewsLetter(long newsletterId);
        
    }
}
