using System;
using System.Data.Entity.Spatial;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace Billboards.ModelBinders
{
    public class DbGeographyModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            try
            {
                var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName).AttemptedValue;
                string[] strParts = valueProviderResult.Split(';');
                DbGeography result = DbGeography.FromText(strParts[1], Convert.ToInt32(Regex.Replace(strParts[0], @"[^\d]+", "")));
                return result;
            }
            catch
            {
                return null;
            }
        }
    }
}