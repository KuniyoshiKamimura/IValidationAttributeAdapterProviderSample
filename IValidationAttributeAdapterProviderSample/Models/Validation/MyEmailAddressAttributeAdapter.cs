using IValidationAttributeAdapterProviderSample.Properties;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;

namespace IValidationAttributeAdapterProviderSample.Models.Validation
{
    public class MyEmailAddressAttributeAdapter : AttributeAdapterBase<EmailAddressAttribute>
    {
        public MyEmailAddressAttributeAdapter(EmailAddressAttribute attribute, IStringLocalizer? stringLocalizer)
           : base(attribute, stringLocalizer)
        {
            attribute.ErrorMessageResourceType = typeof(Resources);
            attribute.ErrorMessageResourceName = "ValidationMessageForEmailAddress";
            attribute.ErrorMessage = null;
        }

        public override void AddValidation(ClientModelValidationContext context)
        {
        }

        public override string GetErrorMessage(ModelValidationContextBase validationContext)
        {
            return GetErrorMessage(validationContext.ModelMetadata, validationContext.ModelMetadata.GetDisplayName());
        }
    }
}
