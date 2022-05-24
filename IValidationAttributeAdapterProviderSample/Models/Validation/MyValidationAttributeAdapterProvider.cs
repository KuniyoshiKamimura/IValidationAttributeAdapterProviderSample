using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;

namespace IValidationAttributeAdapterProviderSample.Models.Validation
{
    public class MyValidationAttributeAdapterProvider : ValidationAttributeAdapterProvider, IValidationAttributeAdapterProvider
    {
        // This should be called 4 times with each of EmailAddressAttribute/MaxLengthAttribute/MinLengthAttribute/RequiredAttribute but be called only once with EmailAddressAttribute.
        // If you remove [EmailAddress] from SampleDTO, this will never be called.
        // So the problem is not because of [EmailAddress] or the order of validation attributes.
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
