using Silofy.Domain.Accounts.Entities;
using Silofy.Domain.Shared.Abstractions;
using Silofy.Domain.Shared.Extensions;

namespace Silofy.Domain.Silos.Entities;

public class Silo : EntityBase
{
    public string Name { get; protected set; }
    public int AccountId { get; protected set; }
    public decimal CurrentBalance { get; protected set; }
    public bool IsDefault { get; protected set; }
    
    #region Navigations

    public Account Account { get; protected set; }

    #endregion

    public Silo(
        string name,
        int accountId,
        decimal currentBalance,
        bool isDefault = false)
    {
        SetName(name);
        SetAccountId(accountId);
        CurrentBalance = currentBalance;
        SetIsDefault(isDefault);
    }
    
    public void SetName(string name)
    {
        name.ValidateRequiredProperty(nameof(Name), 1, 50);
        Name = name;
    }

    public void SetAccountId(int accountId)
    {
        accountId.ValidateRequiredProperty(nameof(AccountId));
        AccountId = accountId;
    }
    
    public void SetIsDefault(bool isDefault) => IsDefault = isDefault;
}