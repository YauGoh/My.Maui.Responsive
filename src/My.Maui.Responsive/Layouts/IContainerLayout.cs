using Microsoft.Maui;
using System.Collections.Generic;

namespace My.Maui.Responsive.Layouts
{
    internal interface IContainerLayout : ILayout
    {
        IEnumerable<IView> GetOrderedVisibleRows();
    }
}
