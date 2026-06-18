using ZXing;
using ZXing.Common;

namespace News_Project.Controllers
{
    internal class BarcodeWriter
    {
        public BarcodeFormat Format { get; set; }
        public EncodingOptions Options { get; set; }
    }
}