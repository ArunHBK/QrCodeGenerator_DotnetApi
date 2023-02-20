namespace QrCodeGenerator.Service
{
    public interface IQrCode
    {
        public byte[] generateQr(string text);
    }
}
