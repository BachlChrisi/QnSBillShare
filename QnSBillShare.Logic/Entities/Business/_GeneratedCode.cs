namespace QnSBillShare.Logic.Entities.Business.App
{
	using System;
	partial class BillExpenses : QnSBillShare.Contracts.Business.App.IBillExpenses
	{
		static BillExpenses()
		{
			ClassConstructing();
			ClassConstructed();
		}
		static partial void ClassConstructing();
		static partial void ClassConstructed();
		public BillExpenses()
		{
			Constructing();
			Constructed();
		}
		partial void Constructing();
		partial void Constructed();
		public QnSBillShare.Contracts.Persistence.App.IBill Bill
		{
			get
			{
				OnBillReading();
				return _bill;
			}
			set
			{
				bool handled = false;
				OnBillChanging(ref handled, ref _bill);
				if (handled == false)
				{
					this._bill = value;
				}
				OnBillChanged();
			}
		}
		private QnSBillShare.Contracts.Persistence.App.IBill _bill;
		partial void OnBillReading();
		partial void OnBillChanging(ref bool handled, ref QnSBillShare.Contracts.Persistence.App.IBill _bill);
		partial void OnBillChanged();
		public System.Collections.Generic.IEnumerable<QnSBillShare.Contracts.Persistence.App.IExpense> Expenses
		{
			get
			{
				OnExpensesReading();
				return _expenses;
			}
			set
			{
				bool handled = false;
				OnExpensesChanging(ref handled, ref _expenses);
				if (handled == false)
				{
					this._expenses = value;
				}
				OnExpensesChanged();
			}
		}
		private System.Collections.Generic.IEnumerable<QnSBillShare.Contracts.Persistence.App.IExpense> _expenses;
		partial void OnExpensesReading();
		partial void OnExpensesChanging(ref bool handled, ref System.Collections.Generic.IEnumerable<QnSBillShare.Contracts.Persistence.App.IExpense> _expenses);
		partial void OnExpensesChanged();
		public System.Double TotalExpense
		{
			get
			{
				OnTotalExpenseReading();
				return _totalExpense;
			}
			set
			{
				bool handled = false;
				OnTotalExpenseChanging(ref handled, ref _totalExpense);
				if (handled == false)
				{
					this._totalExpense = value;
				}
				OnTotalExpenseChanged();
			}
		}
		private System.Double _totalExpense;
		partial void OnTotalExpenseReading();
		partial void OnTotalExpenseChanging(ref bool handled, ref System.Double _totalExpense);
		partial void OnTotalExpenseChanged();
		public System.Double FriendPortion
		{
			get
			{
				OnFriendPortionReading();
				return _friendPortion;
			}
			set
			{
				bool handled = false;
				OnFriendPortionChanging(ref handled, ref _friendPortion);
				if (handled == false)
				{
					this._friendPortion = value;
				}
				OnFriendPortionChanged();
			}
		}
		private System.Double _friendPortion;
		partial void OnFriendPortionReading();
		partial void OnFriendPortionChanging(ref bool handled, ref System.Double _friendPortion);
		partial void OnFriendPortionChanged();
		public System.Int32 NumberOfFriends
		{
			get
			{
				OnNumberOfFriendsReading();
				return _numberOfFriends;
			}
			set
			{
				bool handled = false;
				OnNumberOfFriendsChanging(ref handled, ref _numberOfFriends);
				if (handled == false)
				{
					this._numberOfFriends = value;
				}
				OnNumberOfFriendsChanged();
			}
		}
		private System.Int32 _numberOfFriends;
		partial void OnNumberOfFriendsReading();
		partial void OnNumberOfFriendsChanging(ref bool handled, ref System.Int32 _numberOfFriends);
		partial void OnNumberOfFriendsChanged();
		public System.String[] Friends
		{
			get
			{
				OnFriendsReading();
				return _friends;
			}
			set
			{
				bool handled = false;
				OnFriendsChanging(ref handled, ref _friends);
				if (handled == false)
				{
					this._friends = value;
				}
				OnFriendsChanged();
			}
		}
		private System.String[] _friends;
		partial void OnFriendsReading();
		partial void OnFriendsChanging(ref bool handled, ref System.String[] _friends);
		partial void OnFriendsChanged();
		public System.Double[] FriendAmounts
		{
			get
			{
				OnFriendAmountsReading();
				return _friendAmounts;
			}
			set
			{
				bool handled = false;
				OnFriendAmountsChanging(ref handled, ref _friendAmounts);
				if (handled == false)
				{
					this._friendAmounts = value;
				}
				OnFriendAmountsChanged();
			}
		}
		private System.Double[] _friendAmounts;
		partial void OnFriendAmountsReading();
		partial void OnFriendAmountsChanging(ref bool handled, ref System.Double[] _friendAmounts);
		partial void OnFriendAmountsChanged();
		public System.Collections.Generic.IEnumerable<QnSBillShare.Contracts.Modules.BillExpense.IBalance> Balances
		{
			get
			{
				OnBalancesReading();
				return _balances;
			}
			set
			{
				bool handled = false;
				OnBalancesChanging(ref handled, ref _balances);
				if (handled == false)
				{
					this._balances = value;
				}
				OnBalancesChanged();
			}
		}
		private System.Collections.Generic.IEnumerable<QnSBillShare.Contracts.Modules.BillExpense.IBalance> _balances;
		partial void OnBalancesReading();
		partial void OnBalancesChanging(ref bool handled, ref System.Collections.Generic.IEnumerable<QnSBillShare.Contracts.Modules.BillExpense.IBalance> _balances);
		partial void OnBalancesChanged();
		public void CopyProperties(QnSBillShare.Contracts.Business.App.IBillExpenses other)
		{
			if (other == null)
			{
				throw new System.ArgumentNullException(nameof(other));
			}
			bool handled = false;
			BeforeCopyProperties(other, ref handled);
			if (handled == false)
			{
				Id = other.Id;
				Timestamp = other.Timestamp;
				Bill = other.Bill;
				Expenses = other.Expenses;
				TotalExpense = other.TotalExpense;
				FriendPortion = other.FriendPortion;
				NumberOfFriends = other.NumberOfFriends;
				Friends = other.Friends;
				FriendAmounts = other.FriendAmounts;
				Balances = other.Balances;
			}
			AfterCopyProperties(other);
		}
		partial void BeforeCopyProperties(QnSBillShare.Contracts.Business.App.IBillExpenses other, ref bool handled);
		partial void AfterCopyProperties(QnSBillShare.Contracts.Business.App.IBillExpenses other);
		public override bool Equals(object obj)
		{
			if (!(obj is QnSBillShare.Contracts.Business.App.IBillExpenses instance))
			{
				return false;
			}
			return base.Equals(instance) && Equals(instance);
		}
		protected bool Equals(QnSBillShare.Contracts.Business.App.IBillExpenses other)
		{
			if (other == null)
			{
				return false;
			}
			return Id == other.Id && IsEqualsWith(Timestamp, other.Timestamp) && IsEqualsWith(Bill, other.Bill) && IsEqualsWith(Expenses, other.Expenses) && TotalExpense == other.TotalExpense && FriendPortion == other.FriendPortion && NumberOfFriends == other.NumberOfFriends && IsEqualsWith(Friends, other.Friends) && IsEqualsWith(FriendAmounts, other.FriendAmounts) && IsEqualsWith(Balances, other.Balances);
		}
		public override int GetHashCode()
		{
			return HashCode.Combine(Id, Timestamp, Bill, Expenses, TotalExpense, FriendPortion, HashCode.Combine(NumberOfFriends, Friends, FriendAmounts, Balances));
		}
	}
}
namespace QnSBillShare.Logic.Entities.Business.App
{
	partial class BillExpenses : IdentityObject
	{
	}
}
namespace QnSBillShare.Logic.Entities.Business.Account
{
	using System;
	partial class LoginUser : QnSBillShare.Contracts.Business.Account.ILoginUser
	{
		static LoginUser()
		{
			ClassConstructing();
			ClassConstructed();
		}
		static partial void ClassConstructing();
		static partial void ClassConstructed();
		public LoginUser()
		{
			Constructing();
			Constructed();
		}
		partial void Constructing();
		partial void Constructed();
		public QnSBillShare.Contracts.Persistence.Account.IUser User
		{
			get
			{
				OnUserReading();
				return _user;
			}
			set
			{
				bool handled = false;
				OnUserChanging(ref handled, ref _user);
				if (handled == false)
				{
					this._user = value;
				}
				OnUserChanged();
			}
		}
		private QnSBillShare.Contracts.Persistence.Account.IUser _user;
		partial void OnUserReading();
		partial void OnUserChanging(ref bool handled, ref QnSBillShare.Contracts.Persistence.Account.IUser _user);
		partial void OnUserChanged();
		public System.Collections.Generic.IEnumerable<QnSBillShare.Contracts.Persistence.Account.IRole> Roles
		{
			get
			{
				OnRolesReading();
				return _roles;
			}
			set
			{
				bool handled = false;
				OnRolesChanging(ref handled, ref _roles);
				if (handled == false)
				{
					this._roles = value;
				}
				OnRolesChanged();
			}
		}
		private System.Collections.Generic.IEnumerable<QnSBillShare.Contracts.Persistence.Account.IRole> _roles;
		partial void OnRolesReading();
		partial void OnRolesChanging(ref bool handled, ref System.Collections.Generic.IEnumerable<QnSBillShare.Contracts.Persistence.Account.IRole> _roles);
		partial void OnRolesChanged();
		public void CopyProperties(QnSBillShare.Contracts.Business.Account.ILoginUser other)
		{
			if (other == null)
			{
				throw new System.ArgumentNullException(nameof(other));
			}
			bool handled = false;
			BeforeCopyProperties(other, ref handled);
			if (handled == false)
			{
				Id = other.Id;
				Timestamp = other.Timestamp;
				User = other.User;
				Roles = other.Roles;
			}
			AfterCopyProperties(other);
		}
		partial void BeforeCopyProperties(QnSBillShare.Contracts.Business.Account.ILoginUser other, ref bool handled);
		partial void AfterCopyProperties(QnSBillShare.Contracts.Business.Account.ILoginUser other);
		public override bool Equals(object obj)
		{
			if (!(obj is QnSBillShare.Contracts.Business.Account.ILoginUser instance))
			{
				return false;
			}
			return base.Equals(instance) && Equals(instance);
		}
		protected bool Equals(QnSBillShare.Contracts.Business.Account.ILoginUser other)
		{
			if (other == null)
			{
				return false;
			}
			return Id == other.Id && IsEqualsWith(Timestamp, other.Timestamp) && IsEqualsWith(User, other.User) && IsEqualsWith(Roles, other.Roles);
		}
		public override int GetHashCode()
		{
			return HashCode.Combine(Id, Timestamp, User, Roles);
		}
	}
}
namespace QnSBillShare.Logic.Entities.Business.Account
{
	partial class LoginUser : IdentityObject
	{
	}
}
