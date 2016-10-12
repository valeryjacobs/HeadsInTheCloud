using HeadsInTheCloud.Models;
using HeadsInTheCloud.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Command;

namespace HeadsInTheCloud.ViewModels
{
    public class SelfiesPageViewModel
    {
        private ObservableCollection<Selfie> _selfies = new ObservableCollection<Selfie>();
        private ISelfieService _selfieService;

        private RelayCommand _gotoTakePhotoPageCommand;
        public RelayCommand GotoTakePhotoPageCommand
        {
            get
            {
                return _gotoTakePhotoPageCommand ?? new RelayCommand(() =>
                {
                    //NavigatetoTakePhotoPage();
                });
            }
        }
        public ObservableCollection<Selfie> Selfies { get { return _selfies; } }

        public SelfiesPageViewModel()
        {
            _selfieService = SimpleIoc.Default.GetInstance<ISelfieService>();
        }

        public async Task LoadAsync()
        {
            var list = await _selfieService.GetAllAsync();
            Selfies.Clear();
            foreach (var selfie in list)
            {
                Selfies.Add(selfie);
            }
        }
    }
}
