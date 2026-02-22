Console.WriteLine("Hello, World!");

decimal valor = 0.01m;

ValidateRequiredProperty(valor, nameof(valor));
return;

static void ValidateRequiredProperty(decimal value, string propertyName)
{
    if (value <= 0.00m)
        throw new ArgumentNullException(propertyName);
}