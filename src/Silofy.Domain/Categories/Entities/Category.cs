using Silofy.Domain.Shared.Abstractions;
using Silofy.Domain.Shared.Extensions;
using Silofy.Domain.Users.Entities;

namespace Silofy.Domain.Categories.Entities;

public class Category : EntityBase
{
    public string Name { get; protected set; }
    public bool IsDefault { get; protected set; }
    public int? UserId { get; protected set; }
    
    #region Navigations

    public User? User { get; protected set; }

    #endregion

    public Category(
        string name,
        bool isDefault = false,
        int? userId = null)
    {
        SetName(name);
        IsDefault = isDefault;
        UserId = userId;
    }
    
    public void SetName(string name)
    {
        name.ValidateRequiredProperty(nameof(Name), 1, 20);
        Name = name;
    }
}