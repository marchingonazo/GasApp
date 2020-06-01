using System;
using System.Collections.Generic;
using System.ComponentModel;

using Xamarin.Forms;
using System.Windows.Input;

namespace GasApp.ViewModels
{
    public class RegistrationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand ClicLoginPageCommand { get; set; }

        public RegistrationViewModel()
        {
            ClicLoginPageCommand = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PopAsync();
            });
        }
        public void SafeUser()
        {

        }
        public void DeleteUser()
        {

        }

    }
}
