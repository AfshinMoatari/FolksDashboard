using DataAccessLibrary.DataObjects;
using DataAccessLibrary.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FolksDashboard.Components
{
    public class ExpenseMonthBase : ComponentBase
    {
        protected List<ServiceModel> service;
        protected Dictionary<string, List<ExpenseModel>> expenses = new Dictionary<string, List<ExpenseModel>>();
        [Inject] protected IServiceData _sd { get; set; }
        [Inject] protected IJSRuntime jsRuntime { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                service = await _sd.GetService();
                foreach (var s in service)
                {
                    expenses.Add(s.Name, await _sd.GetExpense(s.Name));
                }
                await jsRuntime.InvokeVoidAsync("GenerateBarChart", expenses);
                StateHasChanged();
            }
        }
    }
}
