#pragma checksum "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Announcements\Announcements.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "380ac2f1db5db0e14336fa5c5072881a2c082d9f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Announcements_Announcements), @"mvc.1.0.view", @"/Views/Announcements/Announcements.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"380ac2f1db5db0e14336fa5c5072881a2c082d9f", @"/Views/Announcements/Announcements.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d35d2813d6673bb22d8616e0dbf06eada8dc73d", @"/Views/_ViewImports.cshtml")]
    public class Views_Announcements_Announcements : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WebProject.Models.Announcement>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Announcements", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AnnouncementsDetail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral(@"

<section class=""section"">
    <div class=""announcements-wrapper"">
        <div class=""content-block"">
            <div class=""content-block1"">
                <h2 class=""announcements-wrapper-title"">
                    Duyurular
                    <svg class=""icon icon-bullhorn"">
                        <use xlink:href=""#icon-bullhorn""></use>
                    </svg>
                </h2>
                <p class=""announcements-wrapper-sub-title"">Lorem ipsum dolor, sit amet consectetur adipisicing elit.
                    Odit,
                    cum.</p>
            </div>
            <div class=""content-block2"">
");
#nullable restore
#line 19 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Announcements\Announcements.cshtml"
                 foreach (var item in Model.Take(3))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"announcements\">\r\n                        <div role=\"img\" class=\"announcements-img\"");
            BeginWriteAttribute("style", " style=\"", 886, "\"", 935, 4);
            WriteAttributeValue("", 894, "background-image:", 894, 17, true);
            WriteAttributeValue(" ", 911, "url(", 912, 5, true);
#nullable restore
#line 22 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Announcements\Announcements.cshtml"
WriteAttributeValue("", 916, item.PicturePath, 916, 17, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 933, ");", 933, 2, true);
            EndWriteAttribute();
            WriteLiteral("></div>\r\n                        <h3 class=\"announcements-title\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "380ac2f1db5db0e14336fa5c5072881a2c082d9f5542", async() => {
#nullable restore
#line 25 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Announcements\Announcements.cshtml"
                                               Write(item.Title);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 25 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Announcements\Announcements.cshtml"
                              WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </h3>\r\n                        <p class=\"announcements-text\">\r\n                            ");
#nullable restore
#line 28 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Announcements\Announcements.cshtml"
                       Write(item.ShortText);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </p>\r\n                        <p class=\"announcements-meta\">\r\n                            <time");
            BeginWriteAttribute("date-time", " date-time=\"", 1419, "\"", 1449, 1);
#nullable restore
#line 31 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Announcements\Announcements.cshtml"
WriteAttributeValue("", 1431, item.AdditionDate, 1431, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 31 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Announcements\Announcements.cshtml"
                                                            Write(item.AdditionDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</time>\r\n                        </p>\r\n                    </div>\r\n");
#nullable restore
#line 34 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Announcements\Announcements.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WebProject.Models.Announcement>> Html { get; private set; }
    }
}
#pragma warning restore 1591
