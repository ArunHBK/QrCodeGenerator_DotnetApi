using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QrCodeGenerator.Service;
using static System.Net.Mime.MediaTypeNames;

namespace QrCodeGenerator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QrCodeGeneratorController : ControllerBase
    {
        private readonly IQrCode qrCode;

        public QrCodeGeneratorController(IQrCode qrCode)
        {
            this.qrCode =qrCode;
        }

        [HttpPost]
        [Route("Image")]
        public ActionResult<string> generateQrCodeImage (string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return BadRequest("Text or URL is required");
            }
            else
            {
                byte[] qrCodeAsBytes = qrCode.generateQr(text);
                return File(qrCodeAsBytes,"image/png");
            }
        }

        [HttpPost]
        [Route("ImgSrcLink")]
        //Use the result in Img tag src attribute to get QrCode
        public ActionResult<string> generateQrCodeSrcLink(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return BadRequest("Text or URL is required");
            }
            else
            {
                byte[] qrCodeAsBytes = qrCode.generateQr(text);
                string qrCodeAsImageBase64 = $"data:image/png;base64,{Convert.ToBase64String(qrCodeAsBytes)}";
                return Ok(qrCodeAsImageBase64);
            }
        }
    }
}