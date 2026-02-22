using Silofy.Domain.Shared.Abstractions;
using Silofy.Domain.Shared.Extensions;
using Silofy.Domain.Shared.ValueObjects;

namespace Silofy.Domain.Users.Entities;

public class User : EntityBase
{
    public string Name { get; protected set; }
    public Email Email { get; protected set; }
    public string Password { get; protected set; }

    public User(
        string name,
        Email email,
        string password)
    {
        SetName(name);
        SetEmail(email);
        SetPassword(password);
    }
    
    public void SetName(string name)
    {
        name.ValidateRequiredProperty(nameof(Name), 1, 100);
        Name = name;
    }

    public void SetEmail(Email email) => Email = email;

    public void SetPassword(string password)
    {
        password.ValidateRequiredProperty(nameof(Password), 8, 20);
        Password = password;
    }
}