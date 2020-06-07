using System;
using System.Collections.Generic;
using System.ComponentModel;

using Xamarin.Forms;
using System.Windows.Input;
using System.IO;

namespace GasApp.ViewModels
{
    public class RegistrationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ClicLoginPageCommand { get; set; }
        public ICommand ClicAddImageCommand { get; set; }
        public ICommand ClicSafeUserCommand { get; set; }


        public RegistrationViewModel()
        {
            ClicLoginPageCommand = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PopAsync();
            });

            ClicAddImageCommand = new Command(() =>
            {
                //FileStream pic = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), FileMode.Open);
                //FileStream piic = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), FileImageSource.);
               // ImageSource image = ImageSource.FromFile(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
                //var pic = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "*.jpeg");
            });
        }
        public void SafeUser()
        {

        }
        public void DeleteUser()
        {

        }
       
        public async void AddImage()
        {
            ClicAddImageCommand = new Command(() =>
            {
                //Stream stream = await DependencyService.Get<IphotoPickerService>
                //FileStream pic = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), FileMode.Open);
                //var pic = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "*.jpeg");
            });
        }

    }
}
