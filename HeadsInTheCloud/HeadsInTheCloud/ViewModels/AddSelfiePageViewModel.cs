using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using HeadsInTheCloud.Services;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadsInTheCloud.ViewModels
{
    public class AddSelfiePageViewModel : ViewModelBase
    {
        private ISelfieService _selfieService;

        public AddSelfiePageViewModel()
        {
            _selfieService = SimpleIoc.Default.GetInstance<ISelfieService>();
        }

        private MediaFile _image;
        public MediaFile Image
        {
            get
            {
                return _image;
            }
            set
            {
                Set("Image", ref _image, value);
            }
        }

        public string Name { get; set; }

        private RelayCommand _takePhotoCommand = null;
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

        private RelayCommand _saveSelfieCommand = null;
        public RelayCommand SaveSelfieCommand
        {
            get
            {
                return _saveSelfieCommand ?? new RelayCommand(async () =>
                {
                    await _selfieService.AddSelfieAsync(new Models.Selfie() { Name = Name, Image = Image });
                });
            }
        }
    }
}
