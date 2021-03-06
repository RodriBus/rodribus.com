//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Contentful.ModelGenerator.Cli tool.
//     Runtime Version: 1.0.0.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contentful.Core.Models;

namespace RodriBusCom.Models.Content
{
    public partial class Education
    {
        [GeneratedCode("Contentful.ModelGenerator.Cli", "1.0.0.0")]
        public const string ContentTypeId = "education";

        [GeneratedCode("Contentful.ModelGenerator.Cli", "1.0.0.0")]
        public SystemProperties Sys { get; set; }
        [GeneratedCode("Contentful.ModelGenerator.Cli", "1.0.0.0")]
        public string Title { get; set; }
        [GeneratedCode("Contentful.ModelGenerator.Cli", "1.0.0.0")]
        public string School { get; set; }
        [GeneratedCode("Contentful.ModelGenerator.Cli", "1.0.0.0")]
        public string SchoolLocation { get; set; }
        [GeneratedCode("Contentful.ModelGenerator.Cli", "1.0.0.0")]
        public DateTime StartDate { get; set; }
        [GeneratedCode("Contentful.ModelGenerator.Cli", "1.0.0.0")]
        public DateTime EndDate { get; set; }
        [GeneratedCode("Contentful.ModelGenerator.Cli", "1.0.0.0")]
        public Document AdditionalInformation { get; set; }
        [GeneratedCode("Contentful.ModelGenerator.Cli", "1.0.0.0")]
        public bool HonorableMention { get; set; }

        [GeneratedCode("Contentful.ModelGenerator.Cli", "1.0.0.0")]
        public async Task<string> RenderAdditionalInformationAsync() => await new HtmlRenderer().ToHtml(AdditionalInformation);
    }
}