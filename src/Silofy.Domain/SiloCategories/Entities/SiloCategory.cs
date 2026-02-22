using Silofy.Domain.Accounts.Entities;
using Silofy.Domain.Categories.Entities;
using Silofy.Domain.Shared.Abstractions;
using Silofy.Domain.Shared.Extensions;
using Silofy.Domain.Silos.Entities;

namespace Silofy.Domain.SiloCategories.Entities;

public class SiloCategory : EntityBase
{
    public int SiloId { get; protected set; }
    public int CategoryId { get; protected set; }
    public int AccountId { get;  protected set; }

    #region Navigations

    public Silo Silo { get; protected set; }
    public Category Category { get; protected set; }
    public Account Account { get; protected set; }

    #endregion

    public SiloCategory(
        int siloId,
        int categoryId,
        int accountId)
    {
        SetSiloId(siloId);
        SetCategoryId(categoryId);
        SetAccountId(accountId);
    }

    public void SetSiloId(int siloId)
    {
        siloId.ValidateRequiredProperty(nameof(SiloId));
        SiloId = siloId;
    }
    
    public void SetCategoryId(int categoryId)
    {
        categoryId.ValidateRequiredProperty(nameof(CategoryId));
        CategoryId = categoryId;
    }
    
    public void SetAccountId(int accountId)
    {
        accountId.ValidateRequiredProperty(nameof(AccountId));
        AccountId = accountId;
    }
}