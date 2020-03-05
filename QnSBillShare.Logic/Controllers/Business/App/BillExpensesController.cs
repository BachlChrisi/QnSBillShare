using CommonBase.Extensions;
using QnSBillShare.Adapters.Exceptions;
using QnSBillShare.Contracts.Business.App;
using QnSBillShare.Logic.Controllers.Persistence.App;
using QnSBillShare.Logic.Entities.Business.App;
using QnSBillShare.Logic.Entities.Persistence.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QnSBillShare.Logic.Controllers.Business.App
{
    partial class BillExpensesController
    {
        private BillController billController;
        private ExpenseController expenseController;

        partial void Constructed()
        {
            billController = new BillController(this);
            expenseController = new ExpenseController(this);
        }
        public int MaxPageSize => billController.MaxPageSize;

        public Task<int> CountAsync()
        {
            return billController.CountAsync();
        }

        public Task<IBillExpenses> CreateAsync()
        {
            return Task.Run<IBillExpenses>(() => new BillExpenses());
        }

        public async Task<IBillExpenses> GetByIdAsync(int id)
        {
            var result = default(BillExpenses);
            var travel = await billController.GetByIdAsync(id);

            if (travel != null)
            {
                result = new BillExpenses();
                result.Bill.CopyProperties(travel);
                foreach (var item in await expenseController.QueryAsync(e => e.BillId == id))
                {
                    result.ExpenseEntities.Add(item);
                }
            }
            else
            {
                throw new LogicException(ErrorType.InvalidId, "Entity can't find!");
            }
            return result;
        }
        public Task<IEnumerable<IBillExpenses>> GetAllAsync()
        {
            return Task.Run<IEnumerable<IBillExpenses>>(async () =>
            {
                List<IBillExpenses> result = new List<IBillExpenses>();

                foreach (var item in (await billController.GetAllAsync()).ToList())
                {
                    result.Add(await GetByIdAsync(item.Id));
                }
                return result;
            });
        }

        public Task<IEnumerable<IBillExpenses>> GetPageListAsync(int pageIndex, int pageSize)
        {
            return Task.Run<IEnumerable<IBillExpenses>>(async () =>
            {
                List<IBillExpenses> result = new List<IBillExpenses>();

                foreach (var item in (await billController.GetPageListAsync(pageIndex, pageSize)).ToList())
                {
                    result.Add(await GetByIdAsync(item.Id));
                }
                return result;
            });
        }

        public Task<IEnumerable<IBillExpenses>> QueryPageListAsync(string predicate, int pageIndex, int pageSize)
        {
            return Task.Run<IEnumerable<IBillExpenses>>(async () =>
            {
                List<IBillExpenses> result = new List<IBillExpenses>();

                foreach (var item in (await billController.QueryPageListAsync(predicate, pageIndex, pageSize)).ToList())
                {
                    result.Add(await GetByIdAsync(item.Id));
                }
                return result;
            });
        }

        public async Task<IBillExpenses> InsertAsync(IBillExpenses entity)
        {
            entity.CheckArgument(nameof(entity));
            entity.Bill.CheckArgument(nameof(entity.Bill));
            entity.Expenses.CheckArgument(nameof(entity.Expenses));

            var result = new BillExpenses();

            result.BillEntity.CopyProperties(entity.Bill);
            await billController.InsertAsync(result.BillEntity);
            foreach (var item in entity.Expenses)
            {
                var expense = new Expense();

                expense.Bill = result.BillEntity;
                expense.CopyProperties(item);
                await expenseController.InsertAsync(expense);
                result.ExpenseEntities.Add(expense);
            }
            return result;
        }

        public async Task<IBillExpenses> UpdateAsync(IBillExpenses entity)
        {
            entity.CheckArgument(nameof(entity));
            entity.Bill.CheckArgument(nameof(entity.Bill));
            entity.Expenses.CheckArgument(nameof(entity.Expenses));

            //Delete all costs that are no longer included in the list.
            foreach (var item in await expenseController.QueryAsync(e => e.BillId == entity.Bill.Id))
            {
                var tmpExpense = entity.Expenses.SingleOrDefault(i => i.Id == item.Id);

                if (tmpExpense == null)
                {
                    await expenseController.DeleteAsync(item.Id);
                }
            }

            var result = new BillExpenses();
            var travel = await billController.UpdateAsync(entity.Bill);

            result.BillEntity.CopyProperties(travel);
            foreach (var item in entity.Expenses)
            {
                if (item.Id == 0)
                {
                    item.BillId = entity.Bill.Id;
                    var insEntity = await expenseController.InsertAsync(item);

                    item.CopyProperties(insEntity);
                }
                else
                {
                    var updEntity = await expenseController.UpdateAsync(item);

                    item.CopyProperties(updEntity);
                }
            }
            return result;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);

            if (entity != null)
            {
                foreach (var item in entity.Expenses)
                {
                    await expenseController.DeleteAsync(item.Id);
                }
                await billController.DeleteAsync(entity.Bill.Id);
            }
            else
            {
                throw new LogicException(ErrorType.InvalidId, "Entity can't find!");
            }
        }

        public Task SaveChangesAsync()
        {
            return Context.SaveAsync();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            billController.Dispose();
            expenseController.Dispose();

            billController = null;
            expenseController = null;
        }
    }
}
