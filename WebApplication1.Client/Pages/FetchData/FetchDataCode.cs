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

        [Parameter]
        protected WeatherForecast[] Forecasts { get; set; }

        protected string ComponentString = "Default Value";

        [Parameter]
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

        //protected void SortByDate()
        //{
        //    if (SortColumn != "Date" || SortDirection != "ASC")
        //    {
        //        SortColumn = "Date";
        //        SortDirection = "ASC";
        //        forecasts = forecasts.OrderBy(x => x.Date).ToArray();
        //    }
        //    else
        //    {
        //        SortDirection = "DESC";
        //        forecasts = forecasts.OrderByDescending(x => x.Date).ToArray();
        //    }
        //}

        //protected void SortByCelsius()
        //{
        //    if (SortColumn != "Celsius" || SortDirection != "ASC")
        //    {
        //        SortColumn = "Celsius";
        //        SortDirection = "ASC";
        //        forecasts = forecasts.OrderBy(x => x.TemperatureC).ToArray();
        //    }
        //    else
        //    {
        //        SortDirection = "DESC";
        //        forecasts = forecasts.OrderByDescending(x => x.TemperatureC).ToArray();
        //    }
        //}

        //protected void SortByFahrenheit()
        //{
        //    if (SortColumn != "Fahrenheit" || SortDirection != "ASC")
        //    {
        //        SortColumn = "Fahrenheit";
        //        SortDirection = "ASC";
        //        forecasts = forecasts.OrderBy(x => x.TemperatureF).ToArray();
        //    }
        //    else
        //    {
        //        SortDirection = "DESC";
        //        forecasts = forecasts.OrderByDescending(x => x.TemperatureF).ToArray();
        //    }
        //}

        //protected void SortBySummary()
        //{
        //    if (SortColumn != "Summary" || SortDirection != "ASC")
        //    {
        //        SortColumn = "Summary";
        //        SortDirection = "ASC";
        //        forecasts = forecasts.OrderBy(x => x.Summary).ToArray();
        //    }
        //    else
        //    {
        //        SortDirection = "DESC";
        //        forecasts = forecasts.OrderByDescending(x => x.Summary).ToArray();
        //    }
        //}
    }
}
