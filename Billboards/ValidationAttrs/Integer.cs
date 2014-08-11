using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Billboards.ValidationAttrs
{
    public class Integer : ValidationAttribute, IClientValidatable
    {
        public override bool IsValid(object value)
        {
            return true;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            return new List<ModelClientValidationRule>
            {
                new ModelClientValidationRule
                {
                    ValidationType = "digits",
                    ErrorMessage = ErrorMessage
                }
            };
        }
    }
    
}