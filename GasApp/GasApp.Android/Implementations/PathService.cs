using GasApp.Interfaces;
using System;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(GasApp.Droid.Implementations.PathService))]
namespace GasApp.Droid.Implementations
{
    public class PathService : IPathService
    {
        public string GetDataBasePath()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return Path.Combine(path, "GasappDb.db3");
        }
    }
}