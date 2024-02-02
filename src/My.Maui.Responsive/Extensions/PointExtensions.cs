namespace My.Maui.Responsive.Extensions;

internal static class PointExtensions
{
    internal static Point Offset(this Point point, Size size) => point + size;

    internal static Point Offset(this Point point, Thickness padding, OffsetFlags from) => point + padding.GetOffset(from);

    internal static Point OffsetLeft(this Point point, double left) => new Point(point.X + left, point.Y);
}
