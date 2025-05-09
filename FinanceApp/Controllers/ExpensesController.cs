using FinanceApp.Data;
using FinanceApp.Data.Services;
using FinanceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly IExpensesServies _service;
        public ExpensesController(IExpensesServies service) 
        {
            _service = service;
        }
        //[Route("/")]
        public async Task<ActionResult> Index()
        {
            var expenses = await _service.GetAll();
            return View(expenses);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Expense expense)
        {
            if (ModelState.IsValid)
            {
                await _service.Add(expense);
                return RedirectToAction("Index");
            }
            return View(expense);
        }
        public IActionResult GetChart()
        {
            var data = _service.GetChartData();
            return Json(data);
        }
    }

}
