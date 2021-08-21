using Microsoft.Maui.Graphics;

namespace My.Maui.Responsive.Extensions
{
    internal static class RectangleExtensions
    {
        internal static Rectangle WithHeight(this Rectangle rectangle, double height) => new Rectangle(rectangle.Location, new Size(rectangle.Width, height));
    }
}
