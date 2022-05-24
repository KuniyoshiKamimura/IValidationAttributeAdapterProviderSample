using IValidationAttributeAdapterProviderSample.Properties;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;

namespace IValidationAttributeAdapterProviderSample.Models.Validation
{
    public class MyMaxLengthAttributeAdapter : AttributeAdapterBase<MaxLengthAttribute>
    {
        // This should be called but never be called at all.
        public MyMaxLengthAttributeAdapter(MaxLengthAttribute attribute, IStringLocalizer? stringLocalizer)
           : base(attribute, stringLocalizer)
        {
            attribute.ErrorMessageResourceType = typeof(Resources);
            attribute.ErrorMessageResourceName = "ValidationMessageForMaxLength";
            attribute.ErrorMessage = null;
        }

        public override void AddValidation(ClientModelValidationContext context)
        {
        }

        // This should be called but never be called at all.
        // So I can't see the message "The length of {0} must be less than or equal to {1}.".
        // Instead, the default message "The field Test must be a string or array type with a maximum length of '3'." is shown.
        public override string GetErrorMessage(ModelValidationContextBase validationContext)
        {
            return GetErrorMessage(validationContext.ModelMetadata, validationContext.ModelMetadata.GetDisplayName());
        }
    }
}
