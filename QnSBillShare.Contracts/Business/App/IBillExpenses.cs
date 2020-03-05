using QnSBillShare.Contracts.Modules.BillExpense;
using QnSBillShare.Contracts.Persistence.App;
using System;
using System.Collections.Generic;
using System.Text;

namespace QnSBillShare.Contracts.Business.App
{
    public partial interface IBillExpenses : IIdentifiable, ICopyable<IBillExpenses>
    {
        IBill Bill { get; }
        IEnumerable<IExpense> Expenses { get; }
        double TotalExpense { get; }
        double FriendPortion { get; }
        int NumberOfFriends { get; }
        string[] Friends { get; }
        double[] FriendAmounts { get; }
        IEnumerable<IBalance> Balances { get; }
        IExpense CreateExpense();
        void Add(IExpense expense);
        void Remove(IExpense expense);
    }
}
