using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using QrCodeWriterSpikeApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace QrCodeWriterSpikeApp.ViewModels
{
    public class ZxingQrCodePageViewModel : ViewModelBase
    {
        private string qrCodeSource;

        public string QrCodeSource { get => qrCodeSource; set => SetProperty(ref qrCodeSource, value, nameof(QrCodeSource)); }

        public ZxingQrCodePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            MessagingCenter.Subscribe<QrCodeDetailsPageViewModel, string>(this, MessageTypes.QR_CODE_MESSAGE, (sender, qrCode) =>
            {
                QrCodeSource = qrCode;
                HasNoQrCodeValue = false;
                HasQrCodeValue = true;
            });
        }
    }
}
