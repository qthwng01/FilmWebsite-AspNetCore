#pragma checksum "E:\Project ASP.Net Core\Jobject.Parse\Jobject Parse\Views\Home\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f84e63780748400f36860fcec4b9eca10b7b5520"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Detail), @"mvc.1.0.view", @"/Views/Home/Detail.cshtml")]
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
#line 1 "E:\Project ASP.Net Core\Jobject.Parse\Jobject Parse\Views\_ViewImports.cshtml"
using Jobject_Parse;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Project ASP.Net Core\Jobject.Parse\Jobject Parse\Views\_ViewImports.cshtml"
using Jobject_Parse.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f84e63780748400f36860fcec4b9eca10b7b5520", @"/Views/Home/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"18cee5cd88082f7b4a4f352759bba4834baeb4ba", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "E:\Project ASP.Net Core\Jobject.Parse\Jobject Parse\Views\Home\Detail.cshtml"
     foreach (var item in ViewBag.Data)
    {
        ViewData["Title"] = "Phim " + @item["movie"]["name"] + " -";
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"pd-wrap\">\r\n");
#nullable restore
#line 11 "E:\Project ASP.Net Core\Jobject.Parse\Jobject Parse\Views\Home\Detail.cshtml"
     foreach (var item in ViewBag.Data)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"container\">\r\n            <div class=\"heading-section\">\r\n                <h2>");
