#pragma checksum "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Shared\_Footer.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "86caabe44e29956ef96702ca59ccb75012311ef4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Footer), @"mvc.1.0.view", @"/Views/Shared/_Footer.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"86caabe44e29956ef96702ca59ccb75012311ef4", @"/Views/Shared/_Footer.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d35d2813d6673bb22d8616e0dbf06eada8dc73d", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Footer : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<footer role=\"nav\">\r\n    <div class=\"footer-wrapper\">\r\n        ");
#nullable restore
#line 3 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Shared\_Footer.cshtml"
   Write(await Component.InvokeAsync("FooterMenuComponent"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        <div class=""contact-us"">
            <h3 class=""contact-us-title"">
                İletişim
            </h3>
            <div class=""address"">
                <h4>Adres</h4>
                <p>Ömer Nasuhi Bilmen Mah. Havaalanı Yolu Cad. Yakutiye/ERZURUM</p>
            </div>
            <div>
                <h4>Mail</h4>
                <a href=""mailto:bilgi@erzurum.edu.tr"">bilgi@erzurum.edu.tr</a>
            </div>
            <div>
                <h4>Telefon</h4>
                <a href=""tel:+0442 444 5 388"">0442 444 5 388</a>
            </div>
        </div>
    </div>
</footer>
<footer role=""main"">
    <a id=""top-link-btn"" href=""#top-of-site"" class=""btn btn-top-link"">
        <svg class=""icon icon-circle-up"">
            <use xlink:href=""#icon-circle-up""></use>
        </svg>
    </a>
    <p>
        &copy; Hodagh All right reserved 2021
    </p>

    <ul>
        <li><a href=""#"">Privacy Policy</a></li>
        <li><a href=""#"">Cookies Policy</a></li>
       ");
            WriteLiteral(" <li><a href=\"#\">Copyright</a></li>\r\n        <li><a href=\"#\">Site Map</a></li>\r\n    </ul>\r\n\r\n\r\n</footer>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
