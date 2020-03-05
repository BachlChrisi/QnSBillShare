namespace QnSBillShare.Logic.Entities.Modules.BillExpense
{
	using System;
	partial class Balance : QnSBillShare.Contracts.Modules.BillExpense.IBalance
	{
		static Balance()
		{
			ClassConstructing();
			ClassConstructed();
		}
		static partial void ClassConstructing();
		static partial void ClassConstructed();
		public Balance()
		{
			Constructing();
			Constructed();
		}
		partial void Constructing();
		partial void Constructed();
		public System.String From
		{
			get
			{
				OnFromReading();
				return _from;
			}
			set
			{
				bool handled = false;
				OnFromChanging(ref handled, ref _from);
				if (handled == false)
				{
					this._from = value;
				}
				OnFromChanged();
			}
		}
		private System.String _from;
		partial void OnFromReading();
		partial void OnFromChanging(ref bool handled, ref System.String _from);
		partial void OnFromChanged();
		public System.String To
		{
			get
			{
				OnToReading();
				return _to;
			}
			set
			{
				bool handled = false;
				OnToChanging(ref handled, ref _to);
				if (handled == false)
				{
					this._to = value;
				}
				OnToChanged();
			}
		}
		private System.String _to;
		partial void OnToReading();
		partial void OnToChanging(ref bool handled, ref System.String _to);
		partial void OnToChanged();
		public System.Double Amount
		{
			get
			{
				OnAmountReading();
				return _amount;
			}
			set
			{
				bool handled = false;
				OnAmountChanging(ref handled, ref _amount);
				if (handled == false)
				{
					this._amount = value;
				}
				OnAmountChanged();
			}
		}
		private System.Double _amount;
		partial void OnAmountReading();
		partial void OnAmountChanging(ref bool handled, ref System.Double _amount);
		partial void OnAmountChanged();
		public void CopyProperties(QnSBillShare.Contracts.Modules.BillExpense.IBalance other)
		{
			if (other == null)
			{
				throw new System.ArgumentNullException(nameof(other));
			}
			bool handled = false;
			BeforeCopyProperties(other, ref handled);
			if (handled == false)
			{
				From = other.From;
				To = other.To;
				Amount = other.Amount;
			}
			AfterCopyProperties(other);
		}
		partial void BeforeCopyProperties(QnSBillShare.Contracts.Modules.BillExpense.IBalance other, ref bool handled);
		partial void AfterCopyProperties(QnSBillShare.Contracts.Modules.BillExpense.IBalance other);
		public override bool Equals(object obj)
		{
			if (!(obj is QnSBillShare.Contracts.Modules.BillExpense.IBalance instance))
			{
				return false;
			}
			return base.Equals(instance) && Equals(instance);
		}
		protected bool Equals(QnSBillShare.Contracts.Modules.BillExpense.IBalance other)
		{
			if (other == null)
			{
				return false;
			}
			return IsEqualsWith(From, other.From) && IsEqualsWith(To, other.To) && Amount == other.Amount;
		}
		public override int GetHashCode()
		{
			return HashCode.Combine(From, To, Amount);
		}
	}
}
namespace QnSBillShare.Logic.Entities.Modules.BillExpense
{
	partial class Balance : ModuleObject
	{
	}
}
