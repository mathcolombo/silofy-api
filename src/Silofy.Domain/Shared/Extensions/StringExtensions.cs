namespace Silofy.Domain.Shared.Extensions;

public static  class StringExtensions
{
    public static void ValidateRequiredProperty(this string value, string propertyName, int? minLength = null, int? maxLength = null)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentNullException(propertyName);

        if (value.Length < minLength || value.Length > maxLength)
            throw new ArgumentOutOfRangeException(propertyName);
    }
}