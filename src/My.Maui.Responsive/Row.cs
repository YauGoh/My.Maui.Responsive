using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Layouts;
using My.Maui.Responsive.Extensions;
using My.Maui.Responsive.Layouts;
using System.Collections.Generic;
using System.Linq;

namespace My.Maui.Responsive
{
    [ContentProperty(nameof(Children))]
    public partial class Row : Layout, IRowLayout
    {
        public static BindableProperty ColumnsProperty = BindableProperty.Create(nameof(Columns), typeof(int), typeof(Row), 12);

        public int Columns { get => (int)GetValue(ColumnsProperty); set => SetValue(ColumnsProperty, value); }

        public IEnumerable<IView> GetOrderedVisibleElements() => Children
            .Where(_ => _.Visibility == Visibility.Visible)
            .OrderBy(_ => _.GetOrder());

        public int GetTotalColumns()
        {
            var visibleViews = GetOrderedVisibleElements();

            if (visibleViews.All(_ => _.GetColumnSpan() == default)) return visibleViews.Count();

            if (Columns == default) return visibleViews.Sum(_ => _.GetColumnSpan() == default ? 1 : _.GetColumnSpan());

            return Columns;
        }

        protected override ILayoutManager CreateLayoutManager() => new RowLayoutManager(this);
    }
}