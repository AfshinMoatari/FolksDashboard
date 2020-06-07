using DataAccessLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary.DataObjects
{
    public interface IServiceData
    {
        Task<List<ExpenseModel>> GetExpense(string SelectedService);
        Task<List<ServiceModel>> GetService();
        Task<bool> InsertService(ServiceModel service);
    }
}