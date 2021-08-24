using Microsoft.Extensions.DependencyInjection;
using System;

namespace My.Maui.Responsive.Samples.ViewModels
{
    public static class ViewModelLocator
    {
        private static IServiceProvider _serviceProvider;

        public static void UseServiceProvider(IServiceProvider provider) => _serviceProvider = provider;

        public static SamplesPageViewModel SamplesPage => GetScoped<SamplesPageViewModel>();

        public static SimpleFormPageViewModel SimpleFormPage => GetScoped<SimpleFormPageViewModel>();

        private static TViewModel GetScoped<TViewModel>() where TViewModel: ViewModel
        {
            var scope = _serviceProvider.CreateScope();

            var model = scope.ServiceProvider.GetRequiredService<TViewModel>();

            model.Disposed += (_, _) => scope.Dispose();

            return model;
        }
    }
}
