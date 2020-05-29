namespace GasApp.ViewModels
{
    using GasApp.Models;
    using System.Collections.ObjectModel;
    using System.ComponentModel;

    public class ProductsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Products> Prod { get; set; }

        public ProductsViewModel()
        {

        }
    }
}
