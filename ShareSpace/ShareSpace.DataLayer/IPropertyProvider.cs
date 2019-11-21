using System.Collections.Generic;

namespace ShareSpace.DataLayer.Property
{
    public interface IPropertyProvider
    {
        List<Models.Property> GetAllPropertys();
    }
}