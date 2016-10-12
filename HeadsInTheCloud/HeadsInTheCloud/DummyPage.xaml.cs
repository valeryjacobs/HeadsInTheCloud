using GalaSoft.MvvmLight.Ioc;
using HeadsInTheCloud.Abstracts;
using HeadsInTheCloud.Services;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace HeadsInTheCloud
{
    public partial class DummyPage : ContentPage
    {
        public DummyPage()
        {
            OnClicked(this, new EventArgs());
        }

        private async void OnClicked(object sender, EventArgs e)
        {
            InitializeComponent();
            await CrossMedia.Current.Initialize();
            var mediafile = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions()
            { DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Front });
            var blobStorage = SimpleIoc.Default.GetInstance<IBlobStorage>();
            await blobStorage.SaveMediaFile(mediafile.GetStream(), "PeterBryntesson");
            string imageUrl = "https://headsinthecloud.blob.core.windows.net/mycontainer/" + "PeterBryntesson" + "?sv=2015-04-05&ss=bqtf&srt=sco&sp=rwdlacup&se=2016-10-12T23%3A19%3A01Z&sig=%2FxquMz7mlRk%2F9N%2FQIi6k%2BMIO5hNswtWX7lEBqR75%2FZ4%3D";
            var selfieService = new SelfieService();
            await selfieService.AddSelfieAsync(new Models.Selfie() { Name = "BartSimpson", ImageUrl = imageUrl });
            var list = await selfieService.GetAllAsync();
            foreach (var selfie in list)
            {
                Debug.WriteLine(selfie.Name);
            }
        }
    }
}
