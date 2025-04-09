using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Models
{
    public class Expense
    {
        public int Id { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "Сумма должна быть больше 0")]
        public decimal Amount { get; set; }
        [Required(ErrorMessage = "Категория обязательна")]
        public required string Category { get; set; }
        [Required(ErrorMessage = "Дата обязательна")]
        public DateTime Date { get; set; }
    }
}