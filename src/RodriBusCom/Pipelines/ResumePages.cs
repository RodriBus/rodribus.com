using RodriBusCom.Modules;
using Statiq.Common;
using Statiq.Core;
using Statiq.Razor;

namespace RodriBusCom.Pipelines
{
    public class ResumePages : Pipeline
    {
        public const string CvView = "Cv.cshtml";

        private readonly string[] Deps = new[]
        {
            nameof(LoadGeneralInformationEs),
            nameof(LoadAptitudesEs),
            nameof(LoadEducationsEs),
            nameof(LoadExperiencesEs),
            nameof(LoadKnowledgesEs),
        };

        public ResumePages()
        {
            Dependencies.AddRange(Deps);

            ProcessModules = new ModuleList {
                // Include product view
                new ReadFiles(patterns: CvView),

                // Render page
                new RenderRazor(),

                // Set destination
                new SetDestination(Config.FromDocument(_ => new NormalizedPath("cv.html"))),
            };

            OutputModules = new ModuleList {
                new BeautifyHtml(),
                new WriteFiles(),
            };
        }

        public static string DEBUG(IDocument doc)
        {
            return doc.ToSafeDisplayString();
        }
    }
}