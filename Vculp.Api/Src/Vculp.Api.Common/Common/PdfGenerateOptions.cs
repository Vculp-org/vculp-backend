namespace Vculp.Api.Common.Common
{
    public class PdfGenerateOptions
    {
        public string Title { get; set; }
        public double PageWidth { get; set; }
        public double PageHeight { get; set; }
        public bool IsLandscapeMode { get; set; }
        public int RotationDegrees { get; set; }
    }
}
