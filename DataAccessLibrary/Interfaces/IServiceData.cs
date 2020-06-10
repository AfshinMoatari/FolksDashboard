using DataAccessLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary.DataObjects
{
    public interface IServiceData
    {
        Task<List<ExpenseMonthModel>> GetExpenseMonth(string SelectedService);
        Task<List<ExpenseYearModel>> GetExpenseYear(int? SelectedYear = null);
        Task<List<ServiceModel>> GetService();
        Task<bool> InsertService(ServiceModel service);
    }
}