#pragma checksum "C:\Users\Anthony\Source\Repos\WebApplication1\WebApplication1.Client\Components\ValidationError\ValidationError.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7f4b382047c88593480391fcfa7db82ac0143051"
// <auto-generated/>
#pragma warning disable 1591
namespace WebApplication1.Client.Components.ValidationError
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using System.Net.Http;
    using Microsoft.AspNetCore.Components.Layouts;
    using Microsoft.AspNetCore.Components.Routing;
    using Microsoft.JSInterop;
    using WebApplication1.Client;
    using WebApplication1.Client.Shared;
    public class ValidationError : ValidationErrorComponent
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
#line 3 "C:\Users\Anthony\Source\Repos\WebApplication1\WebApplication1.Client\Components\ValidationError\ValidationError.cshtml"
 if (Errors != null)
{ 

#line default
#line hidden
            builder.AddContent(0, "    ");
            builder.OpenElement(1, "div");
            builder.AddAttribute(2, "class", "validationerror");
            builder.AddContent(3, "\r\n        ");
            builder.OpenElement(4, "ul");
            builder.AddContent(5, "\r\n");
#line 7 "C:\Users\Anthony\Source\Repos\WebApplication1\WebApplication1.Client\Components\ValidationError\ValidationError.cshtml"
             foreach (var error in Errors)
            {

#line default
#line hidden
            builder.AddContent(6, "                ");
            builder.OpenElement(7, "li");
            builder.AddContent(8, error);
            builder.CloseElement();
            builder.AddContent(9, "\r\n");
#line 10 "C:\Users\Anthony\Source\Repos\WebApplication1\WebApplication1.Client\Components\ValidationError\ValidationError.cshtml"
            }

#line default
#line hidden
            builder.AddContent(10, "        ");
            builder.CloseElement();
            builder.AddContent(11, "\r\n    ");
            builder.CloseElement();
            builder.AddContent(12, "\r\n");
#line 13 "C:\Users\Anthony\Source\Repos\WebApplication1\WebApplication1.Client\Components\ValidationError\ValidationError.cshtml"
}

#line default
#line hidden
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591