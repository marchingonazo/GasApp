using System;
using GasApp.Interfaces;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(GasApp.iOS.Implementations.PathService))]
namespace GasApp.iOS.Implementations
{
    public class PathService : IPathService
    {
        public string GetDataBasePath()
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if(!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }
            return Path.Combine(libFolder, "GasappDb.db3");
        }
    }
}