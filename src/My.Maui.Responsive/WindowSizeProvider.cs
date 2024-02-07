namespace My.Maui.Responsive;

internal interface IWindowSizeProvider
{
    Size Get();

    event EventHandler<Size>? SizeChanged;

    private static IWindowSizeProvider _instance = new CurrentApplicationMainPageWindowSizeProvider();

    internal static IWindowSizeProvider Instance => _instance;

    internal static void SetProvider(IWindowSizeProvider provider) => _instance = provider;
}

class CurrentApplicationMainPageWindowSizeProvider : IWindowSizeProvider
{
    public CurrentApplicationMainPageWindowSizeProvider()
    {
        if (Application.Current == null) return;

        Application.Current.MainPage.Window.SizeChanged += (sender, args) => SizeChanged?.Invoke(this, Get());
    }

    public event EventHandler<Size>? SizeChanged;

    public Size Get() => new Size(Application.Current!.MainPage!.Window!.Width, Application.Current!.MainPage!.Window!.Height);
}