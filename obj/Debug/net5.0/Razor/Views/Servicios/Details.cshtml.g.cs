#pragma checksum "D:\USMP-2022-1\SOFTWARE-2\Nueva carpeta\PLANNING_POKER\esta-si-funciona\Views\Servicios\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "74d751254cb445efacbe4cfdba6fb94671203696"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Servicios_Details), @"mvc.1.0.view", @"/Views/Servicios/Details.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\USMP-2022-1\SOFTWARE-2\Nueva carpeta\PLANNING_POKER\esta-si-funciona\Views\_ViewImports.cshtml"
using hostal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\USMP-2022-1\SOFTWARE-2\Nueva carpeta\PLANNING_POKER\esta-si-funciona\Views\_ViewImports.cshtml"
using hostal.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74d751254cb445efacbe4cfdba6fb94671203696", @"/Views/Servicios/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ff3a16656f7154a59dda0c221bde40a38494bc10", @"/Views/_ViewImports.cshtml")]
    public class Views_Servicios_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<hostal.Models.Servicios>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Acompa??ante", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\USMP-2022-1\SOFTWARE-2\Nueva carpeta\PLANNING_POKER\esta-si-funciona\Views\Servicios\Details.cshtml"
  
    ViewData["Title"] = "Detalles";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<link rel=""stylesheet"" href=""//use.fontawesome.com/releases/v5.0.7/css/all.css"">
<style>
    a {
        color: #ffffff;
        text-decoration: none;
    }

    a:hover {
        color: #ffffff;
        text-decoration: none;
        cursor: pointer;
    }

    

    .font20 {
        font-size: 20px;
        font-weight: 300;
    }

    .justificado {
        text-align: justify;
        text- justify: auto;
    }

    .checked {
        color: orange;
    }
    .rating-css input{
        display: none;
    }
    .rating-css input:checked + label ~ label{
        color: #838383;
    }
</style>
<section id=""catalogue"" class=""catalogue section-bg"">
<div class=""container"">
<div class=""section-title"">
<h2 data-aos=""fade-in"">Detalles</h2>
    </div>

    <div class=""card"" style=""border: none;"">
        <div class=""row"">
            <div class=""col-md-4"">
                <div class=""card mb-4"">
                    <img class=""card-img-top"" style=""height: 500px; width:");
            WriteLiteral(" 100%; \"");
            BeginWriteAttribute("src", "\r\n                        src=\"", 1110, "\"", 1188, 2);
            WriteAttributeValue("", 1141, "/images/", 1141, 8, true);
#nullable restore
#line 52 "D:\USMP-2022-1\SOFTWARE-2\Nueva carpeta\PLANNING_POKER\esta-si-funciona\Views\Servicios\Details.cshtml"
WriteAttributeValue("", 1149, Html.DisplayFor(model => model.Imagen), 1149, 39, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", "\r\n                        alt=\"", 1189, "\"", 1259, 1);
#nullable restore
#line 53 "D:\USMP-2022-1\SOFTWARE-2\Nueva carpeta\PLANNING_POKER\esta-si-funciona\Views\Servicios\Details.cshtml"
WriteAttributeValue("", 1220, Html.DisplayFor(model => model.Imagen), 1220, 39, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                </div>\r\n            </div>\r\n            <div class=\"col-md-7\">\r\n                <br>\r\n                <h5 class=\"card-title\">");
#nullable restore
#line 58 "D:\USMP-2022-1\SOFTWARE-2\Nueva carpeta\PLANNING_POKER\esta-si-funciona\Views\Servicios\Details.cshtml"
                                  Write(Html.DisplayFor(model => model.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                <hr>\r\n                <ul class=\"list-unstyled\"></ul>\r\n                  \r\n                  <p class=\"card-text\">");
#nullable restore
#line 62 "D:\USMP-2022-1\SOFTWARE-2\Nueva carpeta\PLANNING_POKER\esta-si-funciona\Views\Servicios\Details.cshtml"
                                  Write(Html.DisplayFor(model => model.Descripcion));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                  <h5 class=\"card-title\">");
#nullable restore
#line 63 "D:\USMP-2022-1\SOFTWARE-2\Nueva carpeta\PLANNING_POKER\esta-si-funciona\Views\Servicios\Details.cshtml"
                                    Write(Html.DisplayFor(model => model.Precio));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h5>
                  <div class=""rating-css"">
                    <div class=""star-icon"">
                        <input type=""radio"" name=""rate"" id=""rate-5"">
                        <label for=""rate-5"" class=""fas fa-star""></label>
                        <input type=""radio"" name=""rate"" id=""rate-4"">
                        <label for=""rate-4"" class=""fas fa-star""></label>
                        <input type=""radio"" name=""rate"" id=""rate-3"">
                        <label for=""rate-3"" class=""fas fa-star""></label>
                        <input type=""radio"" name=""rate"" id=""rate-2"">
                        <label for=""rate-2"" class=""fas fa-star""></label>
                        <input type=""radio"" name=""rate"" id=""rate-1"">
                        <label for=""rate-1"" class=""fas fa-star""></label>
                    </div>
                  </div>
                  <br>
                  <hr>
                  <div>
                  ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "74d751254cb445efacbe4cfdba6fb946712036968663", async() => {
                WriteLiteral("</i>Acompa??antes");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                  </div>\r\n                  <br>\r\n                  <div>\r\n                  ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "74d751254cb445efacbe4cfdba6fb9467120369610010", async() => {
                WriteLiteral("</i>Regresar");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                  </div>\r\n                </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n</section>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<hostal.Models.Servicios> Html { get; private set; }
    }
}
#pragma warning restore 1591
