using System;
using System.Collections.Generic;
using System.ComponentModel;

using Xamarin.Forms;
using System.Windows.Input;
using System.IO;
using GasApp.Models;
using Plugin.Media;
using System.Threading;
using Plugin.Media.Abstractions;

namespace GasApp.ViewModels
{
    public class RegistrationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ClicLoginPageCommand { get; set; }
        public ICommand ClicAddImageCommand { get; set; }
        public ICommand ClicSafeUserCommand { get; set; }

        public Image imageSource;
        private MediaFile file;

        
        public RegistrationViewModel()
        {
            ClicLoginPageCommand = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PopAsync();
            });

            ClicAddImageCommand = new Command(async () =>
            {
                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    await Application.Current.MainPage.DisplayAlert("Photo not suported", ":(", "OK");
                    return;
                }
                file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(
                    new Plugin.Media.Abstractions.PickMediaOptions
                    {
                        PhotoSize = Plugin.Media.Abstractions.PhotoSize.Small
                    });
                if (file == null)
                    return;

                imageSource.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });
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
