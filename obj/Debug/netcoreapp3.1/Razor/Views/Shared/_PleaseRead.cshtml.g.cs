#pragma checksum "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Shared\_PleaseRead.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "155e7e7d2acb6ff946df7019e83fda5ad13250be"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__PleaseRead), @"mvc.1.0.view", @"/Views/Shared/_PleaseRead.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"155e7e7d2acb6ff946df7019e83fda5ad13250be", @"/Views/Shared/_PleaseRead.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d35d2813d6673bb22d8616e0dbf06eada8dc73d", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__PleaseRead : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<string>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<ul class=\"list-group\">\r\n    <li class=\"list-group-item disabled active text-center text-uppercase\" aria-disabled=\"true\" aria-current=\"true\">\r\n        <h4>lütfen Okuyunuz!</h4>\r\n    </li>\r\n");
#nullable restore
#line 7 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Shared\_PleaseRead.cshtml"
     if (Model == "Duyuru")
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li class=\"list-group-item list-group-item-warning p-3\">\r\n            <i class=\"fas fa-exclamation-triangle\"></i>\r\n            ETÜ Araştırma Merkezi Anasayfasında bulunan <strong>");
#nullable restore
#line 11 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Shared\_PleaseRead.cshtml"
                                                           Write(Model);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong> verisidir.\r\n        </li>\r\n");
#nullable restore
#line 13 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Shared\_PleaseRead.cshtml"
    }
    else if (Model == "Yönetici")
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li class=\"list-group-item list-group-item-warning p-3\">\r\n            <i class=\"fas fa-exclamation-triangle\"></i>\r\n            ETÜ Araştırma Merkezi <strong>");
#nullable restore
#line 18 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Shared\_PleaseRead.cshtml"
                                     Write(Model);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong> kadrosudur.\r\n        </li>\r\n");
#nullable restore
#line 20 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Shared\_PleaseRead.cshtml"
    }
    else if (Model == "Kullanıcı")
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li class=\"list-group-item list-group-item-warning p-3\">\r\n            <i class=\"fas fa-exclamation-triangle\"></i>\r\n            ETÜ Araştırma Merkezi Web Sitesinin <strong>");
#nullable restore
#line 25 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Shared\_PleaseRead.cshtml"
                                                   Write(Model);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong> üyeleridir belirli verileri sisteme girirler.\r\n        </li>\r\n");
#nullable restore
#line 27 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Shared\_PleaseRead.cshtml"
    }
    else if (Model == "Altyapı")
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li class=\"list-group-item list-group-item-warning p-3\">\r\n            <i class=\"fas fa-exclamation-triangle\"></i>\r\n            ETÜ Araştırma Merkezi <strong>");
#nullable restore
#line 32 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Shared\_PleaseRead.cshtml"
                                     Write(Model);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong> bilgisidir.\r\n        </li>\r\n");
#nullable restore
#line 34 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Shared\_PleaseRead.cshtml"
    }
    else if (Model == "Haber")
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li class=\"list-group-item list-group-item-warning p-3\">\r\n            <i class=\"fas fa-exclamation-triangle\"></i>\r\n            ETÜ Araştırma Merkezi <strong>");
#nullable restore
#line 39 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Shared\_PleaseRead.cshtml"
                                     Write(Model);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong> bilgisidir Web Sitenin Ana sayfasında gözükür.\r\n        </li>\r\n");
#nullable restore
#line 41 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Shared\_PleaseRead.cshtml"
    }
    else if (Model == "Makale")
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li class=\"list-group-item list-group-item-warning p-3\">\r\n            <i class=\"fas fa-exclamation-triangle\"></i>\r\n            ETÜ Araştırma Merkezi <strong>");
#nullable restore
#line 46 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Shared\_PleaseRead.cshtml"
                                     Write(Model);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong> bilgisidir. Araştırmacılar tarafından sisteme girilir.\r\n        </li>\r\n");
#nullable restore
#line 48 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Shared\_PleaseRead.cshtml"
    }
    else if (Model == "Bildiri")
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li class=\"list-group-item list-group-item-warning p-3\">\r\n            <i class=\"fas fa-exclamation-triangle\"></i>\r\n            ETÜ Araştırma Merkezi <strong>");
#nullable restore
#line 53 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Shared\_PleaseRead.cshtml"
                                     Write(Model);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong> bilgisidir. Araştırmacılar tarafından sisteme girilir.\r\n        </li>\r\n");
#nullable restore
#line 55 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Shared\_PleaseRead.cshtml"
    }
    else if (Model == "Proje")
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li class=\"list-group-item list-group-item-warning p-3\">\r\n            <i class=\"fas fa-exclamation-triangle\"></i>\r\n            ETÜ Araştırma Merkezi <strong>");
#nullable restore
#line 60 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Shared\_PleaseRead.cshtml"
                                     Write(Model);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong> bilgisidir. Araştırmacılar tarafından sisteme girilir.\r\n        </li>\r\n");
#nullable restore
#line 62 "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Shared\_PleaseRead.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <li class=""list-group-item list-group-item-warning p-3"">
        <i class=""fas fa-exclamation-triangle""></i>
        Form Eksiksiz doldurulmalıdır aksi taktirde kayıt yapılmaz.
    </li>
    <li class=""list-group-item list-group-item-warning p-3"">
        <i class=""fas fa-exclamation-triangle""></i>
        İlgili Form elemanlarına doğru bilgi girdiğinizden lütfen emin olunuz.
    </li>
</ul>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<string> Html { get; private set; }
    }
}
#pragma warning restore 1591