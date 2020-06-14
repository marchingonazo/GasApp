using System;
using System.Collections.Generic;
using System.ComponentModel;

using Xamarin.Forms;
using System.Windows.Input;
using System.IO;
using GasApp.Models;
using Plugin.Media;
using System.Threading.Tasks;
using Plugin.Media.Abstractions;
using GasApp.Services;

namespace GasApp.ViewModels
{
    public class RegistrationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ClicLoginPageCommand { get; set; }
        public ICommand ClicAddImageCommand { get; set; }
        public ICommand ClicSafeUserCommand { get; set; }  
        public ICommand ClicCancelUserCommand { get; set; }

        private MediaFile file;
        private bool isRunning;
        public bool IsRunning
        {
            set
            {
                if(isRunning != value)
                {
                    isRunning = value;
                    PropertyChanged?.Invoke
                        (this, new PropertyChangedEventArgs(nameof(IsRunning)));
                }
            }
            get
            {
                return isRunning;
            }
        }

        private bool isEnabled;
        private DataService dataService;

        private ImageSource _imageSource;
        public ImageSource ImageSource
        {
            set
            {
                if (_imageSource != value)
                {
                    _imageSource = value;
                    PropertyChanged?.Invoke
                        (this, new PropertyChangedEventArgs(nameof(ImageSource)));
                }
            }
            get
            {
                return _imageSource;
            }
        }

        public static byte[] ReadFully(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }

        public RegistrationViewModel()
        {
            this.ImageSource = "pic.png";
            dataService = new DataService();
            
            ClicLoginPageCommand = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PopAsync();
            });

            ClicAddImageCommand = new Command(async () =>
            {               
                file = await CrossMedia.Current.PickPhotoAsync(
                        new PickMediaOptions
                        {
                            PhotoSize = PhotoSize.Small,
                        });
                if (file != null)
                {                   
                    ImageSource = ImageSource.FromStream(() =>
                    {
                        var stream = file.GetStream();
                        file.Dispose();
                        return stream;
                    });
                }
            });

            ClicSafeUserCommand = new Command(async () =>
            {
                byte[] ArrayFoto = null;
                if (file != null)
                {
                    ArrayFoto = ReadFully(this.file.GetStream());
                }
                var NewUser = Users
                {
                    
                }

            });

            //ClicCancelUserCommand = new Command(async () =>
            //{

            //});

        }
    }
}
