using System;
using System.ComponentModel;

namespace My.Maui.Responsive.Samples.ViewModels
{
    public class ViewModel : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler Disposed;

        public void Dispose()
        {
            Disposed?.Invoke(this, EventArgs.Empty);
        }
    }
}
