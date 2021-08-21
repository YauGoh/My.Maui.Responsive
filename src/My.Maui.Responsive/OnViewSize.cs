using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Graphics;
using System;
using System.ComponentModel;

namespace My.Maui.Responsive
{
    public class OnViewSize<T> : IMarkupExtension<BindingBase>, INotifyPropertyChanged
    {
        private T? _xs;
        private bool _xsSet;

        private T? _sm;
        private bool _smSet;

        private T? _md;
        private bool _mdSet;

        private T? _lg;
        private bool _lgSet;

        private T? _xl;
        private bool _xlSet;

        private T? _xxl;
        private bool _xxlSet;


        public OnViewSize()
        {
            IWindowSizeProvider.Instance.SizeChanged += WindowSizeChangeEmitter_WindowSizeChanged;
        }

        ~OnViewSize()
        {
            IWindowSizeProvider.Instance.SizeChanged -= WindowSizeChangeEmitter_WindowSizeChanged;
        }

        private void WindowSizeChangeEmitter_WindowSizeChanged(object? sender, Size size)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
        }

        public T? Value => this;

        public T? Default { get; set; }

        public T? Xs
        {
            get => _xs;
            set
            {
                _xs = value;
                _xsSet = true;
            }
        }

        public T? Sm
        {
            get => _sm;
            set
            {
                _sm = value;
                _smSet = true;
            }
        }

        public T? Md
        {
            get => _md;
            set
            {
                _md = value;
                _mdSet = true;
            }
        }

        public T? Lg
        {
            get => _lg;
            set
            {
                _lg = value;
                _lgSet = true;
            }
        }

        public T? Xl
        {
            get => _xl;
            set
            {
                _xl = value;
                _xlSet = true;
            }
        }

        public T? Xxl
        {
            get => _xxl;
            set
            {
                _xxl = value;
                _xxlSet = true;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public BindingBase ProvideValue(IServiceProvider serviceProvider)
        {
            var binding = new Binding(nameof(Value), mode: BindingMode.OneWay, source: this);

            return binding;
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return ((IMarkupExtension<BindingBase>)this).ProvideValue(serviceProvider);
        }

        public static implicit operator T?(OnViewSize<T> onViewSize)
        {
            var deviceSize = IDeviceSizeProvider.Instance.Get();

            switch (deviceSize)
            {
                case DeviceSize.XSmall:
                    return onViewSize._xsSet ? onViewSize.Xs : onViewSize.Default;

                case DeviceSize.Small:
                    return onViewSize._smSet ? onViewSize.Sm : onViewSize.Default;

                case DeviceSize.Medium:
                    return onViewSize._mdSet ? onViewSize.Md : onViewSize.Default;

                case DeviceSize.Large:
                    return onViewSize._lgSet ? onViewSize.Lg : onViewSize.Default;

                case DeviceSize.XLarge:
                    return onViewSize._xlSet ? onViewSize.Xl : onViewSize.Default;

                case DeviceSize.XXLarge:
                    return onViewSize._xxlSet ? onViewSize.Xxl : onViewSize.Default;
            }

            return onViewSize.Default;
        }
    }
}
