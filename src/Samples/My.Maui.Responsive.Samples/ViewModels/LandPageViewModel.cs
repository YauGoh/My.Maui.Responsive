using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace My.Maui.Responsive.Samples.ViewModels
{
    internal class LandPageViewModel : ViewModel
    {
        public LandPageViewModel()
        {
            SamplePages = new SamplePage[]
            {

            };
        }

        public IEnumerable<SamplePage> SamplePages { get; }
    }

    internal record SamplePage(string Title, Type PageType)
    {
        internal async Task NavigateTo() => await App.Current.MainPage.Navigation.PushAsync((Page)Activator.CreateInstance(PageType));
    }

    internal record SamplePage<TPage> : SamplePage where TPage : Page, new()
    {
        public SamplePage(string title) : base(title, typeof(TPage)) { }
    }
}
