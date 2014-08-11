using System;
using System.Data.Entity.Spatial;
using System.Web.Mvc;

namespace Billboards.ModelBinders
{
    public class EFModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(Type modelType)
        {
            if (modelType == typeof(DbGeography))
            {
                return new DbGeographyModelBinder();
            }
            if (modelType == typeof(decimal))
            {
                return new DecimalModelBinder();
            }
            return null;
        }
    }
}