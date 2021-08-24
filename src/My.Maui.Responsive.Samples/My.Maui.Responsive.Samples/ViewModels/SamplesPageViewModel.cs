using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using My.Maui.Responsive.Samples.Pages;

namespace My.Maui.Responsive.Samples.ViewModels
{
    public class SamplesPageViewModel : ViewModel
    {
        public SamplesPageViewModel()
        {
            Options = new SampleOption[]
            {
                new SampleOption<SimpleFormPage>("A Simple Form"),
                new SampleOption<OrderPage>("Responsive Ordering")
            };
        }

        public IEnumerable<SampleOption> Options { get; }
    }

    public class SampleOption
    {
        private readonly Type _pageType;

        public SampleOption(string title, Type pageType)
        {
            Title = title;
            _pageType = pageType;

            OnSelected = new Command(async () => await NavigateToAsync());
        }

        public string Title { get; }

        public async Task NavigateToAsync() => await App.Current.MainPage.Navigation.PushAsync((Page)Activator.CreateInstance(_pageType));

        public Command OnSelected { get; }

    }

    public class SampleOption<TPage> : SampleOption where TPage : Page
    {
        public SampleOption(string title) : base(title, typeof(TPage))
        {
        }
    }
}
