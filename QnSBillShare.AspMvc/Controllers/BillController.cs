using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QnSBillShare.AspMvc.Controllers
{
    public class BillController : Controller
    {
        private Models.App.Bill ConvertToModel(Contracts.Persistence.App.IBill entity)
        {
            var model = new Models.App.Bill();

            model.CopyProperties(entity);
            return model;
        }

        private Contracts.Client.IAdapterAccess<Contracts.Persistence.App.IBill> CreateController()
        {
            return Adapters.Factory.Create<Contracts.Persistence.App.IBill>();
        }
        // GET: Bill
        public async Task<ActionResult> Index()
        {
            using var ctrl = CreateController();

            var models = (await ctrl.GetAllAsync()).Select(e => ConvertToModel(e));
            return View(models);
        }

        // GET: Bill/Details/5
        public async Task<ActionResult> Details(int id)
        {
            using var ctrl = CreateController();

            var model = ConvertToModel(await ctrl.GetByIdAsync(id));

            return View("Detail", model);
        }

        // GET: Bill/Create
        public async Task<ActionResult> Create()
        {
            using var ctrl = CreateController();
            var model = ConvertToModel(await ctrl.CreateAsync());

            return View("Create",model);
        }

        // POST: Bill/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Models.App.Bill model)
        {
            try
            {
                // TODO: Add insert logic here

                using var ctrl = CreateController();

                await ctrl.InsertAsync(model);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Bill/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            using var ctrl = CreateController();
            var model = ConvertToModel(await ctrl.GetByIdAsync(id));

            return View("Edit",model);
        }

        // POST: Bill/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Models.App.Bill entity)
        {
            try
            {
                // TODO: Add update logic here
                using var ctrl = CreateController();
                await ctrl.UpdateAsync(entity);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Bill/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            using var ctrl = CreateController();
            var model = ConvertToModel(await ctrl.GetByIdAsync(id));
            return View("Delete",model);
        }

        // POST: Bill/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Models.App.Bill model)
        {
            try
            {
                // TODO: Add delete logic here
                using var ctrl = CreateController();

                await ctrl.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}