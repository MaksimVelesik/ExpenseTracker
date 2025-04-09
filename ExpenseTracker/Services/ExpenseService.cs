using ExpenseTracker.Models;

namespace ExpenseTracker.Services
{
    public class ExpenseService
    {
        private List<Expense> _expenses = new List<Expense>();

        public List<Expense> GetAllExpenses()
        {
            Console.WriteLine($"GetAllExpenses: Возвращено {_expenses.Count} расходов");
            return _expenses;
        }

        public List<Expense> GetExpensesByCategory(string category)
        {
            var filtered = _expenses.Where(e => e.Category == category).ToList();
            Console.WriteLine($"GetExpensesByCategory: Фильтр по '{category}', найдено {filtered.Count} расходов");
            return filtered;
        }

        public void AddExpense(Expense expense)
        {
            expense.Id = _expenses.Count + 1;
            _expenses.Add(expense);
            Console.WriteLine($"AddExpense: Добавлен расход: ID={expense.Id}, Amount={expense.Amount}, Category={expense.Category}, Date={expense.Date}"); // Отладочный вывод
        }
    }
}