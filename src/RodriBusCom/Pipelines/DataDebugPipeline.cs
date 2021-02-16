//using Statiq.Common;
//using Statiq.Core;

//namespace RodriBusCom.Pipelines
//{
//    public class DataDebugPipeline : Pipeline
//    {
//        private readonly string[] Deps = new[]
//        {
//            nameof(LoadProductsPipeline),
//            nameof(LoadModelsPipeline),
//            nameof(LoadLicensesPipeline),
//        };

//        public DataDebugPipeline(DataContext ct)
//        {
//            Dependencies.AddRange(Deps);

//            ProcessModules = new ModuleList {
//                new ReplaceDocuments(Deps), // Get docs from a different pipeline
//                new GroupDocuments("_type"),
//                //new MergeDocuments(Config.FromDocument((doc, ctx) =>
//                //    {
//                //        var modules = new ModuleList();
//                //        return doc.Yield();
//                //    })),
//                //new ForEachDocument
//                //{
//                //    new ExecuteConfig(Config.FromDocument((doc, ctx) =>
//                //    {
//                //        var modules = new ModuleList()
//                //    }))
//                //},
//                new SetDestination(Config.FromDocument((doc, ctx)  => {
//                    ctx.LogWarning(doc, doc.Get(Keys._type, string.Empty));
//                    return doc.Destination; })),
//            };
//        }
//    }
//}