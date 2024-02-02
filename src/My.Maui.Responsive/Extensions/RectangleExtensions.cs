namespace My.Maui.Responsive.Extensions;

internal static class RectangleExtensions
{
    internal static Rect WithHeight(this Rect rectangle, double height) => new Rect(rectangle.Location, new Size(rectangle.Width, height));
}