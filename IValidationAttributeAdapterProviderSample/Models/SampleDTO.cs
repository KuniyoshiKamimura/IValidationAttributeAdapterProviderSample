using System.ComponentModel.DataAnnotations;

namespace IValidationAttributeAdapterProviderSample.Models
{
    public class SampleDTO
    {
        [EmailAddress]
        [Required]
        [MinLength(2)]
        [MaxLength(3)]
        public string? Test { get; set; }
    }
}
