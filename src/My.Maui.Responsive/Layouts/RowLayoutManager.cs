using Microsoft.Maui;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Layouts;
using My.Maui.Responsive.Extensions;
using System;
using System.Collections.Generic;

namespace My.Maui.Responsive.Layouts
{
    internal class RowLayoutManager : LayoutManager
    {
        private readonly IRowLayout _rowLayout;
        private Dictionary<IView, Rectangle> _viewRectangles = new Dictionary<IView, Rectangle>();
        public RowLayoutManager(IRowLayout rowLayout) : base(rowLayout) 
        {
            _rowLayout = rowLayout;
        }

        public override Size ArrangeChildren(Rectangle bounds)
        {
            foreach(var (view, rectangle) in _viewRectangles)
            {
                var childBounds = rectangle.Offset(bounds.Left, bounds.Top);

                view.Arrange(childBounds);
            }

            return bounds.Size;
        }

        public override Size Measure(double widthConstraint, double heightConstraint)
        {
            var rectangle = new Rectangle(Point.Zero, new Size(widthConstraint, heightConstraint));

            _viewRectangles.Clear();

            var current = rectangle.Location.Offset(_rowLayout.Padding, OffsetFlags.Top | OffsetFlags.Left);

            var totalColumns = _rowLayout.GetTotalColumns();

            var availableWidth = rectangle.Width - _rowLayout.Padding.HorizontalThickness;
            var availableColumns = totalColumns;

            var allocatedColumns = 0;

            var rowItems = new List<WorkingLayout>();

            var maxRowHeight = 0.0;
            var totalHeight = 0.0;

            foreach (var child in _rowLayout.GetOrderedVisibleElements())
            {
                var offset = child.GetOffset();
                var columnSpan = child.GetColumnSpan();

                var offsetWidth = Math.Min(GetAllowedWidth(offset, totalColumns, availableWidth), availableWidth);
                var columnWidth = Math.Min(GetAllowedWidth(columnSpan, totalColumns, availableWidth), availableWidth - offset);

                var childHeight = child.Measure(columnWidth, double.PositiveInfinity).Height;

                bool hasReachedEndOfRow = allocatedColumns + offset + columnSpan > availableColumns;
                if (hasReachedEndOfRow)
                {
                    rowItems.ForEach(_ => _viewRectangles.Add(_.View, _.Rectangle.WithHeight(maxRowHeight)));
                    rowItems.Clear();

                    allocatedColumns = 0;

                    current = new Point(rectangle.Location.X + _rowLayout.Padding.Left, current.Y + maxRowHeight);

                    totalHeight += maxRowHeight;
                    maxRowHeight = 0;
                }

                current = current.OffsetLeft(offsetWidth);

                rowItems.Add(new WorkingLayout(child, new Rectangle(current, new Size(columnWidth, childHeight))));
                maxRowHeight = Math.Max(maxRowHeight, childHeight);

                current = current.OffsetLeft(columnWidth);

                allocatedColumns += offset + columnSpan;
            }

            // layout remaining items
            rowItems.ForEach(_ => _viewRectangles.Add(_.View, _.Rectangle.WithHeight(maxRowHeight)));
            totalHeight += maxRowHeight;

            return new Size(rectangle.Width, totalHeight + _rowLayout.Padding.VerticalThickness);
        }

        private double GetAllowedWidth(int columnSpan, int totalColumns, double width) => columnSpan * width / totalColumns;

        class WorkingLayout
        {
            public WorkingLayout(IView view, Rectangle rectangle)
            {
                View = view;
                Rectangle = rectangle;
            }

            public IView View { get; }
            public Rectangle Rectangle { get; }
        }
    }
}
