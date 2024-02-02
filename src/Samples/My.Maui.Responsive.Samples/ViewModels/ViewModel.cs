using System.ComponentModel;

namespace My.Maui.Responsive.Samples.ViewModels;

internal abstract class ViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
}
