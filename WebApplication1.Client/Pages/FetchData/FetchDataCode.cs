using System.Threading.Tasks;
using WebApplication1.Shared;
using System.Net.Http;
using Microsoft.AspNetCore.Components;
using System;
using System.Linq;

namespace WebApplication1.Client.Pages.FetchData
{
    public class FetchDataCode : ComponentBase
    {
        [Inject]
        protected HttpClient Http { get; set; }

        protected WeatherForecast[] Forecasts { get; set; }

        protected string ComponentString = "Default Value";
        
        protected string CurrentSortColumn { get; set; }

        protected void ComponentMethod()
        {
            ComponentString = "Default Value";
        }

        protected override async Task OnInitAsync()
        {
            Console.WriteLine("OnInitAsync");
            Forecasts = await Http.GetJsonAsync<WeatherForecast[]>("api/SampleData/WeatherForecasts");
            // Default Sort
            CurrentSortColumn = "Date";
            Forecasts = Forecasts.OrderBy(x => x.Date).ToArray();
        }

        public void UpdateCollection(WeatherForecast[] updatedCollection)
        {
            Forecasts = updatedCollection;
            // the sorting changes won't render without this call!
            StateHasChanged();
        }
    }
}
