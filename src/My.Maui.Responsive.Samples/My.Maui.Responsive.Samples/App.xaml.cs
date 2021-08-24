using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using My.Maui.Responsive.Samples.Pages;
using My.Maui.Responsive.Samples.ViewModels;
using Application = Microsoft.Maui.Controls.Application;

namespace My.Maui.Responsive.Samples
{
    public partial class App : Application
	{
		public App()
		{
			var services = new ServiceCollection();

			services.AddViewModels();

			var provider = services.BuildServiceProvider();

			ViewModelLocator.UseServiceProvider(provider);

			InitializeComponent();

			MainPage = new NavigationPage(new SamplePage()) { };
		}
	}
}
