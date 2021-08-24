using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using System;

namespace My.Maui.Responsive
{
    internal interface IWindowSizeProvider
    {
        Size Get();

        event EventHandler<Size>? SizeChanged;

        private static IWindowSizeProvider _instance = new CurrentApplicationMainPageWindowSizeProvider();

        internal static IWindowSizeProvider Instance => _instance;
    }

    class CurrentApplicationMainPageWindowSizeProvider : IWindowSizeProvider
    {
        public CurrentApplicationMainPageWindowSizeProvider()
        {
            Application.Current.MainPage.SizeChanged += (sender, args) => SizeChanged?.Invoke(this, Get());
        }

        public event EventHandler<Size>? SizeChanged;

        public Size Get() => Application.Current.MainPage.ContainerArea.Size;
    }
}
