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
    public class Container : Layout, IContainerLayout
    {
        public IEnumerable<IView> GetOrderedVisibleRows() => Children
            .Where(_ => _.Visibility == Visibility.Visible)
            .OrderBy(_ => _.GetOrder());

        protected override ILayoutManager CreateLayoutManager() => new ContainerLayoutManager(this);
    }
}
