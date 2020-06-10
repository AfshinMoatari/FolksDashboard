using DataAccessLibrary.DataObjects;
using DataAccessLibrary.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FolksDashboard.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IServiceData _ed;
        public ExpenseService(IServiceData ed)
        {
            _ed = ed;
        }

        protected List<ServiceModel> service;
        protected Dictionary<string, List<ExpenseMonthModel>> expenses = new Dictionary<string, List<ExpenseMonthModel>>();
      
        public async Task<Dictionary<string, List<ExpenseMonthModel>>> GetMonthlyExpense()
        {
            service = await _ed.GetService();
            foreach (var s in service)
            {
                expenses.Add(s.Name, await _ed.GetExpenseMonth(s.Name));
            }
            return expenses;
        }
        public async Task<List<ExpenseYearModel>> GetYearlyExpense()
        {
            return await _ed.GetExpenseYear();
        }
    }
}
