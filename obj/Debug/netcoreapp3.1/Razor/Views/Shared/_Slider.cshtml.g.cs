#pragma checksum "C:\Users\hodag\source\repos\WebProject\WebProject\Views\Shared\_Slider.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5c6405fdf1c8a55afc58469598827d04a78c3e68"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Slider), @"mvc.1.0.view", @"/Views/Shared/_Slider.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c6405fdf1c8a55afc58469598827d04a78c3e68", @"/Views/Shared/_Slider.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d35d2813d6673bb22d8616e0dbf06eada8dc73d", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Slider : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""slider-wrapper"">
    <div id=""slider"" class=""slider"">
        <div v-for=""(slide, index) in sliderData"" class=""slide"" :class=""{ 'active': index === 0 }"">
            <div role=""img"" class=""slide-img"" :style=""{ backgroundImage: 'url(' + slide.picture + ')' }""></div>
            <div class=""slide-inner"">
                <h1>{{slide.title}}</h1>
                <p>{{slide.subTitle}}</p>
                <a :href=""slide.link"" type=""button"" class=""btn read-more-btn"">
                    Daha Fazla
                    <svg class=""icon icon-arrow-right2"">
                        <use xlink:href=""#icon-arrow-right2""></use>
                    </svg>
                </a>
            </div>
        </div>
    </div>
    <p id=""arrow-cta"" class=""arrow arrow-anim"">
        <svg class=""icon icon-arrow-down"">
            <use xlink:href=""#icon-arrow-down""></use>
        </svg>
    </p>
    <div class=""slider-indicators"">
        <button id=""slider-prev-btn"" class=""btn"">
            <svg cl");
            WriteLiteral(@"ass=""icon icon-arrow-left2"">
                <use xlink:href=""#icon-arrow-left2""></use>
            </svg>
        </button>
        <button id=""slider-next-btn"" class=""btn"">
            <svg class=""icon icon-arrow-right2"">
                <use xlink:href=""#icon-arrow-right2""></use>
            </svg>
        </button>
    </div>
</div>

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
