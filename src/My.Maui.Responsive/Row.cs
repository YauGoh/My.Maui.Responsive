﻿using Microsoft.Maui.Layouts;
using My.Maui.Responsive.Extensions;
using My.Maui.Responsive.Layouts;

namespace My.Maui.Responsive;

[ContentProperty(nameof(Children))]
public partial class Row : Layout, IRowLayout
{
    public static BindableProperty ColumnsProperty = BindableProperty.Create(nameof(Columns), typeof(int), typeof(Row), 12);

    public int Columns { get => (int)GetValue(ColumnsProperty); set => SetValue(ColumnsProperty, value); }

    public IEnumerable<IView> GetOrderedVisibleElements() => Children
        .Where(_ => _.IsVisible())
        .OrderBy(_ => _.GetOrder());

    protected override ILayoutManager CreateLayoutManager() => new RowLayoutManager(this);
}
