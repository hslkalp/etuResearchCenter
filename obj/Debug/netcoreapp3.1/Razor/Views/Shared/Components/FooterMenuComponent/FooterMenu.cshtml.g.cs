#pragma checksum "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Shared\Components\FooterMenuComponent\FooterMenu.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "513c3ee6450df2e659a37a883bf691fd4d9d2c3f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_FooterMenuComponent_FooterMenu), @"mvc.1.0.view", @"/Views/Shared/Components/FooterMenuComponent/FooterMenu.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"513c3ee6450df2e659a37a883bf691fd4d9d2c3f", @"/Views/Shared/Components/FooterMenuComponent/FooterMenu.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d35d2813d6673bb22d8616e0dbf06eada8dc73d", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_FooterMenuComponent_FooterMenu : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WebProject.Models.FooterMenu>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Shared\Components\FooterMenuComponent\FooterMenu.cshtml"
 foreach (var item in Model)
{
    if (item.ParentId == null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <ul>\r\n            <h3>");
#nullable restore
#line 8 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Shared\Components\FooterMenuComponent\FooterMenu.cshtml"
           Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n            <li>\r\n");
#nullable restore
#line 10 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Shared\Components\FooterMenuComponent\FooterMenu.cshtml"
                 if (item.ParentId == null && Model.Where(a => a.ParentId == item.Id).Any())
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <ul>\r\n");
#nullable restore
#line 13 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Shared\Components\FooterMenuComponent\FooterMenu.cshtml"
                         foreach (var item1 in Model.Where(a => item.Id == a.ParentId).OrderBy(x => x.Queue))
                        {
                            var link = "";
                            if (item1.Link != null && item1.Link != "")
                            {
                                link = item1.Link.Replace(" ", "-");
                            }
                            else
                            {
                                link = @item.Name + "/" + item1.Name.Replace(" ", "-");
                            }

                            if (item1.TargetBlank == false)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li><a");
            BeginWriteAttribute("href", " href=\"", 1032, "\"", 1044, 1);
#nullable restore
#line 27 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Shared\Components\FooterMenuComponent\FooterMenu.cshtml"
WriteAttributeValue("", 1039, link, 1039, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 27 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Shared\Components\FooterMenuComponent\FooterMenu.cshtml"
                                               Write(item1.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 28 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Shared\Components\FooterMenuComponent\FooterMenu.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li>\r\n                                    <a target=\"_blank\"");
            BeginWriteAttribute("href", " href=\"", 1256, "\"", 1268, 1);
#nullable restore
#line 32 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Shared\Components\FooterMenuComponent\FooterMenu.cshtml"
WriteAttributeValue("", 1263, link, 1263, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 32 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Shared\Components\FooterMenuComponent\FooterMenu.cshtml"
                                                               Write(item1.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                </li>\r\n");
#nullable restore
#line 34 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Shared\Components\FooterMenuComponent\FooterMenu.cshtml"
                            }
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </ul>\r\n");
#nullable restore
#line 37 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Shared\Components\FooterMenuComponent\FooterMenu.cshtml"

                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </li>\r\n        </ul>\r\n");
#nullable restore
#line 41 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Shared\Components\FooterMenuComponent\FooterMenu.cshtml"
    }
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WebProject.Models.FooterMenu>> Html { get; private set; }
    }
}
#pragma warning restore 1591
