#pragma checksum "C:\Users\vinci\OneDrive\Documenten\Forum-App-S2\Forum App\Presentation Layer\Views\Message\ReceivedMessages.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4d5d61cccccbd9513ffa526a90c0f9e7cc671eee"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Message_ReceivedMessages), @"mvc.1.0.view", @"/Views/Message/ReceivedMessages.cshtml")]
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
#line 1 "C:\Users\vinci\OneDrive\Documenten\Forum-App-S2\Forum App\Presentation Layer\Views\_ViewImports.cshtml"
using Presentation_Layer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\vinci\OneDrive\Documenten\Forum-App-S2\Forum App\Presentation Layer\Views\_ViewImports.cshtml"
using Presentation_Layer.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\vinci\OneDrive\Documenten\Forum-App-S2\Forum App\Presentation Layer\Views\Message\ReceivedMessages.cshtml"
using Presentation_Layer.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d5d61cccccbd9513ffa526a90c0f9e7cc671eee", @"/Views/Message/ReceivedMessages.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3763f04b0ea78e3e76dcedd889576ef722b28b19", @"/Views/_ViewImports.cshtml")]
    public class Views_Message_ReceivedMessages : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Presentation_Layer.ViewModels.MessageViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div id=""table-wrapper"">
    <div id=""table-scroll"">
        <table class=""table table-striped table-hover"">
            <h1>Received Messages</h1>
            <thead>
                <tr>
                    <th>Title</th>
                    <th>Content</th>
                    <th>Message Time</th>
                    <th>Sender</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 17 "C:\Users\vinci\OneDrive\Documenten\Forum-App-S2\Forum App\Presentation Layer\Views\Message\ReceivedMessages.cshtml"
                 foreach(MessageDetailVM item in Model.Messages)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\vinci\OneDrive\Documenten\Forum-App-S2\Forum App\Presentation Layer\Views\Message\ReceivedMessages.cshtml"
                     if(item.ReceiverId == Model.Account.Id)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>\r\n                                ");
#nullable restore
#line 23 "C:\Users\vinci\OneDrive\Documenten\Forum-App-S2\Forum App\Presentation Layer\Views\Message\ReceivedMessages.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 26 "C:\Users\vinci\OneDrive\Documenten\Forum-App-S2\Forum App\Presentation Layer\Views\Message\ReceivedMessages.cshtml"
                           Write(Html.DisplayFor(modelItem => item.MessageContent));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 29 "C:\Users\vinci\OneDrive\Documenten\Forum-App-S2\Forum App\Presentation Layer\Views\Message\ReceivedMessages.cshtml"
                           Write(Html.DisplayFor(modelItem => item.MessageTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 32 "C:\Users\vinci\OneDrive\Documenten\Forum-App-S2\Forum App\Presentation Layer\Views\Message\ReceivedMessages.cshtml"
                           Write(Html.DisplayFor(modelItem => item.SenderId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 35 "C:\Users\vinci\OneDrive\Documenten\Forum-App-S2\Forum App\Presentation Layer\Views\Message\ReceivedMessages.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 35 "C:\Users\vinci\OneDrive\Documenten\Forum-App-S2\Forum App\Presentation Layer\Views\Message\ReceivedMessages.cshtml"
                     
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Presentation_Layer.ViewModels.MessageViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
