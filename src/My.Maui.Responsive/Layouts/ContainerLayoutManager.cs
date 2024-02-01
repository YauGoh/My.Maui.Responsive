using Microsoft.Maui;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Layouts;
using System.Collections.Generic;

namespace My.Maui.Responsive.Layouts
{
    internal class ContainerLayoutManager : LayoutManager
    {
        private readonly IContainerLayout _layout;
        private Dictionary<IView, Rect> _viewSizes = new Dictionary<IView, Rect>();


        public ContainerLayoutManager(IContainerLayout layout) : base(layout)
        {
            _layout = layout;
        }

        public override Size ArrangeChildren(Rect bounds)
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

                _viewSizes.Add(row, new Rect(new Point(_layout.Padding.Left, y),  rowSize));

                y += rowSize.Height;
            }

            return new Size(widthConstraint, y + _layout.Padding.Bottom);
        }
    }
}
