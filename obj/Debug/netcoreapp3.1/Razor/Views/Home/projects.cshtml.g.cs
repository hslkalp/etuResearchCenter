#pragma checksum "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Home\projects.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c7c0df9ad88820f9412919c2d5bfdf3e6a29cff1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_projects), @"mvc.1.0.view", @"/Views/Home/projects.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c7c0df9ad88820f9412919c2d5bfdf3e6a29cff1", @"/Views/Home/projects.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d35d2813d6673bb22d8616e0dbf06eada8dc73d", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_projects : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WebProject.Models.Project>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"project-wrapper\">\r\n    <div class=\"project\">\r\n        <div class=\"project-title\">\r\n            <h1>Projeler</h1>\r\n        </div>\r\n        <ul class=\"project-list\">\r\n");
#nullable restore
#line 9 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Home\projects.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li>\r\n                    <p>\r\n                        <svg class=\"icon icon-files-empty\">\r\n                            <use xlink:href=\"#icon-files-empty\"></use>\r\n                        </svg>\r\n                        <i>");
#nullable restore
#line 16 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Home\projects.cshtml"
                      Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</i>, ");
#nullable restore
#line 16 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Home\projects.cshtml"
                                      Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </p>\r\n                </li>\r\n");
#nullable restore
#line 19 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Home\projects.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </ul>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WebProject.Models.Project>> Html { get; private set; }
    }
}
#pragma warning restore 1591
