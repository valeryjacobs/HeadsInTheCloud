using GalaSoft.MvvmLight.Command;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadsInTheCloud.ViewModels
{
    public class TakePhotoPageViewModel
    {
        public MediaFile Image { get; set; }

        private RelayCommand _takePhotoCommand;
        public RelayCommand TakePhotoCommand
        {
            get
            {
                return _takePhotoCommand ?? new RelayCommand(async () =>
                {
                    Image = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions() { DefaultCamera = CameraDevice.Front, SaveToAlbum = false });
                });
            }
        }
    }
}
