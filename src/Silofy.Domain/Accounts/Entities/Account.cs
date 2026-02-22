using Silofy.Domain.Shared.Abstractions;
using Silofy.Domain.Shared.Extensions;
using Silofy.Domain.Users.Entities;

namespace Silofy.Domain.Accounts.Entities;

public class Account : EntityBase
{
    public string Name { get; protected set; }
    public int UserId { get; protected set; }
    public decimal Balance { get; protected set; }

    #region Navigations

    public User User { get; protected set; }

    #endregion

    public Account(
        string name,
        int userId,
        decimal balance)
    {
        SetName(name);
        UserId = userId;
        Balance = balance;
    }

    public void SetName(string name)
    {
        name.ValidateRequiredProperty(nameof(Name), 1, 20);
        Name = name;
    }
}