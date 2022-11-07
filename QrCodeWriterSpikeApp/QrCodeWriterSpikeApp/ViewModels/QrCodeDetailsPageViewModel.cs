using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using QrCodeWriterSpikeApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using ZXing.PDF417.Internal;

namespace QrCodeWriterSpikeApp.ViewModels
{
    public class QrCodeDetailsPageViewModel : ViewModelBase
    {
        private string _qrCodeValue;

        public DelegateCommand GenerateQrCodeValueCommand { get; set; }
        public string QrCodeValue
        {
            get => _qrCodeValue;
            set => SetProperty(ref _qrCodeValue, value, nameof(QrCodeValue));
        }

        public QrCodeDetailsPageViewModel(INavigationService navigationService):
            base(navigationService)
        {
            GenerateQrCodeValueCommand = new DelegateCommand(GenerateQrCodeValueForProviders);
        }

        public void GenerateQrCodeValueForProviders()
        {
            MessagingCenter.Send<QrCodeDetailsPageViewModel, string>(this, MessageTypes.QR_CODE_MESSAGE, QrCodeValue);
        }
    }
}
