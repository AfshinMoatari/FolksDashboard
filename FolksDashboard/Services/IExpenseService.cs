using DataAccessLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FolksDashboard.Services
{
    public interface IExpenseService
    {
        Task<Dictionary<string, List<ExpenseMonthModel>>> GetMonthlyExpense();
        Task<List<ExpenseYearModel>> GetYearlyExpense();
    }
}