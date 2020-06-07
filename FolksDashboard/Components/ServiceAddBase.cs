using DataAccessLibrary.DataObjects;
using DataAccessLibrary.Models;
using FolksDashboard.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FolksDashboard.Components
{
    public class ServiceAddBase : ComponentBase
    {
        [Inject] protected IServiceData _sd { get; set; }
        [Parameter]
        public EventCallback<bool> OnInsert { get; set; }
        protected DisplayServiceModel newService = new DisplayServiceModel();
        protected bool Inserted;
       

        protected async Task InsertService()
        {
            ServiceModel S = new ServiceModel
            {
                Name = newService.Name,
                Fee = newService.Fee,
                Description = newService.Description
            };
            Inserted = await _sd.InsertService(S);
            
            if (Inserted)
            {
                newService = new DisplayServiceModel();
                await OnInsert.InvokeAsync(true);
            }
        }
    }
}
