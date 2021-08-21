using Microsoft.Maui.Graphics;

namespace My.Maui.Responsive.Extensions
{
    internal static class SizeExtensions
    {
        internal static Size AddWidth(this Size size, double width) => new Size(size.Width + width, size.Height);
    }
}
