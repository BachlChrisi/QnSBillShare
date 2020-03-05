namespace QnSBillShare.Logic.Controllers.Business.App
{
	sealed partial class BillExpensesController : ControllerObject, Contracts.Client.IControllerAccess<QnSBillShare.Contracts.Business.App.IBillExpenses>
	{
		static BillExpensesController()
		{
			ClassConstructing();
			ClassConstructed();
		}
		static partial void ClassConstructing();
		static partial void ClassConstructed();
		public BillExpensesController(DataContext.IContext context):base(context)
		{
			Constructing();
			Constructed();
		}
		partial void Constructing();
		partial void Constructed();
		public BillExpensesController(ControllerObject controller):base(controller)
		{
			Constructing();
			Constructed();
		}
	}
}
namespace QnSBillShare.Logic.Controllers.Business.Account
{
	sealed partial class LoginUserController : ControllerObject, Contracts.Client.IControllerAccess<QnSBillShare.Contracts.Business.Account.ILoginUser>
	{
		static LoginUserController()
		{
			ClassConstructing();
			ClassConstructed();
		}
		static partial void ClassConstructing();
		static partial void ClassConstructed();
		public LoginUserController(DataContext.IContext context):base(context)
		{
			Constructing();
			Constructed();
		}
		partial void Constructing();
		partial void Constructed();
		public LoginUserController(ControllerObject controller):base(controller)
		{
			Constructing();
			Constructed();
		}
	}
}
