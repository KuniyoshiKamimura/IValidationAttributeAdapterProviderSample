using IValidationAttributeAdapterProviderSample.Properties;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;

namespace IValidationAttributeAdapterProviderSample.Models.Validation
{
    public class MyMinLengthAttributeAdapter : AttributeAdapterBase<MinLengthAttribute>
    {
        // This should be called but never be called at all.
        public MyMinLengthAttributeAdapter(MinLengthAttribute attribute, IStringLocalizer? stringLocalizer)
          : base(attribute, stringLocalizer)
        {
            attribute.ErrorMessageResourceType = typeof(Resources);
            attribute.ErrorMessageResourceName = "ValidationMessageForMinLength";
        }

        public override void AddValidation(ClientModelValidationContext context)
        {
        }

        // This should be called but never be called at all.
        // So I can't see the message "The length of {0} must be greater than or equal to {1}.".
        // Instead, the default message "The field Test must be a string or array type with a minimum length of '2'." is shown.
        public override string GetErrorMessage(ModelValidationContextBase validationContext)
        {
            return GetErrorMessage(validationContext.ModelMetadata, validationContext.ModelMetadata.GetDisplayName());
        }
    }
}