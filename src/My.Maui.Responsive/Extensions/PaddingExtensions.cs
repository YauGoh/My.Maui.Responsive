﻿namespace My.Maui.Responsive.Extensions;

[Flags]
internal enum OffsetFlags
{
    Top = 1,
    Bottom = 2,
    Left = 4,
    Right = 8
}

internal static class PaddingExtensions
{
    internal static double GetWidth(this Thickness padding) => padding.Left + padding.Right;

    internal static Size GetOffset(this Thickness padding, OffsetFlags from)
    {
        var size = new Size();

        if (from.HasFlag(OffsetFlags.Bottom)) size = size + new Size(0, padding.Bottom == default ? 0 : (-1 * padding.Bottom));
        else if (from.HasFlag(OffsetFlags.Top)) size = size + new Size(0, padding.Top);

        if (from.HasFlag(OffsetFlags.Right)) size = size + new Size(padding.Right == default ? 0 : (-1 * padding.Right), 0);
        else if (from.HasFlag(OffsetFlags.Left)) size = size + new Size(padding.Left, 0);

        return size;
    }
}