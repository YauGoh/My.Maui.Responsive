using My.Maui.Responsive.Samples.Pages;
using Application = Microsoft.Maui.Controls.Application;

namespace My.Maui.Responsive.Samples
{
    public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new SamplePage();
		}
	}
}
