#pragma checksum "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Home\substructureDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6a67d7baa8620ae3ba7a345b3a821021de57eff2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_substructureDetail), @"mvc.1.0.view", @"/Views/Home/substructureDetail.cshtml")]
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
#line 1 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\_ViewImports.cshtml"
using WebProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\_ViewImports.cshtml"
using WebProject.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6a67d7baa8620ae3ba7a345b3a821021de57eff2", @"/Views/Home/substructureDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d35d2813d6673bb22d8616e0dbf06eada8dc73d", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_substructureDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebProject.Models.Substructure>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"substructure-lab-wrapper\">\r\n    <h1>");
#nullable restore
#line 4 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Home\substructureDetail.cshtml"
   Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n    <hr>\r\n    <div class=\"row-2\">\r\n        <div class=\"col-2\">\r\n            <p>");
#nullable restore
#line 8 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Home\substructureDetail.cshtml"
          Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <br>\r\n            <div class=\"img-wrapper\" style=\"max-width: 500px;\">\r\n                <img");
            BeginWriteAttribute("src", " src=\"", 313, "\"", 337, 1);
#nullable restore
#line 11 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Home\substructureDetail.cshtml"
WriteAttributeValue("", 319, Model.PicturePath, 319, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 338, "\"", 361, 2);
#nullable restore
#line 11 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Home\substructureDetail.cshtml"
WriteAttributeValue("", 344, Model.Name, 344, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 355, "resmi", 356, 6, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n            </div>\r\n        </div>\r\n\r\n\r\n    </div>\r\n    <h3>Laboratuvarlar</h3>\r\n    <hr>\r\n    <div class=\"row-2\">\r\n");
#nullable restore
#line 20 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Home\substructureDetail.cshtml"
         if (ViewBag.labs != null)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Home\substructureDetail.cshtml"
             foreach (var item in ViewBag.labs)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-2\">\r\n                    <div class=\"img-wrapper\" style=\"max-width: 330px;\">\r\n                        <img");
            BeginWriteAttribute("src", " src=\"", 730, "\"", 753, 1);
#nullable restore
#line 26 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Home\substructureDetail.cshtml"
WriteAttributeValue("", 736, item.PicturePath, 736, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 754, "\"", 776, 2);
#nullable restore
#line 26 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Home\substructureDetail.cshtml"
WriteAttributeValue("", 760, item.Name, 760, 10, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 770, "resmi", 771, 6, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                    </div>\r\n                    <p>");
#nullable restore
#line 28 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Home\substructureDetail.cshtml"
                  Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    <p>");
#nullable restore
#line 29 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Home\substructureDetail.cshtml"
                  Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </div>\r\n");
#nullable restore
#line 31 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Home\substructureDetail.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 31 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Home\substructureDetail.cshtml"
             
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <p>Altyapıya ait laboratuvar bulunmamaktadır</p>\r\n");
#nullable restore
#line 36 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Home\substructureDetail.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebProject.Models.Substructure> Html { get; private set; }
    }
}
#pragma warning restore 1591
