using Moq;

namespace My.Maui.Responsive.Tests;

[Collection(nameof(IWindowSizeProvider))]
public class MyMauiTestBase
{
    private Mock<IWindowSizeProvider> _mockWindowSizeProvider;

    public MyMauiTestBase()
    {

        _mockWindowSizeProvider = new Mock<IWindowSizeProvider>();

        WindowSizeProvider = _mockWindowSizeProvider.Object;

        IWindowSizeProvider.SetProvider(WindowSizeProvider);

        SetWindowSize(new Size(1024, 4000));
    }

    internal IWindowSizeProvider WindowSizeProvider { get; }

    internal void SetWindowSize(Size size) => _mockWindowSizeProvider.Setup(_ => _.Get()).Returns(size);

    internal void SetWindowWidth(double width)
    {
        var newSize = WindowSizeProvider.Get() with { Width = width };

        SetWindowSize(newSize);
    }

    internal void InvokeSizeChange(Size size)
    {
        SetWindowSize(size);

        _mockWindowSizeProvider.Raise(provider => provider.SizeChanged += (_, _) => { }, EventArgs.Empty);
    }
}
