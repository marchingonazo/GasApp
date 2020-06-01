using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using GasApp.Views;

namespace GasApp.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ClicRegisterPageCommand { get; set; }

        public LoginViewModel()
        {
            ClicRegisterPageCommand = new Command(async () =>
              {
                  await Application.Current.MainPage.Navigation.PushModalAsync(new RegistrationPage());
              });
           
        }       
    }
}
