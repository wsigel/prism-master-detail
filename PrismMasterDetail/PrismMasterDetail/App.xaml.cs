using Prism;
using Prism.Ioc;
using PrismMasterDetail.ViewModels;
using PrismMasterDetail.Views;
using Xamarin.Essentials.Interfaces;
using Xamarin.Essentials.Implementation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PrismMasterDetail.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PrismMasterDetail
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            //await NavigationService.NavigateAsync("NavigationPage/MainPage");
            await NavigationService.NavigateAsync("PrismMasterDetailPage/NavigationPage/MasterPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            containerRegistry.RegisterSingleton<ICustomerService, CustomerService>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<PrismMasterDetailPage, PrismMasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<PrismDetailPage, PrismDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<MasterPage, MasterPageViewModel>();
        }
    }
}
