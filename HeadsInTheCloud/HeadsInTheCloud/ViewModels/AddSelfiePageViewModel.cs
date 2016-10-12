using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using HeadsInTheCloud.Services;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadsInTheCloud.ViewModels
{
    public class AddSelfiePageViewModel
    {
        private ISelfieService _selfieService;

        public AddSelfiePageViewModel()
        {
            _selfieService = SimpleIoc.Default.GetInstance<ISelfieService>();
        }

        public MediaFile Image { get; set; }
        public string Name { get; set; }

        private RelayCommand _saveSelfieCommand;
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
