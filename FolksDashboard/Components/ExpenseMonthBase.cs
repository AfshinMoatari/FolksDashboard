﻿using DataAccessLibrary.DataObjects;
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
    public class ExpenseMonthBase : ComponentBase
    {
        [Inject] protected IJSRuntime jsRuntime { get; set; }
        [Inject] protected IExpenseService monthlyExpense { get; set; }

        protected List<ServiceModel> service;
        protected Dictionary<string, List<ExpenseMonthModel>> expensesM { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                expensesM = await monthlyExpense.GetMonthlyExpense();
                await jsRuntime.InvokeVoidAsync("GenerateBarChart", expensesM);
                StateHasChanged();
            }
        }
    }
}
