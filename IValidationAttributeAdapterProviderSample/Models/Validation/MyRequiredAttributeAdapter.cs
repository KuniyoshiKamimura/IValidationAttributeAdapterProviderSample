using IValidationAttributeAdapterProviderSample.Properties;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;

namespace IValidationAttributeAdapterProviderSample.Models.Validation
{
    public class MyRequiredAttributeAdapter : AttributeAdapterBase<RequiredAttribute>
    {
        // This should be called but never be called at all.
        public MyRequiredAttributeAdapter(RequiredAttribute attribute, IStringLocalizer? stringLocalizer)
           : base(attribute, stringLocalizer)
        {
            attribute.ErrorMessageResourceType = typeof(Resources);
            attribute.ErrorMessageResourceName = "ValidationMessageForRequired";
        }

        public override void AddValidation(ClientModelValidationContext context)
        {
        }

        // This should be called but never be called at all.
        // So I can't see the message "{0} is required.".
        // Instead, the default message "The Test field is required." is shown.
        public override string GetErrorMessage(ModelValidationContextBase validationContext)
        {
            return GetErrorMessage(validationContext.ModelMetadata, validationContext.ModelMetadata.GetDisplayName());
        }
    }
}