#nullable restore
#line 15 "E:\Project ASP.Net Core\Jobject.Parse\Jobject Parse\Views\Home\Detail.cshtml"
               Write(item["movie"]["name"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                <div class=\"product-name\" style=\"margin-bottom:1rem\">(");
#nullable restore
#line 16 "E:\Project ASP.Net Core\Jobject.Parse\Jobject Parse\Views\Home\Detail.cshtml"
                                                                 Write(item["movie"]["origin_name"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@")</div>
            </div>
            <div class=""row"">
                <div class=""col-xxl-12 col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12"">
                    <div>
                        <div class=""item"" style=""text-align:center"">
                            <img class=""lozad""");
            BeginWriteAttribute("src", " src=\"", 726, "\"", 759, 1);
#nullable restore
#line 22 "E:\Project ASP.Net Core\Jobject.Parse\Jobject Parse\Views\Home\Detail.cshtml"
WriteAttributeValue("", 732, item["movie"]["thumb_url"], 732, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" style=""width:200px; height:300px;object-fit:contain;text-align:center"">
                        </div>
                    </div>
                </div>
                <div class=""col-md-12"">
                    <div class=""product-dtl"">
                        <div class=""product-info"">
                            
                            <div class=""row info-film"">
                                <div class=""col-md-3"">
");
#nullable restore
#line 32 "E:\Project ASP.Net Core\Jobject.Parse\Jobject Parse\Views\Home\Detail.cshtml"
                                     if (@item["movie"]["episode_total"] == "")
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <p>Số tập: Đang cập nhật</p>\r\n");
#nullable restore
#line 35 "E:\Project ASP.Net Core\Jobject.Parse\Jobject Parse\Views\Home\Detail.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <p>Số tập: ");
#nullable restore
#line 38 "E:\Project ASP.Net Core\Jobject.Parse\Jobject Parse\Views\Home\Detail.cshtml"
                                              Write(item["movie"]["episode_total"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 39 "E:\Project ASP.Net Core\Jobject.Parse\Jobject Parse\Views\Home\Detail.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <p>Trạng thái: ");
#nullable restore
#line 40 "E:\Project ASP.Net Core\Jobject.Parse\Jobject Parse\Views\Home\Detail.cshtml"
                                              Write(item["movie"]["episode_current"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                    <p>Thời lượng: ");
#nullable restore
#line 41 "E:\Project ASP.Net Core\Jobject.Parse\Jobject Parse\Views\Home\Detail.cshtml"
                                              Write(item["movie"]["time"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                    <p>Năm phát hành: ");
#nullable restore
#line 42 "E:\Project ASP.Net Core\Jobject.Parse\Jobject Parse\Views\Home\Detail.cshtml"
                                                 Write(item["movie"]["year"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                    <p>Chất lượng: ");
#nullable restore
#line 43 "E:\Project ASP.Net Core\Jobject.Parse\Jobject Parse\Views\Home\Detail.cshtml"
                                              Write(item["movie"]["quality"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                </div>\r\n                                <div class=\"col-md-3\">\r\n                                    <p>Ngôn ngữ: ");
#nullable restore
#line 46 "E:\Project ASP.Net Core\Jobject.Parse\Jobject Parse\Views\Home\Detail.cshtml"
                                            Write(item["movie"]["lang"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                    <p>Đạo diễn: ");
#nullable restore
#line 47 "E:\Project ASP.Net Core\Jobject.Parse\Jobject Parse\Views\Home\Detail.cshtml"
                                            Write(item["movie"]["director"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                    <p>Diễn viên: ");
#nullable restore
#line 48 "E:\Project ASP.Net Core\Jobject.Parse\Jobject Parse\Views\Home\Detail.cshtml"
                                             Write(item["movie"]["actor"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                    <p>\r\n                                        Thể loại: ");
#nullable restore
#line 50 "E:\Project ASP.Net Core\Jobject.Parse\Jobject Parse\Views\Home\Detail.cshtml"
                                                   foreach (var item3 in ViewBag.GetCategory)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <span>");
#nullable restore
#line 52 "E:\Project ASP.Net Core\Jobject.Parse\Jobject Parse\Views\Home\Detail.cshtml"
                                             Write(item3["name"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(",</span>\r\n");
#nullable restore
#line 53 "E:\Project ASP.Net Core\Jobject.Parse\Jobject Parse\Views\Home\Detail.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </p>\r\n                                    <p>Quốc gia: ");
#nullable restore
#line 55 "E:\Project ASP.Net Core\Jobject.Parse\Jobject Parse\Views\Home\Detail.cshtml"
                                            Write(item["movie"]["country"][0]["name"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                                </div>
                            </div>
                        </div>
                        <p style=""text-align:justify""></p>
                        <div class=""product-count"" style=""height:200px; overflow:auto;"">
                            <label for=""size""></label>
");
#nullable restore
#line 62 "E:\Project ASP.Net Core\Jobject.Parse\Jobject Parse\Views\Home\Detail.cshtml"
                             foreach (var item2 in ViewBag.getServerData)
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 64 "E:\Project ASP.Net Core\Jobject.Parse\Jobject Parse\Views\Home\Detail.cshtml"
                                                                                                           
                                if (@item2.link_embed == "")
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <button data-src=\"\" class=\"btn btn-primary pr-4 pl-4 disabled\">Trailer</button>\r\n");
#nullable restore
#line 68 "E:\Project ASP.Net Core\Jobject.Parse\Jobject Parse\Views\Home\Detail.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <button data-src=\"");
#nullable restore
#line 71 "E:\Project ASP.Net Core\Jobject.Parse\Jobject Parse\Views\Home\Detail.cshtml"
                                                 Write(item2.link_embed);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"round-black-btn\">");
#nullable restore
#line 71 "E:\Project ASP.Net Core\Jobject.Parse\Jobject Parse\Views\Home\Detail.cshtml"
                                                                                            Write(item2.name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</button>\r\n");
#nullable restore
#line 72 "E:\Project ASP.Net Core\Jobject.Parse\Jobject Parse\Views\Home\Detail.cshtml"
                                }
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </div>
                    </div>
                </div>
            </div>
            <div class=""product-info-tabs"">
                <ul class=""nav nav-tabs"" id=""myTab"" role=""tablist"">
                    <li class=""nav-item"">
                        <a class=""nav-link active"" id=""description-tab"" data-toggle=""tab"" href=""#description"" role=""tab"" aria-controls=""description"" aria-selected=""true"">Nội dung</a>
                    </li>
                    <li class=""nav-item"">
                        <a class=""nav-link"" id=""review-tab"" data-toggle=""tab"" href=""#review"" role=""tab"" aria-controls=""review"" aria-selected=""false"">Trailer</a>
                    </li>
                </ul>
                <div class=""tab-content"" id=""myTabContent"">
                    <div class=""tab-pane fade show active"" id=""description"" role=""tabpanel"" aria-labelledby=""description-tab"">
                       ");
#nullable restore
#line 89 "E:\Project ASP.Net Core\Jobject.Parse\Jobject Parse\Views\Home\Detail.cshtml"
                  Write(Html.Raw(@item["movie"]["content"]));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </div>
                    <div class=""tab-pane fade"" id=""review"" role=""tabpanel"" aria-labelledby=""review-tab"">
                        <div class=""review-heading"">Updating.</div>

                    </div>
                </div>
            </div>
        </div>
");
#nullable restore
#line 98 "E:\Project ASP.Net Core\Jobject.Parse\Jobject Parse\Views\Home\Detail.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <hr />\r\n    <h4 style=\"margin-left:20px; color:#fff\">Xem Phim</h4>\r\n");
            WriteLiteral("    <div id=\"watch\">\r\n        <iframe width=\"1100\" height=\"500\"\r\n                src=\"https://www.youtube.com/embed/6eONmnFB9sw\"\r\n                frameborder=\"0\" allowfullscreen>\r\n        </iframe>\r\n    </div>\r\n</div>\r\n\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
