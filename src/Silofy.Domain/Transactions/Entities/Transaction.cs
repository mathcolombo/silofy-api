using Silofy.Domain.Accounts.Entities;
using Silofy.Domain.Categories.Entities;
using Silofy.Domain.Shared.Abstractions;
using Silofy.Domain.Shared.Extensions;
using Silofy.Domain.Transactions.Enums;

namespace Silofy.Domain.Transactions.Entities;

public class Transaction : EntityBase
{
    public string Description { get; protected set; }
    public decimal Amount { get; protected set; }
    public TransactionTypeEnum Type { get; protected set; }
    public int AccountId { get; protected set; }
    public int CategoryId { get; protected set; }
    public int? ToAccountId { get; protected set; }
    public int? ToCategoryId { get; protected set; }

    #region Navigations

    public Account Account { get; protected set; }
    public Category Category { get; protected set; }
    public Account? ToAccount { get; protected set; }
    public Category? ToCategory { get; protected set; }

    #endregion
    
    public Transaction(
        string description,
        decimal amount,
        TransactionTypeEnum typeEnum,
        int accountId,
        int categoryId,
        int? toAccountId = null,
        int? toCategoryId = null)
    {
        SetDescription(description);
        SetAmount(amount);
        SetType(typeEnum);
        SetAccountId(accountId);
        SetCategoryId(categoryId);
        SetToAccountId(toAccountId);
        SetToCategoryId(toCategoryId);
    }

    public void SetDescription(string description)
    {
        description.ValidateRequiredProperty(nameof(Description), 7, 100);
        Description = description;
    }

    public void SetAmount(decimal amount)
    {
        amount.ValidateRequiredProperty(nameof(Amount));
        Amount = amount;
    }
    
    public void SetType(TransactionTypeEnum type) => Type = type;
    
    public void SetAccountId(int accountId)
    {
        accountId.ValidateRequiredProperty(nameof(AccountId));
        
        if(ToAccountId.HasValue)
            accountId.ValidateDifferentProperties(ToAccountId.Value, nameof(AccountId), nameof(ToAccountId));
        
        AccountId = accountId;
    }
    
    public void SetCategoryId(int categoryId)
    {
        categoryId.ValidateRequiredProperty(nameof(CategoryId));
        
        if(ToCategoryId.HasValue)
            categoryId.ValidateDifferentProperties(ToCategoryId.Value, nameof(CategoryId), nameof(ToCategoryId));
        
        CategoryId = categoryId;
    }
    
    public void SetToAccountId(int? toAccountId)
    {
        toAccountId.ValidateNullableProperty(nameof(ToAccountId));
        toAccountId?.ValidateDifferentProperties(AccountId, nameof(ToAccountId), nameof(AccountId));
        
        ToAccountId = toAccountId;
    }
    
    public void SetToCategoryId(int? toCategoryId)
    {
        toCategoryId.ValidateNullableProperty(nameof(ToCategoryId));
        toCategoryId?.ValidateDifferentProperties(CategoryId, nameof(ToCategoryId), nameof(CategoryId));

        ToCategoryId = toCategoryId;
    }
}