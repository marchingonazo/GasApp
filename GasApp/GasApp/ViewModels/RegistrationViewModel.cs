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
using GasApp.Helpers;

namespace GasApp.ViewModels
{
    public class RegistrationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ClicLoginPageCommand { get; set; }
        public ICommand ClicAddImageCommand { get; set; }
        public ICommand ClicSafeUserCommand { get; set; }  
        public ICommand ClicCancelUserCommand { get; set; }

        //guarar nuevo usuario
        public string Name { get; set; }
        public string Pass { get; set; }
        public string ConfPass { get; set; }
        public bool Remembered { get; set; }
        public string Email { get; set; }
        public string _ImagePath { get; set; }
        public byte[] _Image { get; set; }
        public DateTime Date { get; set; }
        public string Phone { get; set; }

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
        public bool IsEnabled
        {
            set
            {
                if (isEnabled != value)
                {
                    isEnabled = value;
                    PropertyChanged?.Invoke
                        (this, new PropertyChangedEventArgs(nameof(IsRunning)));
                }
            }
            get
            {
                return isEnabled;
            }
        }

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
            IsEnabled = true;
            IsRunning = false;
            
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
                        return stream;
                    });
                }
            });

            ClicSafeUserCommand = new Command(async () =>
            {
                IsRunning = true;
                IsEnabled = false;          
                byte[] ArrayFoto = null;
                if (file != null)
                {
                    ArrayFoto = ReadFully(this.file.GetStream());
                }

                if (string.IsNullOrEmpty(Name))
                {
                    await Application.Current.MainPage.DisplayAlert("Error","Debe tener Nombre", "OK");
                    IsEnabled = true;
                    IsRunning = false;
                    return;
                }

                if (string.IsNullOrEmpty(Email))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Usuario debe tener Email", "OK");
                    IsEnabled = true;
                    IsRunning = false;
                    return;
                }

                if (!EmailHelper.IsValidEmail(Email))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Formato de Email No Valido", "OK");
                    IsEnabled = true;
                    IsRunning = false;
                    return;
                }

                if (string.IsNullOrEmpty(Pass))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Usuario Debe tener password", "OK");
                    IsEnabled = true;
                    IsRunning = false;
                    return;
                }

                if(string.IsNullOrEmpty(ConfPass))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Usuario Debe confirmar password", "OK");
                    IsEnabled = true;
                    IsRunning = false;
                    return;
                }

                if (!Pass.Equals(ConfPass))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "El password debe ser igual", "OK");
                    IsEnabled = true;
                    IsRunning = false;
                    return;
                }

                if (Pass.Length < 6)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Password debe tener mas de 6 caracteres", "OK");
                    IsEnabled = true;
                    IsRunning = false;
                    return;
                }

                if (string.IsNullOrEmpty(Phone))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Debe tener No. Telefono", "OK");
                    IsEnabled = true;
                    IsRunning = false;
                    return;
                }

                await dataService.Insert(new Users
                {
                    Name = Name,
                    Password = Pass,
                    Email = Email,
                    //Date = Date.Date,
                    _Image = ArrayFoto,
                    Remembered = false,
                    Telephone = Phone
                });
                //IsRunning = false;
               // IsEnabled = true;

                await dataService.GetAllUsers();
            });

            //ClicCancelUserCommand = new Command(async () =>
            //{

            //});

        }

        

    }
}
