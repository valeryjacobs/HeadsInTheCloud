using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace HeadsInTheCloud.Views
{
    public partial class SelfiesPage : ContentPage
    {
        public SelfiesPage()
        {
            InitializeComponent();
        }

        void OnTakePicture(object sender, EventArgs e)
        {
            CrossMedia.Current.Initialize();
            CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Front });
        }
    }
}
