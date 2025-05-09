using FinanceApp.Models;

namespace FinanceApp.Data.Services
{
    public interface IExpensesServies
    {
        Task<IEnumerable<Expense>> GetAll();
        Task Add(Expense expense);
        IQueryable GetChartData();
    }
}
