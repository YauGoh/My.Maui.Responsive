using System.ComponentModel;

namespace My.Maui.Responsive;

#pragma warning disable CS8601 // Possible null reference assignment.

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



#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public OnViewSize()
    {
        IWindowSizeProvider.Instance.SizeChanged += WindowSizeChangeEmitter_WindowSizeChanged;

        Default = default;
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    ~OnViewSize()
    {
        IWindowSizeProvider.Instance.SizeChanged -= WindowSizeChangeEmitter_WindowSizeChanged;
    }

    private void WindowSizeChangeEmitter_WindowSizeChanged(object? sender, Size size)
    {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
    }

    public T Value => this;

    public T Default { get; set; }

    public T? Xs
    {
        get => _xs;
        set
        {
            _xs = value;
            _xsSet = WasSet(value);
        }
    }

    public T? Sm
    {
        get => _sm;
        set
        {
            _sm = value;
            _smSet = WasSet(value);
        }
    }

    public T? Md
    {
        get => _md;
        set
        {
            _md = value;
            _mdSet = WasSet(value);
        }
    }

    public T? Lg
    {
        get => _lg;
        set
        {
            _lg = value;
            _lgSet = WasSet(value);
        }
    }

    public T? Xl
    {
        get => _xl;
        set
        {
            _xl = value;
            _xlSet = WasSet(value);
        }
    }

    public T? Xxl
    {
        get => _xxl;
        set
        {
            _xxl = value;
            _xxlSet = WasSet(value);
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


#pragma warning disable CS8603 // Possible null reference return.
    public static implicit operator T(OnViewSize<T> onViewSize)
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
#pragma warning restore CS8603 // Possible null reference return.

    private static bool WasSet(T? value)
    {
        return value != null;
    }
}


#pragma warning restore CS8601 // Possible null reference assignment.