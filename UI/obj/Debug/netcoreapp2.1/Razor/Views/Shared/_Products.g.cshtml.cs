#pragma checksum "E:\Visual Studio 2017\Projects\BootCamp\ASP.NET\FincaUserProduct\UI\Views\Shared\_Products.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cff4ab5cd389e7cf9310fa56cc45158d66b1e5b8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Products), @"mvc.1.0.view", @"/Views/Shared/_Products.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_Products.cshtml", typeof(AspNetCore.Views_Shared__Products))]
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
#line 1 "E:\Visual Studio 2017\Projects\BootCamp\ASP.NET\FincaUserProduct\UI\Views\_ViewImports.cshtml"
using DAL.Entities;

#line default
#line hidden
#line 2 "E:\Visual Studio 2017\Projects\BootCamp\ASP.NET\FincaUserProduct\UI\Views\_ViewImports.cshtml"
using UI.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cff4ab5cd389e7cf9310fa56cc45158d66b1e5b8", @"/Views/Shared/_Products.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0bfb89f32a963047349bbda86bf4abe2f8aa299a", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Products : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProductsViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(26, 237, true);
            WriteLiteral("\r\n<div id=\"products\" class=\"container\">\r\n\r\n    <h2>Products</h2>\r\n    <table class=\"table table-bordered col-md-3\">\r\n        <thead>\r\n            <tr>\r\n                <th>Name</th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
            EndContext();
#line 13 "E:\Visual Studio 2017\Projects\BootCamp\ASP.NET\FincaUserProduct\UI\Views\Shared\_Products.cshtml"
             foreach (Product item in Model.Products)
            {

#line default
#line hidden
            BeginContext(333, 72, true);
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(406, 9, false);
#line 17 "E:\Visual Studio 2017\Projects\BootCamp\ASP.NET\FincaUserProduct\UI\Views\Shared\_Products.cshtml"
                   Write(item.Name);

#line default
#line hidden
            EndContext();
            BeginContext(415, 199, true);
            WriteLiteral("\r\n                        <div class=\"float-right\">\r\n                            <button type=\"button\" class=\"btn btn-primary\">\r\n                                Count <span class=\"badge badge-light\">");
            EndContext();
            BeginContext(615, 10, false);
#line 20 "E:\Visual Studio 2017\Projects\BootCamp\ASP.NET\FincaUserProduct\UI\Views\Shared\_Products.cshtml"
                                                                 Write(item.Count);

#line default
#line hidden
            EndContext();
            BeginContext(625, 130, true);
            WriteLiteral("</span>\r\n                            </button>\r\n                        </div>\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 25 "E:\Visual Studio 2017\Projects\BootCamp\ASP.NET\FincaUserProduct\UI\Views\Shared\_Products.cshtml"
            }

#line default
#line hidden
            BeginContext(770, 38, true);
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProductsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591