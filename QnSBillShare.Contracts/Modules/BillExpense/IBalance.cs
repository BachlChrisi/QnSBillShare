using System;
using System.Collections.Generic;
using System.Text;

namespace QnSBillShare.Contracts.Modules.BillExpense
{
    public interface IBalance
    {
        string From { get; }
        string To { get; }
        double Amount { get; }
    }
}
