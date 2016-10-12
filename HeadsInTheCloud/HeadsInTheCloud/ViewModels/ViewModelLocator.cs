using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace HeadsInTheCloud.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<SelfiesPageViewModel>();
        }

        public SelfiesPageViewModel SelfiesPageViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SelfiesPageViewModel>();
            }
        }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}