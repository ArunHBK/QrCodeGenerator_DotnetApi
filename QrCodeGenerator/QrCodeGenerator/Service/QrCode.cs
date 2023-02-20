using QRCoder;

namespace QrCodeGenerator.Service
{
    public class QrCode : IQrCode
    {
        public byte[] generateQr(string text)
        {
            byte[] QrCode = new byte[0];
            if(!string.IsNullOrEmpty(text))
            {
                QRCodeGenerator qrCodeGenerator = new QRCodeGenerator();
                QRCodeData data = qrCodeGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
                BitmapByteQRCode bitmapQRCode = new BitmapByteQRCode(data);
                QrCode = bitmapQRCode.GetGraphic(20);
            }
            return QrCode;
        }
    }
}
