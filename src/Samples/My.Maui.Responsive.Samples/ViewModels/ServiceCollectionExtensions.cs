using System.Reflection;

namespace My.Maui.Responsive.Samples.ViewModels;

internal static class ServiceCollectionExtensions
{
    internal static TServiceCollection UseViewModels<TServiceCollection>(this TServiceCollection serviceCollection) where TServiceCollection : IServiceCollection
    {
        var viewModels = Assembly.GetExecutingAssembly().GetTypes().Where(_ => !_.IsAbstract && _.IsAssignableTo(typeof(ViewModel)));

        foreach (var viewModel in viewModels)
            serviceCollection.AddTransient(viewModel);

        return serviceCollection;
    }
}