using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.Models;
using ExpenseTracker.Services;

namespace ExpenseTracker.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly ExpenseService _expenseService;

        public ExpensesController(ExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        public IActionResult Index()
        {
            var expenses = _expenseService.GetAllExpenses();
            Console.WriteLine($"Index: Передано в представление {expenses.Count} расходов"); 
            return View(expenses);
        }

        [Route("Expenses/Filter/{category}")]
        public IActionResult Filter(string category)
        {
            var expenses = _expenseService.GetExpensesByCategory(category);
            Console.WriteLine($"Filter: Передано в представление {expenses.Count} расходов для категории '{category}'"); 
            return View("Index", expenses);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Expense expense)
        {
            Console.WriteLine("Add POST: Сырые данные формы:");
            foreach (var key in Request.Form.Keys)
            {
                Console.WriteLine($"{key}: {Request.Form[key]}");
            }

            Console.WriteLine($"Add POST: Привязанная модель: Amount={expense.Amount}, Category={expense.Category}, Date={expense.Date}");
            if (ModelState.IsValid)
            {
                _expenseService.AddExpense(expense);
                Console.WriteLine("Add POST: Расход успешно добавлен, редирект на Index");
                return RedirectToAction("Index");
            }
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine($"Add POST: Ошибка валидации: {error.ErrorMessage}");
            }
            return View(expense);
        }
    }
}