using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace QrCodeWriterSpikeApp.ViewModels
{
    public class ViewModelBase : BindableBase, IInitialize, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }
        private bool _hasQrCodeValue = false;
        private bool _hasNoQrCodeValue = true;

        public bool HasQrCodeValue
        {
            get => _hasQrCodeValue;
            set => SetProperty(ref _hasQrCodeValue, value, nameof(HasQrCodeValue));
        }
        public bool HasNoQrCodeValue
        {
            get => _hasNoQrCodeValue;
            set => SetProperty(ref _hasNoQrCodeValue, value, nameof(HasNoQrCodeValue));
        }
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public virtual void Initialize(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }
    }
}
