using IValidationAttributeAdapterProviderSample.Properties;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace IValidationAttributeAdapterProviderSample.Models.Validation
{
    public class MyValidationMetadataProvider : IValidationMetadataProvider
    {
        private const string RESOURCE_KEY_PREFIX = "ValidationMessageFor";

        public MyValidationMetadataProvider()
        {
        }

        public void CreateValidationMetadata(ValidationMetadataProviderContext context)
        {
            var metaData = context.ValidationMetadata.ValidatorMetadata;

            // int/Decimal/DateTime等の値型の場合、
            // 暗黙的に必須属性が追加されるので、そのメッセージも置き換え
            if (context.Key.ModelType.GetTypeInfo().IsValueType &&
                metaData.Where(m => m.GetType() == typeof(RequiredAttribute)).Count() == 0)
            {
                metaData.Add(new RequiredAttribute());
            }

            // 対象プロパティに紐づく全ての属性に対して処理
            foreach (var obj in metaData)
            {
                if (!(obj is ValidationAttribute attr))
                {
                    continue;
                }

                // 対応するメッセージが未定義の場合は既定の動作に任せる
                string name = RESOURCE_KEY_PREFIX + attr.GetType().Name;

                string? newMessage = Resources.ResourceManager.GetString(name);
                if (string.IsNullOrEmpty(newMessage))
                {
                    continue;
                }

                // 対応するメッセージが定義されている場合、それで上書き
                attr.ErrorMessageResourceType = typeof(Resources);
                attr.ErrorMessageResourceName = name;
                attr.ErrorMessage = null;
            }
        }
    }
}
