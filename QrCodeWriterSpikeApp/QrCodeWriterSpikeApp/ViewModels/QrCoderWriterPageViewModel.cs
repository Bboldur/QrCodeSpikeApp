using Prism.Navigation;
using QRCoder;
using QRCoder.Xaml;
using QrCodeWriterSpikeApp.Enums;
using QrCodeWriterSpikeApp.Views;
using System;
using System.Collections.ObjectModel;
using System.IO;
using Xamarin.Forms;
using ZXing.QrCode.Internal;

namespace QrCodeWriterSpikeApp.ViewModels
{
    public class QrCoderWriterPageViewModel : ViewModelBase
    {
        private MemoryStream qrCodeSource;

        public MemoryStream QrCodeSource { get => qrCodeSource; set => SetProperty(ref qrCodeSource,value, nameof(QrCodeSource)); }

        public QrCoderWriterPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            MessagingCenter.Subscribe<QrCodeDetailsPageViewModel, string>(this, MessageTypes.QR_CODE_MESSAGE, (sender, qrcode) =>
            {
                GenerateQrCode(qrcode);
            });

        }

        public void GenerateQrCode(string qrcode)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrcode, QRCodeGenerator.ECCLevel.L);

            BitmapByteQRCode qrCode = new BitmapByteQRCode(qrCodeData);
            byte[] bitmapByteArray = qrCode.GetGraphic(20);
            QrCodeSource = new MemoryStream(bitmapByteArray);
          
            HasNoQrCodeValue = false;
            HasQrCodeValue = true;
        }
    }
}
