using My.Maui.Responsive.Samples.Pages;
using My.Maui.Responsive.Samples.ViewModels;

namespace My.Maui.Responsive.Samples;

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

        MainPage = new NavigationPage(new LandingPage());
    }
}
