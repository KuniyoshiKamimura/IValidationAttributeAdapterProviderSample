using IValidationAttributeAdapterProviderSample.Properties;

namespace IValidationAttributeAdapterProviderSample.Models.Validation
{
    public static class MvcOptionsExtension
    {
        /// <summary>
        /// localize ModelBinding messages, e.g. when user enters string value instead of number...
        /// these messages can't be localized like data attributes
        /// </summary>
        /// <param name="mvc"></param>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IMvcBuilder AddModelBindingMessagesLocalizer(this IMvcBuilder mvc, IServiceCollection services)
        {
            return mvc.AddMvcOptions(options =>
            {
                // モデルバインディング失敗時のエラーメッセージをカスタマイズ
                // (サーバ側でモデルに値を格納する際に発生する可能性がある。)
                Func<string, string, string> f1 = (f, a1) => string.Format(f, a1);
                Func<string, string, string, string> f2 = (f, a1, a2) => string.Format(f, a1, a2);

                var mp = options.ModelBindingMessageProvider;
                mp.SetAttemptedValueIsInvalidAccessor((x, y) => f2(Resources.ModelBinding_AttemptedValueIsInvalid, x, y));
                mp.SetMissingBindRequiredValueAccessor((x) => f1(Resources.ModelBinding_MissingBindRequiredValue, x));
                mp.SetMissingKeyOrValueAccessor(() => Resources.ModelBinding_MissingKeyOrValue);
                mp.SetMissingRequestBodyRequiredValueAccessor(() => Resources.ModelBinding_MissingRequestBodyRequiredValue);
                mp.SetNonPropertyAttemptedValueIsInvalidAccessor((x) => f1(Resources.ModelBinding_NonPropertyAttemptedValueIsInvalid, x));
                mp.SetNonPropertyUnknownValueIsInvalidAccessor(() => Resources.ModelBinding_NonPropertyUnknownValueIsInvalid);
                mp.SetNonPropertyValueMustBeANumberAccessor(() => Resources.ModelBinding_NonPropertyValueMustBeANumber);
                mp.SetUnknownValueIsInvalidAccessor((x) => f1(Resources.ModelBinding_UnknownValueIsInvalid, x));
                mp.SetValueIsInvalidAccessor((x) => f1(Resources.ModelBinding_ValueIsInvalid, x));
                mp.SetValueMustBeANumberAccessor((x) => f1(Resources.ModelBinding_ValueMustBeANumber, x));
                mp.SetValueMustNotBeNullAccessor((x) => f1(Resources.ModelBinding_ValueMustNotBeNull, x));
            });
        }
    }
}
