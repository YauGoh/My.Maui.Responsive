using Moq;

namespace My.Maui.Responsive.Tests;

internal abstract class MockView : BindableObject, IView
{
    public abstract string AutomationId { get; }

    public abstract FlowDirection FlowDirection { get; }

    public abstract Microsoft.Maui.Primitives.LayoutAlignment HorizontalLayoutAlignment { get; }

    public abstract Microsoft.Maui.Primitives.LayoutAlignment VerticalLayoutAlignment { get; }

    public abstract Semantics Semantics { get; }

    public abstract IShape? Clip { get; }

    public abstract IShadow? Shadow { get; }

    public abstract bool IsEnabled { get; }

    public abstract Microsoft.Maui.Visibility Visibility { get; }

    public abstract double Opacity { get; }

    public abstract Paint? Background { get; }

    public abstract Rect Frame { get; set; }

    public abstract double Width { get; }

    public abstract double MinimumWidth { get; }

    public abstract double MaximumWidth { get; }

    public abstract double Height { get; }

    public abstract double MinimumHeight { get; }

    public abstract double MaximumHeight { get; }

    public abstract Thickness Margin { get; }

    public abstract IViewHandler? Handler { get; set; }

    public abstract Size DesiredSize { get; }

    public abstract IElement? Parent { get; }

    public abstract double TranslationX { get; }

    public abstract double TranslationY { get; }

    public abstract double Scale { get; }

    public abstract double ScaleX { get; }

    public abstract double ScaleY { get; }

    public abstract double Rotation { get; }

    public abstract double RotationX { get; }

    public abstract double RotationY { get; }

    public abstract double AnchorX { get; }

    public abstract double AnchorY { get; }
    public abstract bool IsFocused { get; set; }

    public int ZIndex => throw new NotImplementedException();

    public bool InputTransparent => throw new NotImplementedException();

    IElementHandler? IElement.Handler { get; set; }

    public abstract Size Arrange(Rect bounds);


    public abstract bool Focus();

    public abstract void InvalidateArrange();

    public abstract void InvalidateMeasure();

    public abstract Size Measure(double widthConstraint, double heightConstraint);

    public abstract void Unfocus();
}

internal class MockViewBuilder
{
    private readonly double _requiredHeight;
    private readonly ResponsiveSpecifications _columnSpan;

    internal static MockViewBuilder Default => new MockViewBuilder(new ResponsiveSpecifications());

    private MockViewBuilder(ResponsiveSpecifications columnSpan, double requiredHeight = 100)
    {
        _requiredHeight = requiredHeight;
        _columnSpan = columnSpan;
    }

    public MockViewBuilder WithHeight(double height) => new MockViewBuilder(_columnSpan, height);

    public MockViewBuilder WithColumnSpan(ResponsiveSpecifications columnSpecifications) => new MockViewBuilder(columnSpecifications, _requiredHeight);

    internal Mock<MockView> Build()
    {
        var mock = new Mock<MockView>();

        mock.Setup(_ => _.Measure(It.IsAny<double>(), It.IsAny<double>())).Returns((double width, double height) => new Size(width, _requiredHeight));
        mock.Object.SetValue(Row.ColumnSpanProperty, _columnSpan);

        return mock;
    }
}
