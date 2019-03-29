using System;
using System.Threading.Tasks;
using ComposTux.Droid.Helpers;
using ComposTux.Helpers;
using Xamarin.Forms;

[assembly:Dependency(typeof(PathString))]
namespace ComposTux.Droid.Helpers
{
    public class PathString : IPathString
    {
        string IPathString.PathString()
        {
            var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return System.IO.Path.Combine(path, "compostux.db3");
        }
    }
}
