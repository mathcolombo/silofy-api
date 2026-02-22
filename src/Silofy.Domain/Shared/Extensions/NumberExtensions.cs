namespace Silofy.Domain.Shared.Extensions;

public static class NumberExtensions
{
    public static void ValidateRequiredProperty(this int value, string propertyName)
    {
        if(value <= 0)
            throw new ArgumentNullException(propertyName);
    }
    
    public static void ValidateRequiredProperty(this decimal value, string propertyName)
    {
        if(value <= 0.00m)
            throw new ArgumentNullException(propertyName);
    }

    public static void ValidateNullableProperty(this int? value, string propertyName)
    {
        if(value is <= 0)
            throw new ArgumentNullException(propertyName);
    }
    
    public static void ValidateDifferentProperties(this int value, int otherValue, string propertyName, string otherPropertyName)
    {
        if(value == otherValue)
            throw new ArgumentException($"Propriedade {propertyName} não pode ser igual à {otherPropertyName}");
    }
}