using Microsoft.Maui;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Layouts;
using My.Maui.Responsive.Extensions;
using System;
using System.Collections.Generic;

namespace My.Maui.Responsive.Layouts
{
    internal class ContainerLayoutManager : LayoutManager
    {
        private readonly IContainerLayout _layout;
        private Dictionary<IView, Rectangle> _viewSizes = new Dictionary<IView, Rectangle>();


        public ContainerLayoutManager(IContainerLayout layout) : base(layout)
        {
            _layout = layout;
        }

        public override Size ArrangeChildren(Rectangle bounds)
        {
            foreach(var (row, rectangle) in _viewSizes)
            {
                var rowBounds = rectangle.Offset(bounds.Left, bounds.Top);

                row.Arrange(rowBounds);
            }

            return bounds.Size;
        }

        public override Size Measure(double widthConstraint, double heightConstraint)
        {
            _viewSizes.Clear();

            var y = _layout.Padding.Top;

            foreach (var row in _layout.GetOrderedVisibleRows())
            {
                var rowSize = row.Measure(widthConstraint - _layout.Padding.HorizontalThickness, double.PositiveInfinity);

                _viewSizes.Add(row, new Rectangle(new Point(_layout.Padding.Left, y),  rowSize));

                y += rowSize.Height;
            }

            return new Size(widthConstraint, y + _layout.Padding.Bottom);
        }
    }
}
