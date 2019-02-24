using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Client.Components.ValidationError
{
    public class ValidationErrorComponent : ComponentBase
    {
        [Parameter]
        protected IValidatableObject Subject { get; set; }

        [Parameter]
        protected string Property { get; set; }

        protected ValidationContext Context => new ValidationContext(Subject) { MemberName = Property };

        protected IEnumerable<ValidationResult> Errors => Subject.Validate(Context);

        protected override void OnInit()
        {
            Console.WriteLine("ValidationError OnInit");
        }
    }
}
