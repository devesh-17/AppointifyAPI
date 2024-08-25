using CityConnect.Pdf.Models;
using CityConnect.Pdf.RazorEngine;
using iText.Html2pdf;
using RazorEngine.Configuration;
using RazorEngine.Templating;
using System.IO;
using System.Linq;

namespace CityConnect.Pdf
{
    public class PdfGenerator
    {
        private static readonly TemplateServiceConfiguration Config = new TemplateServiceConfiguration
        {
            BaseTemplateType = typeof(PdfTemplateBase<>),
            TemplateManager = new EmbeddedTemplateManager(typeof(PdfGenerator).Namespace + ".Templates"),
            CachingProvider = new DefaultCachingProvider()
        };

        private static readonly IRazorEngineService RazorEngine = InitRazorEngine();

        private static IRazorEngineService InitRazorEngine()
        {
            return RazorEngineService.Create(Config);
        }

        private static void GenerateFromTemplate<T>(string template, string path = "", params T[] models)
        {
            var html1 = models.Select(model => RazorEngine.RunCompile(template, typeof(T), models[0])).ToArray();
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            HtmlConverter.ConvertToPdf(html1[0], new FileStream(path, FileMode.Create));
        }

        public static void GenerateSamplePdf(string path = "", params SampleModelPdf[] SamplePdf)
        {
            GenerateFromTemplate("SamplePdf", path, SamplePdf);
        }
    }
}
