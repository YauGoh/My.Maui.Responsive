using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using My.Maui.Responsive.Samples.ViewModels;
using Application = Microsoft.Maui.Controls.Application;

namespace My.Maui.Responsive.Samples
{
    public partial class App : Application
    {
        static App()
        {
            var services = new ServiceCollection();

            services.UseViewModels();

            var provider = services.BuildServiceProvider();

            ViewModelLocator.UseServiceProvider(provider);
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }
    }
}
