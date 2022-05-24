using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;

namespace IValidationAttributeAdapterProviderSample.Models.Validation
{
    public class MyValidationAttributeAdapterProvider : ValidationAttributeAdapterProvider, IValidationAttributeAdapterProvider
    {
        IAttributeAdapter? IValidationAttributeAdapterProvider.GetAttributeAdapter(
            ValidationAttribute attribute,
            IStringLocalizer? stringLocalizer)
        {
            return attribute switch
            {
                EmailAddressAttribute => new MyEmailAddressAttributeAdapter((EmailAddressAttribute)attribute, stringLocalizer),
                MaxLengthAttribute => new MyMaxLengthAttributeAdapter((MaxLengthAttribute)attribute, stringLocalizer),
                MinLengthAttribute => new MyMinLengthAttributeAdapter((MinLengthAttribute)attribute, stringLocalizer),
                RequiredAttribute => new MyRequiredAttributeAdapter((RequiredAttribute)attribute, stringLocalizer),
                _ => base.GetAttributeAdapter(attribute, stringLocalizer),
            };
        }
    }
}
