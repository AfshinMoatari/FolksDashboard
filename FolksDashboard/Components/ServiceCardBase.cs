using DataAccessLibrary.DataObjects;
using DataAccessLibrary.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FolksDashboard.Components
{
    public class ServiceCardBase : ComponentBase
    {
        [Inject] protected IServiceData _sd { get; set; }
        /*[Inject] protected IServiceScopeFactory ScopeFactory { get; set; }*/

        protected List<ServiceModel> service;
        protected string imageUrl =
        "https://dummyimage.com/286x180/8EB1C7/FEFDFF.png&text=Service";

        protected override async Task OnInitializedAsync()
        {
            service = await _sd.GetService();
        }

        /*protected override async Task OnInitializedAsync()
        {
            using (var serviceScope = ScopeFactory.CreateScope())
            {
                var dataService = serviceScope.ServiceProvider.GetService<IServiceData>();
                service = await dataService.GetService();
            }
        }*/
    }
}
