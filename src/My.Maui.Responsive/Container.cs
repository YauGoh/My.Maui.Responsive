using Microsoft.Maui.Layouts;
using My.Maui.Responsive.Extensions;
using My.Maui.Responsive.Layouts;

namespace My.Maui.Responsive;

[ContentProperty(nameof(Children))]
public class Container : Layout, IContainerLayout
{
    public IEnumerable<IView> GetOrderedVisibleRows() => Children
        .Where(_ => _.IsVisible())
        .OrderBy(_ => _.GetOrder());

    protected override ILayoutManager CreateLayoutManager() => new ContainerLayoutManager(this);
}
