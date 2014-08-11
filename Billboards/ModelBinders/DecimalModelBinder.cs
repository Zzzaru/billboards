using System.Web.Mvc;

namespace Billboards.ModelBinders
{
    public class DecimalModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            var val = valueProviderResult.AttemptedValue.Replace(".", ",");
            decimal temp;
            if (decimal.TryParse(val, out temp))
            {
                return temp;
            }

            return base.BindModel(controllerContext, bindingContext);
        }
    }
}