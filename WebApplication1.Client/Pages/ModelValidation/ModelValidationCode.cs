using Microsoft.AspNetCore.Components;
using System;
using WebApplication1.Shared;

namespace WebApplication1.Client.Pages.ModelValidation
{
    public class ModelValidationCode : ComponentBase
    {
        protected MyModel Model { get; set; } = new MyModel();

        protected void Update(UIChangeEventArgs __e, Action UpdateAction)
        {
            Console.WriteLine("ModelValidation.Update entry");
            if (__e.Value == null)
            {
                Console.WriteLine("ModelValidation.Update null value");
            }
            else
            {
                string value = (string)__e.Value;
                Console.WriteLine("ModelValidation.Update " + __e.Value);
                try
                { 
                    UpdateAction();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
