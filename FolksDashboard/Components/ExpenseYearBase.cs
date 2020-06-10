using DataAccessLibrary.DataObjects;
using DataAccessLibrary.Models;
using FolksDashboard.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FolksDashboard.Components
{
    public class ExpenseYearBase : ComponentBase
    {
        [Inject] protected IExpenseService yearlyExpense { get; set; }
        [Inject] protected IJSRuntime jsRuntime { get; set; }
        protected List<ExpenseYearModel> expensesY { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                expensesY = await yearlyExpense.GetYearlyExpense();
                await jsRuntime.InvokeVoidAsync("GenerateDoughnutChart", expensesY);
                StateHasChanged();
            }
        }
    }
}
