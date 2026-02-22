using System.ComponentModel;

namespace Silofy.Domain.Transactions.Enums;

public enum TransactionTypeEnum
{
    [Description("Revenue")]
    Revenue = 0,
    [Description("Expense")]
    Expense = 1,
    [Description("Allocation between Silos")]
    Allocation = 2,
    [Description("Transfer between Accounts")]
    Transfer = 3
}